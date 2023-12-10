using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        public IceHockeyDbContext Context; 
        public Repository(IceHockeyDbContext Context)
        {
            this.Context = Context;
        }
        public void Create(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return Context.Set<T>();
        }
        public void Delete(int id)
        {
            Context.Set<T>().Remove(Read(id));
            Context.SaveChanges();
        }
        public abstract T Read(int id);
        public abstract void Update(T item);


    }
}
