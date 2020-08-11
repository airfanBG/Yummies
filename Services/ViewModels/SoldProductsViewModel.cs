﻿using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class SoldProductsViewModel:IInfrastructureViewModels
    {
        public string Id { get; set; }
        public List<IOrderItemViewModel> OrderMealsViews { get; set; }
        public List<IOrderItemViewModel> OrderDrinksViewModels { get; set; }
        
    }
    
}
