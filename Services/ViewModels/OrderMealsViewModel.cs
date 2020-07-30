using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class OrderMealsViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
       
        public string MealId { get; set; }
        public MealViewModel Meal { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public Statuses Statuses { get; set; }
    }
}
