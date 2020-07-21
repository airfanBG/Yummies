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
        public IServiceConnector ServiceConnector { get; }
        public CategoryService(IServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }
        public async Task<List<MenuMealCategoryViewModel>> GetCategories(string menuId)
        {
            var res =await ServiceConnector.Context.Set<MenuMealCategory>().Include(x => x.MealCategory).Where(x => x.MenuId == menuId).ToListAsync();
            return MapperConfigurator.Mapper.Map<List<MenuMealCategoryViewModel>>(res);
           
        }
    }
}
