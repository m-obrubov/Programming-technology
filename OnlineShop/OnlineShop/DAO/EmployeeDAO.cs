using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class EmployeeDAO
    {
        private Entities entities = new Entities();

        public bool Create(Employee input)
        {
            entities.Employee.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(Employee input)
        {
            entities.Employee.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Employee> GetAll() => entities.Employee.Select(n => n);

        public Employee GetById(string id) => entities.Employee.FirstOrDefault(n => n.UserId == id);

        public bool Update(Employee input)
        {
            Employee current = entities.Employee.FirstOrDefault(n => n.UserId == input.UserId);
            current.MonthSalary = input.MonthSalary;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}