using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MealService
    {
        private ApplicationDbContext Connector { get;}

        public MealService()
        {
           // Connector = new ServiceConnector(new ApplicationDbContext());
        }

        public async Task Add(MealViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Meal>(model);
            Connector.Meals.Add(res);
            await Connector.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
           // Context = new ApplicationDbContext();
            //var meal = await Context.Meals.FirstOrDefaultAsync(x => x.Id == id);
            //Context.Meals.Remove(meal);
            //await Context.SaveChangesAsync();
        }

        public async Task<ICollection<MealViewModel>> GetAll(string id)
        {
           // Context = new ApplicationDbContext();
          
            var models = await Connector.Meals.ToListAsync();

            return MapperConfigurator.Mapper.Map<List<MealViewModel>>(models);
        }

        public async Task Update(MealViewModel model)
        {
           // Context = new ApplicationDbContext();
            var res = MapperConfigurator.Mapper.Map<Meal>(model);

            Connector.Meals.Update(res);
            await Connector.SaveChangesAsync();
        }
    }
}
