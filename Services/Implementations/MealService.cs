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
        private ServiceConnector ServiceConnector { get;}

        public MealService(ServiceConnector serviceConnector)
        {
            this.ServiceConnector = serviceConnector;
        }

        public async Task Add(MealViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Meal>(model);
            await ServiceConnector.Meals.Add(res);
            await ServiceConnector.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            await this.ServiceConnector.Meals.Remove(id);
            await ServiceConnector.SaveChangesAsync();
        }

        public async Task<ICollection<MealViewModel>> GetAll(string id)
        {
            var models = await ServiceConnector.Meals.GetAll();

            return MapperConfigurator.Mapper.Map<List<MealViewModel>>(models);
        }

        public async Task Update(MealViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Meal>(model);

            await ServiceConnector.Meals.Update(res);
            await ServiceConnector.SaveChangesAsync();
        }
    }
}
