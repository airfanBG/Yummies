using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IBaseEntity<T> where T:class
    {
        public T Id { get; set; }
    }
}
