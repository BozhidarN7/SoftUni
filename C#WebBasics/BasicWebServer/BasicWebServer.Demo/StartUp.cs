using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

const string FileName = "content.txt";

await DownloadSitesAsTextFile(FileName, new string[] { "https://judge.softuni.org/", "https://softuni.org/" });

await new HttpServer(routes =>
   routes.MapGet("/", new TextResponse("Hello from the server!"))
         .MapGet("/HTML", new HtmlResponse(HtmlForm))
         .MapPost("/HTML", new TextResponse("", AddFormDataAction))
         .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
         .MapGet("/Content", new HtmlResponse(DownloadForm))
         .MapPost("/Content", new TextFileResponse(FileName)))
   .Start();

static void AddFormDataAction(Request request, Response response)
{
    response.Body = "";

    foreach (var (key, value) in request.Form)
    {
        response.Body += $"{key} - {value}";
        response.Body += Environment.NewLine;
    }
}

static async Task<string> DownloadWebSiteContent(string url)
{
    HttpClient httpClient = new HttpClient();
    using (httpClient)
    {
        var response = await httpClient.GetAsync(url);
        string html = await response.Content.ReadAsStringAsync();

        return html.Substring(0, 2000);
    }
}

static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
{
    List<Task<string>> downloads = new List<Task<string>>();

    foreach (string url in urls)
    {
        downloads.Add(DownloadWebSiteContent(url));
    }
    var responses = await Task.WhenAll(downloads);

    string responsesString = string.Join(Environment.NewLine + new string('-', 100), responses);

    await File.WriteAllTextAsync(fileName, responsesString);
}