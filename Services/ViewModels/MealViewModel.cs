using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MealViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string MealName { get; set; }
        public decimal Price { get; set; }
        public string TimeForPrepare { get; set; }
        public string Image { get; set; }
        public string MealDescription { get; set; }
        public string MealCategoryId { get; set; }
        public RecepeeViewModel Recepee { get; set; }
    }
}
