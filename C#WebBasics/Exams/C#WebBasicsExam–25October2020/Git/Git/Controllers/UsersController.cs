using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(Request request) : base(request)
        {
        }
        public Response Register()
        {
            return View(new { IsAuthenticated = false });
        }

        public Response Login()
        {
            return View(new { IsAuthenticated = false });
        }
    }
}
