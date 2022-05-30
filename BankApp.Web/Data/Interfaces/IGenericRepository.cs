using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Web.Data.Interfaces
{
    public interface IGenericRepository<T>
        where T : class, new()
    {
        public void Create(T entity);
        public void Remove(T entity);
        public void Update(T entity);
        public List<T> GetAll();
        public T GetById(object id);
    }
}
