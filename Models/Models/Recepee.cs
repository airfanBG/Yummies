using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Recepee:BaseEntity
    {
        public string MealName { get; set; }
        public string Description { get; set; }
        public string TimeForPrepare { get; set; }
        public ICollection<RecepeeIngradients> RecepeeIngradients { get; set; }
    }
}
