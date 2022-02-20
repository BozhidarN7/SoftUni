using FootballManager.ViewModels.ExportModels;

namespace FootballManager.Contracts
{
    public interface IUserPlayerService
    {
        IEnumerable<UserCollectionViewModel> GetUserPlayers(string id);
        void AddPlayerToUserCollection(string playerId, string userId);
        void RemovePlayerFromUserCollection(string playerId, string userId);
    }
}
