using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBaseService
    {
        Task Add(BaseEntity model);
        Task Remove(string id);
        Task<ICollection<BaseEntity>> GetAll();
        Task Update(BaseEntity model);
    }
}
