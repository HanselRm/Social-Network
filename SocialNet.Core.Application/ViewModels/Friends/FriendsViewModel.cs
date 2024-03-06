using SocialNet.Core.Application.ViewModels.Posts;
using SocialNet.Core.Application.ViewModels.Users;

namespace SocialNet.Core.Application.ViewModels.Friends
{
    public class FriendsViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
        //Friends 2
        public int FriendId { get; set; }

        public string FriendName { get; set; }

        public string FriendLastName { get; set; }

        public string FriendPhoto { get; set; }

        public List<PostViewModel>? FriendPublications { get; set; }

    }
}
