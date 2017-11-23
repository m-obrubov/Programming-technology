using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class EmployeeDAO : AbstractDAO<Employee, int>
    {
        public EmployeeDAO() : base()
        {
        }

        public override bool Create(Employee input)
        {
            entities.Employee.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(Employee input)
        {
            entities.Employee.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<Employee> GetAll() => entities.Employee.Select(n => n);

        public override Employee GetById(int id) => entities.Employee.FirstOrDefault(n => n.Id == id);

        public override bool Update(Employee input)
        {
            Employee current = entities.Employee.FirstOrDefault(n => n.Id == input.Id);
            current.MonthSalary = input.MonthSalary;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}