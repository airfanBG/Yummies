using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MealService: IBaseService
    {
        private ApplicationDbContext Context { get; set; }


        public async Task Add(BaseEntity model)
        {
            Context = new ApplicationDbContext();
            Context.Meals.Add((Meal)model);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            Context = new ApplicationDbContext();
            var meal = await Context.Meals.FirstOrDefaultAsync(x => x.Id == id);
            Context.Meals.Remove(meal);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<BaseEntity>> GetAll()
        {
            Context = new ApplicationDbContext();
            return await Context.Meals.ToListAsync<BaseEntity>();
        }

        public async Task Update(BaseEntity model)
        {
            Context = new ApplicationDbContext();
            Context.Meals.Update((Meal)model);
            await Context.SaveChangesAsync();
        }
    }
}
