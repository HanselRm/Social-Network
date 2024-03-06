
using SocialNet.Core.Domain.Common;

namespace SocialNet.Core.Domain.Entities
{
    public class Friends : AuditableBaseEntity
    {
        public int IdFriend1 { get; set; }
        public int IdFriend2 { get; set; }

        //Navigation Property

        public User User1 { get; set; }
        public User User2 { get; set; }
    }
}
 