using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class AddressDAO : AbstractDAO<Address, int>
    {
        public AddressDAO() : base()
        {
        }

        public override bool Create(Address input)
        {

            entities.Address.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Create(int buyerId, Address input)
        {
            Buyer buyer = entities.Buyer.FirstOrDefault(n => n.Id == buyerId);
            buyer.Address = input;
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(Address input)
        {
            entities.Address.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<Address> GetAll() => entities.Address;

        public override Address GetById(int id) => entities.Address.FirstOrDefault(n => n.Id == id);

        public override bool Update(Address input)
        {
            Address current = entities.Address.FirstOrDefault(n => n.Id == input.Id);
            current.Postcode = input.Postcode;
            current.Country = input.Country;
            current.Region = input.Region;
            current.City = input.City;
            current.Street = input.Street;
            current.House = input.House;
            current.Flat = input.Flat;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}