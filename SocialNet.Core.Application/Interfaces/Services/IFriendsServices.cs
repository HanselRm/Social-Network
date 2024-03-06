using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.ViewModels.Friends;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Interfaces.Services
{
    public interface IFriendsServices : IGenericServices<SaveFriendsViewModel, FriendsViewModel, Friends>
    {
        Task<List<FriendsViewModel>> GetAllViewModelWithInclude(int Id);
    }
}
