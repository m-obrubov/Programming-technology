using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using NLog;

namespace OnlineShop.DAO
{
    public class UserDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Delete(AspNetUsers input)
        {
            bool result = true;
            try
            {
                UserRoleDAO roleDAO = new UserRoleDAO();
                IEnumerable<AspNetRoles> roles = roleDAO.GetAllForUser(input.Id);
                AspNetUsers user = entities.AspNetUsers.FirstOrDefault(n => n.Id == input.Id);
                foreach (AspNetRoles item in roles)
                {
                    if(item.Name == "Buyer")
                    {
                        BuyerDAO buyerDAO = new BuyerDAO();
                        result &= buyerDAO.Delete(buyerDAO.GetById(user.Id));
                        AddressDAO addressDAO = new AddressDAO();
                        result &= addressDAO.Delete(addressDAO.GetById(user.Id));
                    }
                    else
                    {
                        EmployeeDAO employeeDAO = new EmployeeDAO();
                        result &= employeeDAO.Delete(user.Id);
                    }
                    result &= roleDAO.RemoveRole(input.Id, item);
                }
                entities.AspNetUsers.Remove(user);
                result &= entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления пользователя");
                result = false;
            }
            logger.Debug("Удаление пользователя выполнено успешно");
            return result;
        }

        public IEnumerable<AspNetUsers> GetAll()
        {
            IEnumerable<AspNetUsers> result;
            try
            {
                result = entities.AspNetUsers;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех пользователей");
                result = null;
            }
            logger.Debug("Получение всех пользователей выполнено успешно");
            return result;
        }

        public AspNetUsers GetById(string id)
        {
            AspNetUsers result;
            try
            {
                result = entities.AspNetUsers.FirstOrDefault(n => n.Id == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения пользователя по id");
                result = null;
            }
            logger.Debug("Получение пользователя по id выполнено успешно");
            return result;
        }

        public AspNetUsers GetByIdWithRoles(string id)
        {
            AspNetUsers result;
            try
            {
                result = entities.
                    AspNetUsers.
                    Include("AspNetRoles").
                    FirstOrDefault(n => n.Id == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения пользователя с ролями по id");
                result = null;
            }
            logger.Debug("Получение пользователя с ролями по id выполнено успешно");
            return result;
        }

        public bool Update(AspNetUsers input)
        {
            bool result;
            try
            {
                AspNetUsers current = entities.AspNetUsers.FirstOrDefault(n => n.Id == input.Id);
                current.Name = input.Name;
                current.Surname = input.Surname;
                current.Email = input.Email;
                current.PhoneNumber = input.PhoneNumber;
                current.PhoneNumberConfirmed = input.PhoneNumberConfirmed;
                current.LockoutEnabled = input.LockoutEnabled;
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка обновления пользователя");
                result = false;
            }
            logger.Debug("Обновление пользователя выполнено успешно");
            return result;
        }
    }
}