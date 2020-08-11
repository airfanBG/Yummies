using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MealViewModel:IMealViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string TimeForPrepare { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string MealCategoryId { get; set; }
        public RecepeeViewModel Recepee { get; set; }
    }
}
