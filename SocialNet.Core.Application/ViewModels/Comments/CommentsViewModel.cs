

using System.ComponentModel.DataAnnotations;

namespace SocialNet.Core.Application.ViewModels.Comments
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir un comentario")]
        public required string Content { get; set; }

        public int PublicationsId { get; set; }

        public int UserId { get; set; }
        public required string UserName { get; set; }

        public required string PhotoUrl { get; set; }
        public int? childId { get; set; }
        public List<CommentsViewModel>? CommentsChild { get; set; }

    }
}
