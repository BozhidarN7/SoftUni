using Git.Contracts;
using Git.Data.Common;
using Git.Data.Models;
using Git.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Git.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;
        public UserService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public string Login(LoginViewModel model)
        {
            User user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == CalculateHash(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }

        public (bool isRegister, string error) Register(RegisterViewModel model)
        {
            bool isRegister = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                Password = CalculateHash(model.Password)
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isRegister = true;
            }
            catch (Exception ex)
            {
                error = "Registration failed!";
            }

            return (isRegister, error);

        }
        private string CalculateHash(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }
    }
}
