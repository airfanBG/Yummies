﻿using Services.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.ViewModels
{
    public class OrderViewModel:IOrderViewModel
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public ICustomerViewModel Customer { get; set; }
        public ICollection<IOrderMeal> OrderedMeals { get; set; }
        public ICollection<IOrderDrink> OrderDrinks { get; set; }
        public bool HasPaid { get; set; } = false;
        [MaxLength(200)]
        public string OrderComment { get; set; }
    }
}