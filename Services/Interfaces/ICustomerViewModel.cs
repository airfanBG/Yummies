using Models.Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICustomerViewModel:IBaseViewModel
    {
        public string UserId { get; set; }
        public UserViewModel User { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public string ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
    }
}
