using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Contracts
{
    public interface IUserService
    {
        (bool isRegister, string error) Register(RegisterViewModel model);
        string Login(LoginViewModel model);
    }
}
