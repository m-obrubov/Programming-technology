using System;
using System.Linq;
using OnlineShop.Models;
using System.Data.Entity;
using NLog;

namespace OnlineShop.DAO
{
    public class BuyerDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Create(string id)
        {
            bool result;
            try
            {
                Buyer buyer = new Buyer { UserId = id };
                entities.Buyer.Add(buyer);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка добавления товара");
                result = false;
            }
            logger.Debug("Добавление товара выполнено успешно");
            return result;
        }

        public bool Delete(Buyer input)
        {
            bool result;
            try
            {
                entities.Buyer.Remove(input);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления покупателя");
                result = false;
            }
            logger.Debug("Удаление покупателя выполнено успешно");
            return result;
        }

        public Buyer GetById(string id)
        {
            Buyer result;
            try
            {
                result = entities.Buyer.FirstOrDefault(n => n.UserId == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения покупателя по id");
                result = null;
            }
            logger.Debug("Получение покупателя по id выполнено успешно");
            return result;
        }

        public Buyer GetByIdWithDetails(string id)
        {
            Buyer result;
            try
            {
                result = entities.
                    Buyer.
                    Where(n => n.UserId == id).
                    Include("Address").
                    Include("AspNetUsers").
                    Include("Orders").
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения расширенной информации покупателя по id");
                result = null;
            }
            logger.Debug("Получение расширенной информации покупателя по id выполнено успешно");
            return result;
        }
    }
}