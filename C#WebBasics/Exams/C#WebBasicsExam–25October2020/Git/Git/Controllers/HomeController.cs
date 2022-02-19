using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace Git.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return View(new { IsAuthenticated = true }, "/Repositories/All");
            }

            return View(new { IsAuthenticated = false });
        }
    }
}
