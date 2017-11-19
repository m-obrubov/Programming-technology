using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public abstract class Employee : ApplicationUser
    {
        public decimal MonthSalary { get; set; }
    }

    public class Manager : Employee
    {
        public virtual List<Order> Orders { get; set; }
    }

    public class Administrator : Employee
    {
    }
}