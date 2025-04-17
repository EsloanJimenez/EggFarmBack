using GranjaDeHuevo.Domain.Core;
using System.Collections.Generic;

namespace GranjaDeHuevo.Domain.Entity
{
    public class Products : BaseAuditory
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
            Inventory = new HashSet<Inventory>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
 