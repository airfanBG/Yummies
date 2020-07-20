using Data;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CategoryService
    {
        private IServiceConnector ServiceConnector { get; }
        public CategoryService(ServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }
        public async Task Add(MealCategoryViewModel model)
        {

            var res = MapperConfigurator.Mapper.Map<MealCategory>(model);

            await ServiceConnector.MealCategories.Add(res);
            await ServiceConnector.SaveChangesAsync();
        }
        public async Task<ICollection<MenuMealCategory>> GetAll(string id)
        {
           
            var all = await ServiceConnector.Context.Set<MenuMealCategory>().Where(x=>x.MenuId==id).Include(x => x.MealCategory).ThenInclude(x=>x.Meals).ToListAsync();
            var mapped = MapperConfigurator.Mapper.Map<List<MenuMealCategory>>(all);
            return mapped;
        }
        public async Task Remove(string id)
        {
            var menu = await ServiceConnector.MealCategories.Remove(id);
            await ServiceConnector.SaveChangesAsync();
        }

        public async Task Update(MealCategoryViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<MealCategory>(model);
            await ServiceConnector.MealCategories.Update(res);
            await ServiceConnector.SaveChangesAsync();
        }
    }
}
