using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using Git.Contracts;
using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IRepositoryService repositoryService;
        public CommitsController(Request request, ICommitService commitService, IRepositoryService repositoryService) : base(request)
        {
            this.commitService = commitService;
            this.repositoryService = repositoryService;
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<CommitViewModel> commits = commitService.GetCommits(User.Id);

            return View(new { IsAuthenticated = true, Commits = commits }, "/Commits/All");
        }

        [Authorize]
        public Response Create(string id)
        {
            string repoName = repositoryService.GetRepositoryName(id);
            return View(new { IsAuthenticated = User.IsAuthenticated, RepositoryName = repoName });
        }

        [Authorize]
        public Response Delete(string id)
        {
            commitService.DeleteCommit(id,User.Id);

            return Redirect("/Commits/All");
        }

        [HttpPost]
        [Authorize]

        public Response Create(CreateCommitModel model, string id)
        {
            var (created, error) = commitService.Create(model, id, User.Id);

            if (!created)
            {
                return Redirect("/Commits/Create");
            }

            return Redirect("/Commits/All");
        }
    }
}
