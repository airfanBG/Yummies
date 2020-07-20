using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBaseService<T> where T:class
    {
        Task<int> Add(T model);
        Task<int> Remove(string id);
        Task<List<T>> GetAll(Func<T,bool> func=null);
        Task<int> Update(T model);
        public Task<int> SaveChanges();
    }
}
