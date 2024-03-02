
using Microsoft.AspNetCore.Http;
using SocialNet.Core.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SocialNet.Core.Application.ViewModels.Posts
{
    public class SavePostViewModel : IEntity
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Debe escribir una descripcion")]
        public string Caption { get; set; }
        public string? ImgPost { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly? Hour { get; set; }
        public int IdUser { get; set; }
        
    }
}
