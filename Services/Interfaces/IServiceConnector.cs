using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IServiceConnector
    {
        public IBaseService<OrderService> OrderService { get;}
        public IBaseService<MenuService> MenuService { get; }
        public IBaseService<MealService> MealService { get; }
        public IBaseService<CustomerService> CustomerService { get; }
    }
}
