

using System.ComponentModel.DataAnnotations;

namespace SocialNet.Core.Application.ViewModels.Friends
{
    public class SaveFriendsViewModel
    {
        public int Id { get; set; }

        public int IdFriend1 { get; set; }

        [Required(ErrorMessage = "Debe colocar algun Usuario")]
        public required string Username { get; set; }
        public int? IdFriend2 { get; set; }
    }
}
