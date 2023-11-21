using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H0AGKU_HFT_2023241.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();      
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        T Read(int id);
    }
}
