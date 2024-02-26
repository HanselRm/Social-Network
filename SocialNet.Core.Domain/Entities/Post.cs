
using SocialNet.Core.Domain.Common;

namespace SocialNet.Core.Domain.Entities
{
    public class Post : AuditableBaseEntity
    {
        public string Caption { get; set; }
        public string? ImgPost { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Hour { get; set; }


        public int IdUser { get; set; }

        //Navigation Property
        public User User { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
