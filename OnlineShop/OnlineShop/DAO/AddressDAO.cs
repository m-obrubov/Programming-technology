using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using NLog;

namespace OnlineShop.DAO
{
    public class AddressDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Create(Address input)
        {
            bool result;
            try
            {
                entities.Address.Add(input);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка добавления адреса");
                result = false;
            }
            logger.Debug("Добавление адреса выполнено успешно");
            return result;
        }

        public bool Delete(Address input)
        {
            bool result;
            try
            {
                entities.Address.Remove(input);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления адреса");
                result = false;
            }
            logger.Debug("Удаление адреса выполнено успешно");
            return result;
        }

        public IEnumerable<Address> GetAll()
        {
            IEnumerable<Address> result;
            try
            {
                result = entities.Address;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех адресов");
                result = null;
            }
            logger.Debug("Получение всех адресов выполнено успешно");
            return result;
        }


        public Address GetById(string id)
        {
            Address result;
            try
            {
                result = entities.Address.FirstOrDefault(n => n.UserId == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения адреса по id");
                result = null;
            }
            logger.Debug("Получение адреса по id выполнено успешно");
            return result;
        }

        public bool Update(Address input)
        {
            bool result;
            try
            {
                Address current = entities.Address.FirstOrDefault(n => n.UserId == input.UserId);
                current.Postcode = input.Postcode;
                current.Country = input.Country;
                current.Region = input.Region;
                current.City = input.City;
                current.Street = input.Street;
                current.House = input.House;
                current.Flat = input.Flat;
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка обновления адреса");
                result = false;
            }
            logger.Debug("Обновление адреса выполнено успешно");
            return result;
        }
    }
}