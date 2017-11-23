using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class BuyerDAO : AbstractDAO<Buyer, int>
    {
        public BuyerDAO() : base()
        {
        }

        public override bool Create(Buyer input)
        {
            entities.Buyer.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(Buyer input)
        {
            entities.Buyer.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<Buyer> GetAll() => entities.Buyer.Select(n => n);

        public override Buyer GetById(int id) => entities.Buyer.FirstOrDefault(n => n.Id == id);

        public override bool Update(Buyer input)
        {
            Buyer current = entities.Buyer.FirstOrDefault(n => n.Id == input.Id);
            current.ShoppingCartId = input.ShoppingCartId;
            current.AddressId = input.AddressId;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}