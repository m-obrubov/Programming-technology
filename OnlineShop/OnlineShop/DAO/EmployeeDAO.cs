using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Models;
using NLog;

namespace OnlineShop.DAO
{
    public class EmployeeDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Create(string id)
        {
            bool result;
            try
            {
                Employee employee = new Employee { UserId = id, MonthSalary = 10000 };
                entities.Employee.Add(employee);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка добавления сотрудника");
                result = false;
            }
            logger.Debug("Добавление сотрудника выполнено успешно");
            return result;
        }

        public bool Delete(string id)
        {
            bool result;
            try
            {
                Employee employee = entities.Employee.FirstOrDefault(n => n.UserId == id);
                entities.Employee.Remove(employee);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления сотрудника");
                result = false;
            }
            logger.Debug("Удаление сотрудника выполнено успешно");
            return result;
        }
    }
}