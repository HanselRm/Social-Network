

using System.ComponentModel.DataAnnotations;

namespace SocialNet.Core.Application.ViewModels.Comments
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir un comentario")]
        public string Content { get; set; }

        public int PublicationsId { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public string PhotoUrl { get; set; }

    }
}
