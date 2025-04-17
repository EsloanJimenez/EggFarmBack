using GranjaDeHuevo.Domain.Core;
using System;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class OrderDetailsDTO : BaseUserDTO
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
