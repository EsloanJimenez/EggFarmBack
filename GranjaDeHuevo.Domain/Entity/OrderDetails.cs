using GranjaDeHuevo.Domain.Core;

namespace GranjaDeHuevo.Domain.Entity
{
    public class OrderDetails : BaseAuditory
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Orders OrdersNavegation { get; set; }
        public virtual Products ProductsNavegation { get; set; }
    }
}
 