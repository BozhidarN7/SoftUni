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
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService repositoryService;
        public RepositoriesController(Request request, IRepositoryService repositoryService) : base(request)
        {
            this.repositoryService = repositoryService;
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<RepositoryViewModel> repositories = repositoryService.GetRepositories(User.Id);

            return View(new { IsAuthenticated = User.IsAuthenticated,Repositories = repositories },"/Repositories/All");
        }

        [Authorize]

        public Response Create()
        {
            return View(new { IsAuthenticated = User.IsAuthenticated });
        }

        [Authorize]
        [HttpPost]
        public Response Create(CreateRepositoryModel model)
        {
            var (created, error) = repositoryService.Create(model, User.Id);

            if (!created)
            {
                return Redirect("/Repositories/Create");
            }

            return Redirect("/");

        }
    }
}
