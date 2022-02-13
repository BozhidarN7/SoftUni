using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService userService) : base(request)
        {
            this.userService = userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View();
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return View();
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
		{
			var (isValid, errors) = userService.ValidateModel(model);

            if (!isValid)
			{
                return View(errors, "/Error");
			}

            try
			{
                userService.RegisterUser(model);
			}
            catch(ArgumentException aex)
			{
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
			}
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Users/Login");
        }
	}
}
