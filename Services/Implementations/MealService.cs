using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MealService
    {
        private ApplicationDbContext Context { get;}

        public MealService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task Add(MealViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Meal>(model);
            Context.Meals.Add(res);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
           // Context = new ApplicationDbContext();
            var meal = await Context.Meals.FirstOrDefaultAsync(x => x.Id == id);
            Context.Meals.Remove(meal);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<MealViewModel>> GetAll()
        {
           // Context = new ApplicationDbContext();
            var models = await Context.Meals.ToListAsync();

            return MapperConfigurator.Mapper.Map<List<MealViewModel>>(models);
        }

        public async Task Update(MealViewModel model)
        {
           // Context = new ApplicationDbContext();
            var res = MapperConfigurator.Mapper.Map<Meal>(model);

            Context.Meals.Update(res);
            await Context.SaveChangesAsync();
        }
    }
}
