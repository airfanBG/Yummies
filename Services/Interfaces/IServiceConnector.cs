using Models.Models;
using Services.Implementations;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IServiceConnector
    {
        public IBaseService<Order> Orders { get;}
        public IBaseService<Menu> Menus { get; }
        public IBaseService<Meal> Meals { get; }
        public IBaseService<Customer> Customers { get; }
    }
}
