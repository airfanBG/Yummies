using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
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
    public class MenuService
    {
        private ServiceConnector ServiceConnector { get; }
        public MenuService(ServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }
        public async Task Add(MenuViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Menu>(model);

            await ServiceConnector.Menus.Add(res);
            await ServiceConnector.SaveChangesAsync();
        }
        public async Task<ICollection<MenuViewModel>> GetAll()
        {

            var all = await ServiceConnector.Context.Set<Menu>().Include(x => x.MenuMealCategories).ThenInclude(x => x.MealCategory.Meals).ToListAsync();
            var mapped = MapperConfigurator.Mapper.Map<List<MenuViewModel>>(all);
            return mapped;
        }
        public async Task Remove(string id)
        {

            var menu = await ServiceConnector.Menus.Remove(id);
            
            await ServiceConnector.SaveChangesAsync();
        }

        public async Task Update(MenuViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Menu>(model);
            await ServiceConnector.Menus.Update(res);
            await ServiceConnector.SaveChangesAsync();
        }

    }
}
