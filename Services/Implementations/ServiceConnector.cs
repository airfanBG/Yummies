using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class ServiceConnector : IServiceConnector
    {
        private readonly Dictionary<Type, object> repositories;
        private DbContext context;
        public DbContext Context { get { return this.context; } }
        public ServiceConnector(DbContext applicationDb)
        {
            this.context = applicationDb;
            repositories = new Dictionary<Type, object>();
        }
        public IBaseService<OrderService> OrderService
        {
            get
            {
                return GetRepository<OrderService>();
            }
        }

        public IBaseService<MenuService> MenuService
        {
            get
            {
                return GetRepository<MenuService>();
            }
        }

        public IBaseService<MealService> MealService
        {
            get
            {
                return GetRepository<MealService>();
            }
        }

        public IBaseService<CustomerService> CustomerService
        {
            get
            {
                return GetRepository<CustomerService>();
            }
        }

        private BaseService<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(BaseService<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (BaseService<T>)this.repositories[typeof(T)];
        }
    }
}
