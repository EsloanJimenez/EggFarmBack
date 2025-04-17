using GranjaDeHuevo.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class ProductsDTO : BaseUserDTO
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo nombre no puede superar los 50 caracteres.")]
        public string ProductName { get; set; }
        [StringLength(200, ErrorMessage = "El campo descripcion no puede tener mas de 200 caracteres.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "El campo precio es requerido.")]
        [Range(1, 400, ErrorMessage = "El precio debe de estar entre 1 y 400")]
        public decimal Price { get; set; }
        public int UserCreation { get; set; }
        public int? UserModify { get; set; }
    }
}
