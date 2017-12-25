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

        public bool Create(string id)
        {
            Employee employee = new Employee { UserId = id, MonthSalary = 10000 };
            entities.Employee.Add(employee);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(string id)
        {
            Employee employee = entities.Employee.FirstOrDefault(n => n.UserId == id);
            entities.Employee.Remove(employee);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Employee> GetAll() => entities.Employee.Select(n => n);

        public Employee GetById(string id) => entities.Employee.FirstOrDefault(n => n.UserId == id);
    }
}