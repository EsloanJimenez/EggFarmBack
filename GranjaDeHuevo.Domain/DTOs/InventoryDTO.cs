using GranjaDeHuevo.Domain.Core;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class InventoryDTO : BaseUserDTO
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int QuantityAdded { get; set; }
        public int QuantityAvailable { get; set; }
        public string Notes { get; set; }
        public string ProductName { get; set; }
    }
}
