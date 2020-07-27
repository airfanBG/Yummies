using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IModel:IBaseEntity<string>,IAuditInfo
    {
        public string MealName { get; set; }
        public decimal Price { get; set; }
        public string TimeForPrepare { get; set; }
    }
}
