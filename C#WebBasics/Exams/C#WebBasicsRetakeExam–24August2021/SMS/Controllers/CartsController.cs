using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;
        public CartsController(Request request, ICartService cartService) : base(request)
        {
            this.cartService = cartService;
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            IEnumerable<CartViewModel> products = cartService.AddProduct(productId, User.Id);

            return View(new
            {
                products = products,
                IsAuthenticated = User.IsAuthenticated
            }, "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            cartService.BuyProduct(User.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Details()
        {
            IEnumerable<CartViewModel> products = cartService.GetProducts(User.Id);

            return View(new
            {
                products = products,
                IsAuthenticated = User.IsAuthenticated
            });
        }
    }
}
