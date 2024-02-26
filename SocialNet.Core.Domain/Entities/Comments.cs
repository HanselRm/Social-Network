
using SocialNet.Core.Domain.Common;

namespace SocialNet.Core.Domain.Entities
{
    public class Comments : AuditableBaseEntity
    {
        public string Comment { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Hour { get; set; }

        public int? ParentCommentId { get; set; }
        public int IdPost { get; set; }
        public int IdUser { get; set; }

        //Navigation Property
        public Post Post { get; set; }
        public User User { get; set; }
        public Comments ParentComment { get; set; }
        public  ICollection<Comments> ChildComments { get; set; }

    }
}
