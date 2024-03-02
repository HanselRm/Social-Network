using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet.Core.Application.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe escribir una descripcion")]
        public string Caption { get; set; }
        public string? ImgPost { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Hour { get; set; }
        public int IdUser { get; set; }
        /*public int IdComment { get; set; }*/
    }
}
