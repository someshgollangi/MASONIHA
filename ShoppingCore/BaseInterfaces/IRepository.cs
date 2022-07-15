using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCore.BaseInterfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> Get();
        T GetById(int id);
        T Insert(T obj);
        T Update(T obj);
        T DeleteItem(int id);
        void Save();

    }
}
