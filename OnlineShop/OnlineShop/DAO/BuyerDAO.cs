using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using System.Data.Entity;

namespace OnlineShop.DAO
{
    public class BuyerDAO
    {
        private Entities entities = new Entities();

        public bool Create(string id)
        {
            Buyer buyer = new Buyer();
            buyer.UserId = id;
            entities.Buyer.Add(buyer);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(Buyer input)
        {
            entities.Buyer.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Buyer> GetAll() => entities.Buyer.Select(n => n);

        public Buyer GetById(string id) => entities.Buyer.FirstOrDefault(n => n.UserId == id);

        public Buyer GetByIdWithDetails(string id) => 
            entities.
            Buyer.
            Where(n => n.UserId == id).
            Include("Address").
            Include("AspNetUsers").
            Include("Orders").
            FirstOrDefault();

        public bool Update(Buyer input)
        {
            Buyer current = entities.Buyer.FirstOrDefault(n => n.UserId == input.UserId);
            current.Address = input.Address;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}