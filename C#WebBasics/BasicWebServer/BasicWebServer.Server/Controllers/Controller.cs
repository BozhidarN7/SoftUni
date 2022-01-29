using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Runtime.CompilerServices;

namespace BasicWebServer.Server.Controllers
{
    public abstract class Controller
    {
        protected Controller(Request request)
        {
            Request = request;
        }

        protected Request Request { get; private init; }

        protected Response Text(string text) => new TextResponse(text);

        protected Response Html(string html, CookieCollection cookies = null)
        {
            Response response = new HtmlResponse(html);

            if (cookies != null)
            {
                foreach (Cookie cookie in cookies)
                {
                    response.Cookies.Add(cookie.Name, cookie.Value);
                }
            }

            return response;
        }

        protected Response BadRequest() => new BadRequsetResponse();

        protected Response UnAuthorized() => new UnauthorizedResponse();

        protected Response NotFound() => new NotFoundResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);

        protected Response FileResponse(string fileName) => new TextFileResponse(fileName);

        protected Response View([CallerMemberName] string viewName = "") => new ViewResponse(viewName, GetControllerName());

        private string GetControllerName() => GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}
