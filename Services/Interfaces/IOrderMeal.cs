using Models.Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderMeal:IOrderItemViewModel
    {
        public string MealId { get; set; }
        public MealViewModel Meal { get; set; }
        public List<MealViewModel> Meals { get; set; }
        public Statuses Statuses { get; set; }
    }
}
