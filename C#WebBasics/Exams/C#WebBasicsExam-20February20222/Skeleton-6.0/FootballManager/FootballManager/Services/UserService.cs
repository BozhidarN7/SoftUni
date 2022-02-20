using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using FootballManager.ViewModels.ImportModels;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
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

        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(u => u.Id == userId)?.Username;
        }

        public string Login(LoginViewModel model)
        {
            User user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == CalculateHash(model.Password))
                .SingleOrDefault();

            return user?.Id;
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

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username,
                Password = CalculateHash(model.Password),
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                isRegistered = true;
            }
            catch (Exception ex)
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
