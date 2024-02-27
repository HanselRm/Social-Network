
using SocialNet.Core.Domain.Common;

namespace SocialNet.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }


        //Navigation Properties
        public ICollection<Post> Posts { get; set; }
        public ICollection<Friends> FriendshipsAsUser1 { get; set; }
        public ICollection<Friends> FriendshipsAsUser2 { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
