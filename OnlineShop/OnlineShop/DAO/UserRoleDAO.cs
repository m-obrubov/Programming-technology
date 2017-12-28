using NLog;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.DAO
{
    public class UserRoleDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public IEnumerable<AspNetRoles> GetAllForUser(string id)
        {
            IEnumerable<AspNetRoles> result;
            try
            {
                result = entities.
                    AspNetUsers.
                    Include("AspNetRoles").
                    Where(n => n.Id == id).
                    Select(n => n.AspNetRoles).
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех ролей для пользователя по id");
                result = null;
            }
            logger.Debug("Получение всех ролей для пользователя по id выполнено успешно");
            return result;
        }

        public IEnumerable<AspNetRoles> GetAll()
        {
            IEnumerable<AspNetRoles> result;
            try
            {
                result = entities.AspNetRoles;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех ролей");
                result = null;
            }
            logger.Debug("Получение всех ролей выполнено успешно");
            return result;
        }

        public AspNetRoles GetByName(string name)
        {
            AspNetRoles result;
            try
            {
                result = entities.AspNetRoles.FirstOrDefault(n => n.Name == name);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения роли по имени");
                result = null;
            }
            logger.Debug("Получение роли по имени выполнено успешно");
            return result;
        }

        public AspNetRoles GetById(string id)
        {
            AspNetRoles result;
            try
            {
                result = entities.AspNetRoles.FirstOrDefault(n => n.Id == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения роли по id");
                result = null;
            }
            logger.Debug("Получение роли по id выполнено успешно");
            return result;
        }

        public bool AddRole(string userId, AspNetRoles role)
        {
            bool result;
            try
            {
                AspNetUsers changedUser = entities.AspNetUsers.FirstOrDefault(n => n.Id == userId);
                changedUser.AspNetRoles.Add(role);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка добавления роли пользователю");
                result = false;
            }
            logger.Debug("Добавление роли пользователю выполнено успешно");
            return result;
        }

        public bool RemoveRole(string userId, AspNetRoles role)
        {
            bool result;
            try
            {
                AspNetUsers changedUser = entities.AspNetUsers.FirstOrDefault(n => n.Id == userId);
                AspNetRoles rmRole = entities.AspNetRoles.FirstOrDefault(n => n.Name == role.Name);
                changedUser.AspNetRoles.Remove(rmRole);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления роли у пользователя");
                result = false;
            }
            logger.Debug("Удаление роли у пользователя выполнено успешно");
            return result;
        }
    }
}