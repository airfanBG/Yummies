using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    internal class BaseService<T> : IBaseService<T> where T : class
    {
        private DbContext DbContext { get; }
        private DbSet<T> Set { get; }
        public BaseService(DbContext context)
        {
            this.DbContext = context ?? throw new ArgumentException("An instance of context is null");

            Set = this.DbContext.Set<T>();
        }
        public async Task<int> Add(T model)
        {
            try
            {
                EntityEntry entry = DbContext.Entry<T>(model);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Added;
                }
                else
                {
                    await this.DbContext.AddAsync(model);
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<T>> GetAll(Func<T, bool> func = null)
        {
            if (func==null)
            {
                Task<List<T>> result = new Task<List<T>>(() => Set.ToList());
                result.Start();
                return await result;
            }
            Task<List<T>> task = new Task<List<T>>(() => Set.Where(func).ToList());
            task.Start();
            return await task;
        }

        public async Task<int> Remove(string id)
        {
            try
            {
                var entry =await Set.FindAsync(id);
                if (entry!=null)
                {
                    Set.Remove(entry);
                    var res=await this.SaveChanges();
                    return res;
                }
                return 0;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<int> Update(T model)
        {
            try
            {
                EntityEntry entry = DbContext.Entry<T>(model);
                if (entry.State==EntityState.Detached)
                {
                    Set.Attach(model);
                }
                entry.State = EntityState.Modified;
                return await Task.Run(()=>1);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<T> FindById(string id)
        {
            try
            {
                var res =await DbContext.Set<T>().FindAsync(id);
                if (res!=null)
                {
                    return res;
                }
                return null;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<int> SaveChanges()
        {
            return await DbContext.SaveChangesAsync();
        }

      
    }
}
