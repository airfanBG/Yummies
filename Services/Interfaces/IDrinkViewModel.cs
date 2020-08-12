using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IDrinkViewModel:IRestaurantItem
    {
        public List<DrinkCategoryViewModel> DrinkCategoryViewModels { get; set; }
    }
}
