using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(IRepository repo, IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }
        public (bool isRegistered, string error) Register(RegisterViewModel model)
        {
            bool isRegistered = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Cart cart = new Cart();

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                Password = CalculateHash(model.Password),
                Cart = cart,
                CartId = cart.Id
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isRegistered = true;
            }
            catch(Exception)
            {
                error = "Registration failed!";
            }

            return (isRegistered, error);
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
