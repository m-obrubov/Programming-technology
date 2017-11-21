using System.Collections.Generic;
using OnlineShop.Models;

namespace OnlineShop.DAO
{
    public abstract class AbstractDAO <T, K>
    {
        protected Entities entities;

        public AbstractDAO()
        {
            entities = new Entities();
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(K id);
        public abstract bool Create(T input);
        public abstract bool Update(T input);
        public abstract bool Delete(T input);
    }
}