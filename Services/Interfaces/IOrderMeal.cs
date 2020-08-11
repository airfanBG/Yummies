using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderMeal:IOrderItemViewModel
    {
        public IMealViewModel Meal { get; set; }
        public List<IMealViewModel> Meals { get; set; }
    }
}
