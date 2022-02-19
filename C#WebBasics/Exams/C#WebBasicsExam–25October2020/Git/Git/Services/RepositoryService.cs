using Git.Contracts;
using Git.Data.Common;
using Git.Data.Models;
using Git.Models;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public RepositoryService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }
        public (bool created, string error) Create(CreateRepositoryModel model, string userId)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            User user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            Repository repository = new Repository()
            {
                Name = model.Name,
                IsPublick = model.RepositoryType == "Public" ? true : false,
            };


            try
            {
                //repo.Add(repository);
                user.Repositories.Add(repository);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception ex)
            {
                error = "Could not create repository";
            }

            return (created, error);
        }

        public IEnumerable<RepositoryViewModel> GetRepositories(string userId)
        {
            return repo.All<Repository>()
                .Where(r => r.OwnerId == userId)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("dd/MM/yyyy HH.mm.ss"),
                    CommitsCount = r.Commits.Count,
                })
                .ToList();
        }

        public string GetRepositoryName(string id)
        {
            return repo.All<Repository>()
                .FirstOrDefault(r => r.Id == id)?.Name;
        }
    }
}
