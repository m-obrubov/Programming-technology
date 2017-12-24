using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class GoodsDAO
    {
        private Entities entities = new Entities();

        public bool Create(Goods input)
        {
            entities.Goods.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(Goods input)
        {
            entities.Goods.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Goods> GetAll() => entities.Goods;

        public Goods GetById(int id) => entities.Goods.FirstOrDefault(n => n.Id == id);

        public bool Update(Goods input)
        {
            Goods current = entities.Goods.FirstOrDefault(n => n.Id == input.Id);
            current.Name = input.Name;
            current.Price = input.Price;
            current.Image = input.Image;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}