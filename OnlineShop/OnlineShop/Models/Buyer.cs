using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Buyer : ApplicationUser
    {
        public ShoppingCart ShoppingCart { get; set; }
        public Address Address { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}