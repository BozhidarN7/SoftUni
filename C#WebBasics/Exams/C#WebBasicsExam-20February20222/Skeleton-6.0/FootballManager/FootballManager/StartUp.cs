﻿namespace FootballManager
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using FootballManager.Contracts;
    using FootballManager.Data.Common;
    using FootballManager.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());


            server.ServiceCollection
                .Add<IValidationService, ValidationService>()
                .Add<IRepository, Repository>()
                .Add<IUserService, UserService>()
                .Add<IPlayerService, PlayerService>()
                .Add<IUserPlayerService, UserPlayerService>();

            await server.Start();
        }
    }
}
