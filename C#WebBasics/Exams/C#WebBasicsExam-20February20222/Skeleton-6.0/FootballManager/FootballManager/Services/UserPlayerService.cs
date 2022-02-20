using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.ExportModels;

namespace FootballManager.Services
{
    public class UserPlayerService : IUserPlayerService
    {
        private readonly IRepository repo;

        public UserPlayerService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddPlayerToUserCollection(string playerId, string userId)
        {
            User user = repo.All<User>().FirstOrDefault(u => u.Id == userId);
            Player player = repo.All<Player>().FirstOrDefault(p => p.Id == playerId);

            try
            {
                UserPlayer userPlayer = new UserPlayer()
                {
                    User = user,
                    UserId = user.Id,
                    Player = player,
                    PlayerId = player.Id
                };
                user.UserPlayers.Add(userPlayer);

                repo.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public void RemovePlayerFromUserCollection(string playerId, string userId)
        {
            User user = repo.All<User>().FirstOrDefault(u => u.Id == userId);
            Player player = repo.All<Player>().FirstOrDefault(p => p.Id == playerId);
            UserPlayer userPlayer = repo.All<UserPlayer>()
                .FirstOrDefault(up => up.PlayerId == playerId && up.UserId == userId);
            try
            {
                user.UserPlayers.Remove(userPlayer);
                player.UserPlayers.Remove(userPlayer);
                repo.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
        public IEnumerable<UserCollectionViewModel> GetUserPlayers(string id)
        {
            return repo.All<UserPlayer>()
                .Where(up => up.UserId == id)
                .Select(up => up.Player)
                .Select(p => new UserCollectionViewModel()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Description = p.Description,
                    Endurance = p.Endurance,
                    Speed = p.Speed
                })
                .ToList();
        }
    }
}
