using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IMealViewModel:IRestaurantItem
    {
        public string TimeForPrepare { get; set; }
        public string MealCategoryId { get; set; }
        public RecepeeViewModel Recepee { get; set; }
    }
}
