using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class OrderDAO
    {
        private Entities entities = new Entities();

        public Order Create(Order order)
        {
            Order addedOrder = entities.Order.Add(order);
            entities.SaveChanges();
            return addedOrder;
        }

        public void AddGoodsToOrder(Order order, List<Goods> goodsInOrder)
        {
            foreach (Goods goods in goodsInOrder)
            {
                ShoppingCart item = new ShoppingCart { OrderId = order.Id, GoodsId = goods.Id };
                entities.ShoppingCart.Add(item);
            }
            entities.SaveChanges();
        }

        public bool Delete(Order input)
        {
            entities.Order.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Order> GetAll() => entities.Order.Select(n => n);

        public IEnumerable<Order> GetAllCreated() => entities.Order.Where(n => OrderStatus.Created.Equals(n.Status));

        public Order GetById(int id) => entities.Order.FirstOrDefault(n => n.Id == id);

        public Order GetByIdWithGoods(int id) => entities.Order.Include("ShoppingCart").FirstOrDefault(n => n.Id == id);
        
        public bool Update(Order input)
        {
            Order current = entities.Order.FirstOrDefault(n => n.Id == input.Id);
            current.IsPayed = input.IsPayed;
            current.Address = input.Address;
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateStatus(int id, OrderStatus status)
        {
            Order current = entities.Order.FirstOrDefault(n => n.Id == id);
            current.Status = (short)status;
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool DeleteGoodsFromOrder(Order order)
        {
            foreach (var goods in order.ShoppingCart)
            {
                entities.ShoppingCart.Remove(goods);
            }
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}