namespace SMS
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Services;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IUserService, UserService>()
                .Add<IRepository, Repository>()
                .Add<IProductService, ProductService>()
                .Add<ICartService, CartService>()
                .Add<IValidationService, ValidationService>();

            await server.Start();
        }
    }
}