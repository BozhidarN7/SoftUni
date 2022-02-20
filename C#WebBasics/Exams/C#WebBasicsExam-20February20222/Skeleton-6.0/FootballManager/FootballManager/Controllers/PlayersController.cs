using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels.ExportModels;
using FootballManager.ViewModels.ImportModels;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly IUserPlayerService userPlayerService;

        public PlayersController(Request request, IPlayerService playerService, IUserPlayerService userPlayerService) : base(request)
        {
            this.playerService = playerService;
            this.userPlayerService = userPlayerService;
        }

        [Authorize]
        public Response Collection(UserCollectionViewModel model)
        {
            IEnumerable<UserCollectionViewModel> userPlayers = userPlayerService.GetUserPlayers(User.Id);
            return View(new { IsAuthenticated = true, UserPlayers = userPlayers });
        }

        [Authorize]
        public Response AddToCollection(string playerId)
        {
            userPlayerService.AddPlayerToUserCollection(playerId, User.Id);

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response RemoveFromCollection(string playerId)
        {
            userPlayerService.RemovePlayerFromUserCollection(playerId, User.Id);

            return Redirect("/Players/Collection");
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<PlayerViewModel> players = playerService.GetPlayers();
            return View(new { IsAuthenticated = true, Players = players });
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddPlayerViewModel model)
        {
            var (added, error) = playerService.Add(model);

            if (!added)
            {
                return Redirect("/Players/Add");
            }

            return Redirect("/");
        }
    }
}
