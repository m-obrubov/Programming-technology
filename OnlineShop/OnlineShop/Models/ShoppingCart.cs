using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<Goods> Goods { get; set; }
        public List<int> Counts { get; set; }

        public virtual Order Order { get; set; }
        public virtual Buyer Buyer { get; set; }
    }
}