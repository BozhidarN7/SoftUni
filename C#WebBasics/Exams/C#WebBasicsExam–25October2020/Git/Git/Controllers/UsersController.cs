using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contracts;
using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(Request request, IUserService userService) : base(request)
        {
            this.userService = userService;
        }
        public Response Register()
        {
            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isRegister, error) = userService.Register(model);

            if (isRegister)
            {
                return Redirect("/Users/Login");
            }

            return Redirect("/Users/Register");
        }

        public Response Login()
        {
            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            string id = userService.Login(model);

            if (id == null)
            {
                return Redirect("/Users/Login");
            }

            SignIn(id);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
