using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using NLog;

namespace OnlineShop.DAO
{
    public class GoodsDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Create(Goods input)
        {
            bool result;
            try
            {
                entities.Goods.Add(input);
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

        public bool Delete(Goods input)
        {
            bool result;
            try
            {
                Goods rmGoods = entities.Goods.FirstOrDefault(n => n.Id == input.Id);
                entities.Goods.Remove(rmGoods);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления товара");
                result = false;
            }
            logger.Debug("Удаление товара выполнено успешно");
            return result;
        }

        public IEnumerable<Goods> GetAll()
        {
            IEnumerable<Goods> result;
            try
            {
                result = entities.Goods;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех товаров");
                result = null;
            }
            logger.Debug("Получение всех товаров выполнено успешно");
            return result;
        }

        public Goods GetById(int id)
        {
            Goods result;
            try
            {
                result = entities.Goods.FirstOrDefault(n => n.Id == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения товара по id");
                result = null;
            }
            logger.Debug("Получение товара по id выполнено успешно");
            return result;
        }

        public bool Update(Goods input)
        {
            bool result;
            try
            {
                Goods current = entities.Goods.FirstOrDefault(n => n.Id == input.Id);
                current.Name = input.Name;
                current.Price = input.Price;
                current.Image = input.Image;
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка обновления товара");
                result = false;
            }
            logger.Debug("Обновление товара выполнено успешно");
            return result;
        }
    }
}