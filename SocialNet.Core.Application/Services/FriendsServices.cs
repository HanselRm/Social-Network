using AutoMapper;
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Friends;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Services
{
    public class FriendsServices : GenericServices<SaveFriendsViewModel, FriendsViewModel, Friends>, IFriendsServices
    {
        private readonly IFriendsRepossitory _friendsRepository;
        private readonly IMapper _mapper;
        private readonly IPostServices _postServices;
        public FriendsServices(IFriendsRepossitory friendsRepository, IMapper mapper, IPostServices postServices) : base(friendsRepository, mapper)
        {
            _friendsRepository = friendsRepository;
            _mapper = mapper;
            _postServices = postServices;
        }

        public async Task<List<FriendsViewModel>> GetAllViewModelWithInclude(int id)
        {
            var friends = await _friendsRepository.GetAllWithIncludeAsync(new List<string> { "User1", "User2" });
            var posts = await _postServices.GetAllViewModelWithInclude();

            var userFriends = friends.Where(f => f.User1.Id == id || f.User2.Id == id).ToList();

            List<FriendsViewModel> result = new List<FriendsViewModel>();

            foreach (var friend in userFriends)
            {
                int friendId = (friend.User1.Id == id) ? friend.User2.Id : friend.User1.Id;

                var friendPosts = posts.Where(p => p.IdUser == friendId).ToList();

                FriendsViewModel viewModel = new FriendsViewModel
                {
                    Id = friend.Id,
                    FriendId = friendId,
                    UserId = id,
                    FriendName = (friendId == friend.User1.Id) ? friend.User1.Name : friend.User2.Name,
                    FriendLastName = (friendId == friend.User1.Id) ? friend.User1.LastName : friend.User2.LastName,
                    FriendPhoto = (friendId == friend.User1.Id) ? friend.User1.Imagen : friend.User2.Imagen,
                    FriendPublications = friendPosts
                };

                result.Add(viewModel);
            }

            return result;

        }
    }
}
