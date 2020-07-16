using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MealCategoryViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public ICollection<MealViewModel> Meals { get; set; }
    }
}
