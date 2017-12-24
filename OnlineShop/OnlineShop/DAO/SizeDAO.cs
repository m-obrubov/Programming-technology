using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class SizeDAO
    {
        private Entities entities = new Entities();

        public bool Create(Size input)
        {
            entities.Size.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public bool Delete(Size input)
        {
            entities.Size.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public IEnumerable<Size> GetAll() => entities.Size.Select(n => n);

        public Size GetById(int id) => entities.Size.FirstOrDefault(n => n.Id == id);

        public bool UpdateCount(string sizeName, int deltaCount)
        {
            Size current = entities.Size.FirstOrDefault(n => n.SizeName.Equals(sizeName));
            current.Count += deltaCount;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}