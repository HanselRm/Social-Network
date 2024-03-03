
namespace SocialNet.Core.Application.ViewModels.Comments
{
    public class SaveCommentViewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int IdPost { get; set; }

        public int IdUser { get; set; }
        public int? ParentCommentId { get; set; }

    }
}
