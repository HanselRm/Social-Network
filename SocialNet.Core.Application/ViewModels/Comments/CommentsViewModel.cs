

using System.ComponentModel.DataAnnotations;

namespace SocialNet.Core.Application.ViewModels.Comments
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir un comentario")]
        public required string Comment { get; set; }

        public int IdPost { get; set; }

        public int IdUser { get; set; }
        public required string UserName { get; set; }

        public required string PhotoUrl { get; set; }
        public int? ParentCommentId { get; set; }
        public List<CommentsViewModel>? CommentsChild { get; set; }

    }
}
