using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        Context context = new Context();

        public bool Delete(T item)
        {
            context.Remove(item);
            context.SaveChanges();
            return true;
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public bool Insert(T item)
        {
            context.Add(item);
            context.SaveChanges();
            return true;
        }

        public void Update(T item)
        {
            context.Update(item);
            context.SaveChanges();
        }
    }
}
