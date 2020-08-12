using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderMeal:IOrderItemViewModel
    {
        public string MealId { get; set; }
        public IMealViewModel Meal { get; set; }
        public List<IMealViewModel> Meals { get; set; }
        public Statuses Statuses { get; set; }
    }
}
