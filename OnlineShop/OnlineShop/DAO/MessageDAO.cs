using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class MessageDAO
    {
        private Entities entities = new Entities();

        public bool Create(Message input)
        {
            entities.Message.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(Message input)
        {
            entities.Message.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Message> GetAll() => entities.Message.Select(n => n);

        public Message GetById(int id) => entities.Message.FirstOrDefault(n => n.Id == id);
    }
}