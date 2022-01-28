using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected Response Html(string text) => new HtmlResponse(text);

        protected Response BadRequest() => new BadRequsetResponse();

        protected Response UnAuthorized() => new UnauthorizedResponse();

        protected Response NotFound() => new NotFoundResponse();

        protected Response Redirect(string location) => new RedirectResponse(location);
        
        protected Response File(string fileName) => new TextFileResponse(fileName);
    }
}
