﻿using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class CustomerViewModel:ICustomerViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public IUserViewModel User { get; set; }
        public ICollection<IOrderViewModel> Orders { get; set; }
        public string ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
        
    }
}
