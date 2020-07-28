using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.IdentityModels;
using Services.Implementations;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceConnector
    {
        DbContext Context { get; }
        public IBaseService<Order> Orders { get;}
        public IBaseService<Menu> Menus { get; }
        public IBaseService<Meal> Meals { get; }
        public IBaseService<Customer> Customers { get; }
        public IBaseService<MealCategory> MealCategories { get; }
        public IBaseService<MenuMealCategory> MenuMealCategories { get; }
        public IBaseService<OrderMeals> OrderMeals { get; }
        public IBaseService<User> Users { get; }
        public IBaseService<MealRate> MealRates { get; }
        void Dispose();

        Task<int> SaveChangesAsync();
    }
}
