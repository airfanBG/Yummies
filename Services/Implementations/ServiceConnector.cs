using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class ServiceConnector : IServiceConnector
    {
        private readonly Dictionary<Type, object> repositories;
       
        public DbContext Context { get; }
        public ServiceConnector(DbContext applicationDb)
        {
            this.Context = applicationDb;
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
