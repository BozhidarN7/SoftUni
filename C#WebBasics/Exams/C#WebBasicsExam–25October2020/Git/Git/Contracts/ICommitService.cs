using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contracts
{
    public interface ICommitService
    {
        (bool created, string error) Create(CreateCommitModel model, string repositoryId, string userId);
        IEnumerable<CommitViewModel> GetCommits(string userId);
        void DeleteCommit(string id, string userId);
    }
}
