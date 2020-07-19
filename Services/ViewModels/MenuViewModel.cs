using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MenuViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string MenuName { get; set; }
        public string Image { get; set; }
        public List<MenuMealCategoryViewModel> MenuMealCategoryViewModels { get; set; }
    }
}
