using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class OrderDAO : AbstractDAO<Order, int>
    {
        public OrderDAO() : base()
        {
        }

        public override bool Create(Order input)
        {
            entities.Order.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(Order input)
        {
            entities.Order.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<Order> GetAll() => entities.Order.Select(n => n);

        public override Order GetById(int id) => entities.Order.FirstOrDefault(n => n.Id == id);

        public override bool Update(Order input)
        {
            Order current = entities.Order.FirstOrDefault(n => n.Id == input.Id);
            current.IsPayed = input.IsPayed;
            current.DeliveryAddressId = input.DeliveryAddressId;
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