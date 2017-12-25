using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class LocalShoppingCart
    {
        public LocalShoppingCart()
        {
            GoodsInCart = new List<Goods>();
        }

        public List<Goods> GoodsInCart { get; set; }
         
        public void AddToCart(Goods goods)
        {
            GoodsInCart.Add(goods);
        }

        public void RemoveFromCart(int id)
        {
            Goods goodsToRemove = GoodsInCart.First(n => n.Id == id);
            GoodsInCart.Remove(goodsToRemove);
        }
    }
}