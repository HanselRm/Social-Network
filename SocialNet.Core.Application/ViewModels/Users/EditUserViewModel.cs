
using Microsoft.AspNetCore.Http;
using SocialNet.Core.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SocialNet.Core.Application.ViewModels.Users
{
    public class EditUserViewModel : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        [Display(Name = "Número de Teléfono")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Ingrese un número de teléfono válido sin guiones.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string Email { get; set; }
        public string? Imagen { get; set; } 
        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; } //no

        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "La contraseña de confirmación no coincide con la contraseña.")]
        public string? ConfirmPassword { get; set; } //no
        public bool Status { get; set; }
    }
}
