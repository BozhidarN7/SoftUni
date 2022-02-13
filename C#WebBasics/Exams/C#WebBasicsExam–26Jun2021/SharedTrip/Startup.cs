namespace SharedTrip
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SharedTrip.Contracts;
    using SharedTrip.Data;
    using SharedTrip.Data.Common;
    using SharedTrip.Services;
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
                .Add<ApplicationDbContext>()
                .Add<IUserService, UserService>()
                .Add<ITripService, TripService>();

            await server.Start();
        }
    }
}
