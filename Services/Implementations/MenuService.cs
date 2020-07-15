using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MenuService:IBaseService
    {
        private ApplicationDbContext Context { get; set; }


        public async Task Add(BaseEntity model)
        {
            Context = new ApplicationDbContext();
            Context.Menus.Add((Menu)model);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            Context = new ApplicationDbContext();
            var menu= await Context.Menus.FirstOrDefaultAsync(x => x.Id == id);
            Context.Menus.Remove(menu);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<BaseEntity>> GetAll()
        {
            Context = new ApplicationDbContext();
            return await Context.Menus.Include(x=>x.MenuMealCategories).ThenInclude(x=>x.MealCategory.Meals).ToListAsync<BaseEntity>();
        }

        public async Task Update(BaseEntity model)
        {
            Context = new ApplicationDbContext();
            Context.Menus.Update((Menu)model);
            await Context.SaveChangesAsync();
        }
    }
}
