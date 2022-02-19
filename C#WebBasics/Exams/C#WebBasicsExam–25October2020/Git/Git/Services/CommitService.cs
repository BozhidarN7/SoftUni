using Git.Contracts;
using Git.Data.Common;
using Git.Data.Models;
using Git.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    public class CommitService : ICommitService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public CommitService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }
        public (bool created, string error) Create(CreateCommitModel model, string repositoryId, string userId)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Repository repository = repo.All<Repository>()
                .FirstOrDefault(r => r.Id == repositoryId);

            Commit commit = new Commit()
            {
                Description = model.Description,
                CreatorId = userId
            };

            try
            {
                repository.Commits.Add(commit);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception ex)
            {
                error = "Could not create commit";
            }

            return (created, error);
        }

        public void DeleteCommit(string id, string userId)
        {
            User user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Commits)
                .FirstOrDefault();

            Commit commit = repo.All<Commit>().FirstOrDefault(c => c.Id == id);
            user.Commits.Remove(commit);
            repo.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetCommits(string userId)
        {
            return repo.All<Commit>()
                 .Where(c => c.CreatorId == userId)
                 .Select(c => new CommitViewModel()
                 {
                     Id = c.Id,
                     Repository = c.Repository.Name,
                     Description = c.Description,
                     CreatedOn = c.CreatedOn.ToString("yyyy-MM-dd HH:mm")
                 })
                 .ToList();
        }
    }
}
