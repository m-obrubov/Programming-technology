using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public byte[] Photo { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}