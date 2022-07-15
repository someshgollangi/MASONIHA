using ShoppingCore.BaseInterfaces;
using ShoppingCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryImplementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Context cd;
        private DbSet<T> dbset;
        public Repository()
        {
            cd = new Context();
            dbset = cd.Set<T>();
        }
       
        public IEnumerable<T> Get()
        {
            return dbset.ToList();
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public T Insert(T obj)
        {
            dbset.Add(obj);
            Save();
            return obj;

        }
        public T Update(T obj)
        {
            dbset.Attach(obj);
            cd.Entry(obj).State = EntityState.Modified;
            Save();
            return (obj);

        }
        public T DeleteItem(int id)
        {
            if (dbset.Find(id) != null)
            {
                dbset.Remove(dbset.Find(id));
                Save();
                return (dbset.Find(id));
            }
            return (dbset.Find(id));
        }


        public void Save()
        {
            try
            {
                cd.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }

                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (cd != null)
                {
                    cd.Dispose();
                    cd = null;
                }
            }
        }

       
    }
}
