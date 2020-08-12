using Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICustomerViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public IUserViewModel User { get; set; }
        public ICollection<IOrderViewModel> Orders { get; set; }
        public string ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
    }
}
