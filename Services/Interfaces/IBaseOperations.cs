using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBaseOperations
    {
        Task Add(IModel model);
        Task Remove(string id);
        Task<ICollection<IModel>> GetAll();
        Task Update(IModel model);
    }
}
