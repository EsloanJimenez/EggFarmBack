using GranjaDeHuevo.Domain.Core;
using System.Collections.Generic;

namespace GranjaDeHuevo.Domain.Entity
{
    public class Customers : BaseAuditory
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
