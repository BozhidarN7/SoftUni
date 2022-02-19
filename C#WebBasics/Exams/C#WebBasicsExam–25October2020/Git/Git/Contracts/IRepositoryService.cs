using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contracts
{
    public interface IRepositoryService
    {
        (bool created,string error) Create(CreateRepositoryModel model, string userId);
        IEnumerable<RepositoryViewModel> GetRepositories(string userId);
        string GetRepositoryName(string id);
    }
}
