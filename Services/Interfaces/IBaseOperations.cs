using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IBaseOperations
    {
        void Add(IModel model);
        void Remove(string id);
        ICollection<IModel> GetAll();
        void Update(IModel model);
    }
}
