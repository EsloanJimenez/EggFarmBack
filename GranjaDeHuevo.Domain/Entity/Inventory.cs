using GranjaDeHuevo.Domain.Core;

namespace GranjaDeHuevo.Domain.Entity
{
    public class Inventory : BaseAuditory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int QuantityAdded { get; set; }
        public int QuantityAvailable { get; set; }
        public string Notes { get; set; }

        public virtual Products ProductsNavegation { get; set; }
    }
}
