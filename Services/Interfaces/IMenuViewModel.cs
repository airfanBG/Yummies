using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IMenuViewModel:IBaseViewModel
    {
        public string MenuName { get; set; }
        public string Image { get; set; }
        public List<MenuMealCategoryViewModel> MenuMealCategoryViewModels { get; set; }
    }
}
