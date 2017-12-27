using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using System.Data.Entity;

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

        public bool AddGoodsToOrder(Order order, List<Goods> goodsInOrder)
        {
            foreach (Goods goods in goodsInOrder)
            {
                ShoppingCart item = new ShoppingCart { OrderId = order.Id, GoodsId = goods.Id };
                entities.ShoppingCart.Add(item);
            }
            return entities.SaveChanges() == goodsInOrder.Count ? true : false;
        }

        public bool Delete(Order input)
        {
            entities.Order.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Order> GetAll() => entities.Order.Select(n => n);

        public IEnumerable<Order> GetAllCreated() => entities.Order.Where(n => OrderStatus.Created.Equals(n.Status));

        public Order GetById(int id) => entities.Order.FirstOrDefault(n => n.Id == id);

        public Order GetByIdWithDetails(int id) => entities.Order.Where(n => n.Id == id).Include("Buyer.AspNetUsers").Include("Employee.AspNetUsers").Include("Address").Include("ShoppingCart").FirstOrDefault();

        public Order GetForUserWithDetails(string id) => entities.Order.Where(n => n.BuyerId == id).Include("Employee.AspNetUsers").Include("Address").Include("ShoppingCart").FirstOrDefault();

        public bool UpdateManager(int id, string managerId)
        {
            Order current = entities.Order.FirstOrDefault(n => n.Id == id);
            current.ManagerId = managerId;
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