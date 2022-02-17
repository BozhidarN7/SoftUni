namespace Git
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using Git.Contracts;
    using Git.Data.Common;
    using Git.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<IRepository, Repository>()
                .Add<IUserService, UserService>();

            await server.Start();
        }
    }
}
