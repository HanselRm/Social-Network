using System.ComponentModel.DataAnnotations;


namespace SocialNet.Core.Application.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir una descripcion")]
        public required string Caption { get; set; }
        public string? ImgPost { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Hour { get; set; }
        public int IdUser { get; set; }
        public int IdComment { get; set; }
    }
}
