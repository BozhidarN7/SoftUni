using FootballManager.ViewModels.ImportModels;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        (bool isRegistered, string error) Register(RegisterViewModel model);
        string Login(LoginViewModel model);

        string GetUsername(string userId);
    }
}
