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
        public IServiceConnector ServiceConnector { get; }
        public MenuService(IServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }
        public async Task<List<MenuViewModel>> GetMenu()
        {
            var menus = await ServiceConnector.Context.Set<Menu>().Include(x => x.MenuMealCategories).ToListAsync();
            var res= MapperConfigurator.Mapper.Map<List<MenuViewModel>>(menus);
            return res;
        }
        public async Task<List<DrinkCategoryViewModel>> GetDrinkCategories()
        {
            var all = await ServiceConnector.Context.Set<DrinkCategory>().Include(x => x.Category).Include(x => x.Drink).ToListAsync();

            return MapperConfigurator.Mapper.Map<List<DrinkCategoryViewModel>>(all);
        }

    }
}
