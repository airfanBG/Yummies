﻿using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class OrderDataViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string MealId { get; set; }
        public string DrinkId { get; set; }
        public string Comment { get; set; }
        public bool isMeal { get; set; }
    }
}
