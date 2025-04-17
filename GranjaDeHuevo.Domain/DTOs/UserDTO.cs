using GranjaDeHuevo.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class UserDTO : BaseUserDTO
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "El campo nombre de usuario es requerido.")]
        [StringLength(100, ErrorMessage = "El campo nombre de usuario no puede superar los 50 caracteres.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo contraseña es requerido.")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "El campo Role es requerido.")]
        public int RoleId {  get; set; }
        public string RoleName { get; set; }
    }
}
