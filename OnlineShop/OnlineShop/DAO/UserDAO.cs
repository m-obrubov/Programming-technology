using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using System.Data.Entity;

namespace OnlineShop.DAO
{
    public class UserDAO : AbstractDAO<AspNetUsers, string>
    {
        public UserDAO() : base()
        {
        }

        public override bool Create(AspNetUsers input)
        {
            entities.AspNetUsers.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(AspNetUsers input)
        {
            entities.AspNetUsers.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<AspNetUsers> GetAll() => entities.AspNetUsers.Select(n => n);

        public override AspNetUsers GetById(string id) => entities.AspNetUsers.FirstOrDefault(n => n.Id == id);

        public override bool Update(AspNetUsers input)
        {
            AspNetUsers current = entities.AspNetUsers.FirstOrDefault(n => n.Id == input.Id);
            current.Name = input.Name;
            current.Surname = input.Surname;
            current.Email = input.Email;
            current.PhoneNumber = input.PhoneNumber;
            current.PasswordHash = input.PasswordHash;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}