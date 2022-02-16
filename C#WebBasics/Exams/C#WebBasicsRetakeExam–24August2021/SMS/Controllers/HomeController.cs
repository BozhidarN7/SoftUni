using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;
        public HomeController(Request request, IUserService userService, IProductService productService)
            : base(request)
        {
            this.userService = userService;
            this.productService = productService;

        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                string username = userService.GetUsername(User.Id);

                var model = new
                {
                    Username = username,
                    IsAuthenticated = User.IsAuthenticated,
                    Products = productService.GetProducts()
                };

                return View(model, "/Home/IndexLoggedIn");
            }

            return this.View(new { IsAuthenticated = User.IsAuthenticated });
        }
    }
}