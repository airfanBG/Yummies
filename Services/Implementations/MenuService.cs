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
        private ApplicationDbContext Context { get; }
        public MenuService(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task Add(MenuViewModel model)
        {
            
            var res = MapperConfigurator.Mapper.Map<Menu>(model);

            Context.Menus.Add(res);
            await Context.SaveChangesAsync();
        }
        public async Task<ICollection<MenuViewModel>> GetAll()
        {
          
            var all = await Context.Menus.Include(x => x.MenuMealCategories).ThenInclude(x => x.MealCategory.Meals).ToListAsync();
            var mapped = MapperConfigurator.Mapper.Map<List<MenuViewModel>>(all);
            return mapped;
        }
        public async Task Remove(string id)
        {
           
            var menu = await Context.Menus.FirstOrDefaultAsync(x => x.Id == id);
            Context.Menus.Remove(menu);
            await Context.SaveChangesAsync();
        }

        public async Task Update(MenuViewModel model)
        {
           
            var res = MapperConfigurator.Mapper.Map<Menu>(model);

            Context.Menus.Update(res);
            await Context.SaveChangesAsync();
        }

    }
}
