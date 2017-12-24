using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class OrderDAO
    {
        private Entities entities = new Entities();

        public bool Create(Order input)
        {
            entities.Order.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(Order input)
        {
            entities.Order.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Order> GetAll() => entities.Order.Select(n => n);

        public Order GetById(int id) => entities.Order.FirstOrDefault(n => n.Id == id);

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
    }
}