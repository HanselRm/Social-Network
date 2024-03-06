

using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Interfaces.Services
{
    public interface IUserServicesUp <EditViewModel> : IGenericServices<SaveUserViewModel, UserViewModel, User>
    {
        Task<SaveUserViewModel> Login(LoginViewModel vm);
        Task<Boolean> GetByUserNameViewModel(string userName);
        Task Update(EditViewModel vm, int id);
        Task<EditUserViewModel> GetByIdEditViewModel(int id);

    }
}
