using GranjaDeHuevo.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class CustomersDTO : BaseUserDTO
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El campo nombre no puede superar los 50 caracteres.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo apellido es requerido.")]
        [StringLength(50, ErrorMessage = "El campo apellido no puede superar los 50 caracteres.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo correo es requerido.")]
        [StringLength(100, ErrorMessage = "El campo correo noo puede superar los 100 caracteres.")]
        [EmailAddress(ErrorMessage = "El correo es invalido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo telefono es requerido.")]
        [StringLength(100, ErrorMessage = "El campo telefono noo puede superar los 15 caracteres.")]
        [Phone(ErrorMessage = "El telefono es invalido")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El campo direccion es requerido.")]
        [StringLength(100, ErrorMessage = "El campo direccion noo puede superar los 100 caracteres.")]
        public string Address { get; set; }
    }
}
