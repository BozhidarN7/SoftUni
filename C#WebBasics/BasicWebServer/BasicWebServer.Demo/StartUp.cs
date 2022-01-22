﻿using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

const string HtmlForm = @"<form action='/HTML' method='POST'>
   Name: <input type='text' name='Name'/>
   Age: <input type='number' name ='Age'/>
<input type='submit' value ='Save' />
</form>";

const string DownloadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";

const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";

const string FileName = "content.txt";

const string Username = "user";
const string Password = "user123";

await DownloadSitesAsTextFile(FileName, new string[] { "https://judge.softuni.org/", "https://softuni.org/" });

await new HttpServer(routes =>
   routes.MapGet("/", new TextResponse("Hello from the server!"))
         .MapGet("/HTML", new HtmlResponse(HtmlForm))
         .MapPost("/HTML", new TextResponse("", AddFormDataAction))
         .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
         .MapGet("/Content", new HtmlResponse(DownloadForm))
         .MapPost("/Content", new TextFileResponse(FileName))
         .MapGet("/Cookies", new HtmlResponse("", AddCookiesActoin))
         .MapGet("/Session", new TextResponse("", DisplaySessionInfoAction))
         .MapGet("/Login", new HtmlResponse(LoginForm))
         .MapPost("/Login", new HtmlResponse("", LoginAction))
         .MapGet("/Logout", new HtmlResponse("", LogoutAction))
         .MapGet("/UserProfile", new HtmlResponse("", GetUserDataAction)))
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

static void AddCookiesActoin(Request request, Response response)
{
    bool requsetHasCookies = request.Cookies.Any(c => c.Name != Session.SessionCookieName);

    string bodyText = "";

    if (requsetHasCookies)
    {
        StringBuilder cookieText = new StringBuilder();
        cookieText.AppendLine("<h1>Cookies</h1>");

        cookieText.AppendLine("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

        foreach (Cookie cookie in request.Cookies)
        {
            cookieText.Append("<tr>");
            cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
            cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
            cookieText.Append("</tr>");
        }

        cookieText.Append("</table>");

        bodyText = cookieText.ToString();
    }
    else
    {
        bodyText = "<h1>Cookies set!</h1>";

        response.Cookies.Add("My-Cookie", "My-Value");
        response.Cookies.Add("My-Second-Cookie", "My-Second-Value'");
    }

    response.Body = bodyText;
}

static void DisplaySessionInfoAction(Request request, Response response)
{
    bool sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

    string bodyText = "";

    if (sessionExists)
    {
        string currentDate = request.Session[Session.SessionCurrentDateKey];

        bodyText = $"Stored date: {currentDate}!";
    }
    else
    {
        bodyText = "Current data stored";
    }

    response.Body = "";
    response.Body += bodyText;
}

static void LoginAction(Request request, Response response)
{
    request.Session.Clear();

    string bodyText = "";

    bool usernameMatches = request.Form["Username"].Trim() == Username;
    bool passwordMatches = request.Form["Password"].Trim() == Password;

    if (usernameMatches && passwordMatches)
    {
        request.Session[Session.SessionUserKey] = "MyUserId";
        response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

        bodyText = "<h3>Logged successfully!</h3>";
    }
    else
    {
        bodyText = LoginForm;
    }

    response.Body = "";
    response.Body += bodyText;
}

static void LogoutAction(Request request, Response response)
{
    request.Session.Clear();

    response.Body = "";
    response.Body += "<h3>Logged out successfully!</h3>";
}

static void GetUserDataAction(Request request, Response response)
{
    if (request.Session.ContainsKey(Session.SessionUserKey))
    {
        response.Body = "";
        response.Body += $"<h3>Currently logged-in user is with username '{Username}'</h3>";
    }
    else
    {
        response.Body = "";
        response.Body = "<h3>You should first log in - <a href='/Login'>Login</a>";
    }
}