using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using NLog;

namespace OnlineShop.DAO
{
    public class MessageDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public bool Create(Message input)
        {
            bool result;
            try
            {
                entities.Message.Add(input);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка добавления сообщения");
                result = false;
            }
            logger.Debug("Добавление сообщения выполнено успешно");
            return result;
        }

        public bool Delete(Message input)
        {
            bool result;
            try
            {
                entities.Message.Remove(input);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления сообщения");
                result = false;
            }
            logger.Debug("Удаление сообщения выполнено успешно");
            return result;
        }

        public IEnumerable<Message> GetAll()
        {
            IEnumerable<Message> result;
            try
            {
                result = entities.Message;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех сообщений");
                result = null;
            }
            logger.Debug("Получение всех сообщений выполнено успешно");
            return result;
        }

        public Message GetById(int id)
        {
            Message result;
            try
            {
                result = entities.Message.FirstOrDefault(n => n.Id == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения сообщения по id");
                result = null;
            }
            logger.Debug("Получение сообщения по id выполнено успешно");
            return result;
        }
    }
}