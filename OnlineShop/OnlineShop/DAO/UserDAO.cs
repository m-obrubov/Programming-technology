using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class UserDAO
    {
        private Entities entities = new Entities();

        public bool Create(AspNetUsers input)
        {
            entities.AspNetUsers.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(AspNetUsers input)
        {
            AspNetUsers user = entities.AspNetUsers.FirstOrDefault(n => n.Id == input.Id);
            entities.AspNetUsers.Remove(user);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<AspNetUsers> GetAll() => entities.AspNetUsers.Select(n => n);

        public AspNetUsers GetById(string id) => entities.AspNetUsers.FirstOrDefault(n => n.Id == id);

        public bool Update(AspNetUsers input)
        {
            AspNetUsers current = entities.AspNetUsers.FirstOrDefault(n => n.Id == input.Id);
            current.Name = input.Name;
            current.Surname = input.Surname;
            current.Email = input.Email;
            current.PhoneNumber = input.PhoneNumber;
            current.PhoneNumberConfirmed = input.PhoneNumberConfirmed;
            current.LockoutEnabled = input.LockoutEnabled;
            return entities.SaveChanges() == 1 ? true : false;
        }

        public AspNetUsers GetByIdWithRoles(string id)
        {
            return entities.AspNetUsers.Include("AspNetRoles").FirstOrDefault(n => n.Id == id);
        }
    }
}