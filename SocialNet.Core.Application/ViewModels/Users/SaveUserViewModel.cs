
using Microsoft.AspNetCore.Http;
using SocialNet.Core.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SocialNet.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string Email { get; set; }
        public string? Imagen { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "El campo Nombre de Usuario es requerido")]
        public string UserName { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage = "Las contraseñas deben de coincidir")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public bool Status { get; set; }
    }
}
