using FootballManager.ViewModels.ExportModels;
using FootballManager.ViewModels.ImportModels;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        (bool added, string error) Add(AddPlayerViewModel model);
        IEnumerable<PlayerViewModel> GetPlayers();
    }
}
