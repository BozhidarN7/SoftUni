using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.ExportModels;
using FootballManager.ViewModels.ImportModels;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;
        public PlayerService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public (bool added, string error) Add(AddPlayerViewModel model)
        {
            bool added = false;
            string error = null;

            (bool isValid, string validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Player product = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Endurance = model.Endurance,
                Speed = model.Speed,
                Description = model.Description,
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                error = "Could not save product";
            }

            return (added, error);
        }

        public IEnumerable<PlayerViewModel> GetPlayers()
        {
            return repo.All<Player>()
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Description = p.Description,
                    Endurance = p.Endurance,
                    Speed = p.Speed,
                })
                .ToList();

        }
    }
}
