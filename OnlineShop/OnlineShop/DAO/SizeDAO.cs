using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public class SizeDAO : AbstractDAO<Size, int>
    {
        public SizeDAO() : base()
        {
        }

        public override bool Create(Size input)
        {
            entities.Size.Add(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override bool Delete(Size input)
        {
            entities.Size.Remove(input);
            return entities.SaveChanges() == 1 ? true : false;
        }

        public override IEnumerable<Size> GetAll() => entities.Size.Select(n => n);

        public override Size GetById(int id) => entities.Size.FirstOrDefault(n => n.Id == id);

        public override bool Update(Size input) => false;

        public bool UpdateCount(string sizeName, int deltaCount)
        {
            Size current = entities.Size.FirstOrDefault(n => n.SizeName.Equals(sizeName));
            current.Count += deltaCount;
            return entities.SaveChanges() == 1 ? true : false;
        }
    }
}