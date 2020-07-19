using Data;
using Microsoft.EntityFrameworkCore;
using Models.Models;
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
        private ApplicationDbContext Context { get; }
        public CategoryService(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task Add(MealCategoryViewModel model)
        {

            var res = MapperConfigurator.Mapper.Map<MealCategory>(model);

            Context.MealCategories.Add(res);
            await Context.SaveChangesAsync();
        }
        public async Task<ICollection<MenuMealCategory>> GetAll(string id)
        {
         
            var all = await Context.MenuMealCategories.Where(x => x.MenuId == id).Include(x => x.MealCategory).ThenInclude(x=>x.Meals).ToListAsync();
            var mapped = MapperConfigurator.Mapper.Map<List<MenuMealCategory>>(all);
            return mapped;
        }
        public async Task Remove(string id)
        {

            var menu = await Context.MealCategories.FirstOrDefaultAsync(x => x.Id == id);
            Context.MealCategories.Remove(menu);
            await Context.SaveChangesAsync();
        }

        public async Task Update(MealCategoryViewModel model)
        {

            var res = MapperConfigurator.Mapper.Map<MealCategory>(model);

            Context.MealCategories.Update(res);
            await Context.SaveChangesAsync();
        }
    }
}
