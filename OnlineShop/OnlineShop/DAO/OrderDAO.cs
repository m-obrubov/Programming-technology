using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;
using System.Data.Entity;
using NLog;

namespace OnlineShop.DAO
{
    public class OrderDAO
    {
        private Entities entities = new Entities();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Order Create(Order order)
        {
            Order result;
            try
            {
                result = entities.Order.Add(order);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка добавления заказа");
                result = null;
            }
            logger.Debug("Добавление заказа выполнено успешно");
            return result;
        }

        public bool AddGoodsToOrder(Order order, List<Goods> goodsInOrder)
        {
            bool result;
            try
            {
                foreach (Goods goods in goodsInOrder)
                {
                    ShoppingCart item = new ShoppingCart { OrderId = order.Id, GoodsId = goods.Id };
                    entities.ShoppingCart.Add(item);
                }
                result = entities.SaveChanges() == goodsInOrder.Count;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка добавления товара в заказ");
                result = false;
            }
            logger.Debug("Добавление товара в заказ выполнено успешно");
            return result;
        }

        public bool Delete(Order input)
        {
            bool result;
            try
            {
                Order current = GetById(input.Id);
                entities.Order.Remove(current);
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления заказа");
                result = false;
            }
            logger.Debug("Удаление заказа выполнено успешно");
            return result;
        }

        public bool DeleteGoodsFromOrder(Order order)
        {
            bool result;
            try
            {
                List<ShoppingCart> cart = entities.ShoppingCart.Where(n => n.OrderId == order.Id).ToList();
                foreach (var item in cart)
                {
                    entities.ShoppingCart.Remove(item);
                }
                result = entities.SaveChanges() == cart.Count;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка удаления товара из заказа");
                result = false;
            }
            logger.Debug("Удаление товара из заказа выполнено успешно");
            return result;
        }

        public IEnumerable<Order> GetAll()
        {
            IEnumerable<Order> result;
            try
            {
                result = entities.Order;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех заказов");
                result = null;
            }
            logger.Debug("Получение всех заказов выполнено успешно");
            return result;
        }

        public IEnumerable<Order> GetAllForUserWithDetails(string id)
        {
            IEnumerable<Order> result;
            try
            {
                result = entities.
                    Order.
                    Where(n => n.BuyerId == id).
                    Include("Employee.AspNetUsers").
                    Include("Address").
                    Include("ShoppingCart");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения всех заказов с расширенной информацией для пользователя по id");
                result = null;
            }
            logger.Debug("Получение всех заказов с расширенной информацией для пользователя по id выполнено успешно");
            return result;
        }

        public Order GetById(int id)
        {
            Order result;
            try
            {
                result = entities.Order.FirstOrDefault(n => n.Id == id);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения заказа по id");
                result = null;
            }
            logger.Debug("Получение заказа по id выполнено успешно");
            return result;
        }

        public Order GetByIdWithDetails(int id)
        {
            Order result;
            try
            {
                result = entities.
                    Order.
                    Where(n => n.Id == id).
                    Include("Buyer.AspNetUsers").
                    Include("Employee.AspNetUsers").
                    Include("Address").
                    Include("ShoppingCart").
                    FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка получения заказа с расширенной информацией по id");
                result = null;
            }
            logger.Debug("Получение заказа с расширенной информацией по id выполнено успешно");
            return result;
        }

        public bool UpdateManager(int id, string managerId)
        {
            bool result;
            try
            {
                Order current = entities.Order.FirstOrDefault(n => n.Id == id);
                current.ManagerId = managerId;
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка обновления менеджера у заказа");
                result = false;
            }
            logger.Debug("Обновление менеджера у заказа выполнено успешно");
            return result;
        }

        public bool UpdateIsPayed(int id, bool value)
        {
            bool result;
            try
            {
                Order current = entities.Order.FirstOrDefault(n => n.Id == id);
                current.IsPayed = value;
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка обновления поля IsPayed у заказа");
                result = false;
            }
            logger.Debug("Обновление поля IsPayed у заказа выполнено успешно");
            return result;
        }

        public bool UpdateStatus(int id, OrderStatus status)
        {
            bool result;
            try
            {
                Order current = entities.Order.FirstOrDefault(n => n.Id == id);
                current.Status = (short)status;
                result = entities.SaveChanges() == 1;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка обновления статуса заказа");
                result = false;
            }
            logger.Debug("Обновление статуса заказа выполнено успешно");
            return result;
        }
    }
}