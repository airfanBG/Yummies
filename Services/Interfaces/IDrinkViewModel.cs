using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IDrinkViewModel:IRestaurantItem
    {
        public ICollection<ICategoryViewModel> DrinkCategoryViewModels { get; set; }
    }
}
