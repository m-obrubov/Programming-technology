using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class GoodsDAO : AbstractDAO<Goods, int>
    {
        public GoodsDAO() : base()
        {
        }

        public override bool Create(Goods input)
        {
            entities.Goods.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(Goods input)
        {
            entities.Goods.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<Goods> GetAll() => entities.Goods.Select(n => n);

        public override Goods GetById(int id) => entities.Goods.FirstOrDefault(n => n.Id == id);

        public override bool Update(Goods input)
        {
            Goods current = entities.Goods.FirstOrDefault(n => n.Id == input.Id);
            current.Name = input.Name;
            current.Size = input.Size;
            current.Count = input.Count;
            current.Price = input.Price;
            current.Image = input.Image;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}