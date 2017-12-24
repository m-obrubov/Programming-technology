using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DAO
{
    public class UserRoleDAO
    {
        private Entities entities = new Entities();

        public IEnumerable<AspNetRoles> GetAllForUser(string id) => entities.AspNetUsers.Include("AspNetRoles").Where(n => n.Id == id).Select(n => n.AspNetRoles).FirstOrDefault();

        public IEnumerable<AspNetRoles> GetAll() => entities.AspNetRoles;

        public AspNetRoles GetByName(string name) => entities.AspNetRoles.FirstOrDefault(n => n.Name == name);

        public AspNetRoles GetById(string id) => entities.AspNetRoles.FirstOrDefault(n => n.Id == id);

        public bool AddRole(string userId, AspNetRoles role)
        {
            AspNetUsers changedUser = entities.AspNetUsers.FirstOrDefault(n => n.Id == userId);
            changedUser.AspNetRoles.Add(role);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool RemoveRole(string userId, AspNetRoles role)
        {
            AspNetUsers changedUser = entities.AspNetUsers.FirstOrDefault(n => n.Id == userId);
            AspNetRoles rmRole = entities.AspNetRoles.FirstOrDefault(n => n.Name == role.Name);
            changedUser.AspNetRoles.Remove(rmRole);
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}