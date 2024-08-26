using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGeneric<T> where T : class
    {
        bool Insert(T item);
        bool Delete(T item);
        void Update(T item);
        List<T> GetAll();
        T GetById(int id);
    }
}
