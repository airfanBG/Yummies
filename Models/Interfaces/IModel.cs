﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IModel:IBaseEntity,IAuditInfo
    {
        public string MealName { get; set; }
        public double Price { get; set; }
        public string TimeForPrepare { get; set; }
    }
}
