using GranjaDeHuevo.Domain.Core;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class OrdersDTO : BaseUserDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string FirstName { get; set; }
        public string Status { get; set; }
    }
}
