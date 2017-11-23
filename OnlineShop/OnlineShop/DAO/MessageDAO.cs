using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class MessageDAO : AbstractDAO<Message, int>
    {
        public MessageDAO() : base()
        {
        }

        public override bool Create(Message input)
        {
            entities.Message.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(Message input)
        {
            entities.Message.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<Message> GetAll() => entities.Message.Select(n => n);

        public override Message GetById(int id) => entities.Message.FirstOrDefault(n => n.Id == id);

        public override bool Update(Message input) => false;
    }
}