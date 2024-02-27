
using SocialNet.Core.Application.ViewModels.Users;

namespace SocialNet.Core.Application.Interfaces.Services
{
    public interface IUserServices : IGenericServices<SaveUserViewModel>
    {
        Task<SaveUserViewModel> Login(LoginViewModel vm);
    }
}
