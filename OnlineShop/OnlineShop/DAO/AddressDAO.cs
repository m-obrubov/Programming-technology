using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class AddressDAO
    {
        private Entities entities = new Entities();

        public bool Create(Address input)
        {
            entities.Address.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(Address input)
        {
            entities.Address.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Address> GetAll() => entities.Address;

        public Address GetById(string id) => entities.Address.FirstOrDefault(n => n.UserId == id);

        public bool Update(Address input)
        {
            Address current = entities.Address.FirstOrDefault(n => n.UserId == input.UserId);
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