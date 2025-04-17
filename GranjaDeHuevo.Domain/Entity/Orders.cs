using GranjaDeHuevo.Domain.Core;
using System.Collections.Generic;

namespace GranjaDeHuevo.Domain.Entity
{
    public class Orders : BaseStatus
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Customers CustomersNavegation { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } 
    }
}
 