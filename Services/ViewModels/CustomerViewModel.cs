using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class CustomerViewModel:IBaseViewModel
    {
        public string UserId { get; set; }
        public UserViewModel User { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; }
        public string ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
    }
}
