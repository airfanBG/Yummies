﻿using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ServiceConnector : IServiceConnector
    {
        private ApplicationDbContext context;
        public DbContext Context { get { return this.context; } }
        private readonly Dictionary<Type, object> repositories;
       
        public ServiceConnector(ApplicationDbContext applicationDb)
        {
            this.context = applicationDb;
            repositories = new Dictionary<Type, object>();
        }
        public IBaseService<Order> Orders
        {
            get
            {
                return GetRepository<Order>();
            }
        }

        public IBaseService<Menu> Menus
        {
            get
            {
                return GetRepository<Menu>();
            }
        }

        public IBaseService<Meal> Meals
        {
            get
            {
                return GetRepository<Meal>();
            }
        }

        public IBaseService<Customer> Customers
        {
            get
            {
                return GetRepository<Customer>();
            }
        }

        public IBaseService<MealCategory> MealCategories
        {
            get
            {
                return GetRepository<MealCategory>();
            }
        }

        public IBaseService<MenuMealCategory> MenuMealCategories
        {
            get
            {
                return GetRepository<MenuMealCategory>();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }
        private BaseService<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(BaseService<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (BaseService<T>)this.repositories[typeof(T)];
        }
    }
}
