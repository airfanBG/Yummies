using Microsoft.EntityFrameworkCore;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class IndexService
    {
        private IServiceConnector ServiceConnector { get; }

        public IndexService(IServiceConnector serviceConnector)
        {
            this.ServiceConnector = serviceConnector;
        }
        public async Task<List<MealViewModel>> MostOrderedMealsAsync()
        {
            var top =await ServiceConnector.Context.Set<OrderMeals>()
                .GroupBy(x => x.MealId)
                .Select(x => new { MealId = x.Key, Total = x.Sum(z => z.Quantity) })
                .OrderByDescending(x=>x.Total)
                .Take(5)
                .ToListAsync();

            var ids = top.Select(x => x.MealId).ToList();
            
            var res =await ServiceConnector.Context.Set<Meal>().Where(x => ids.Contains(x.Id)).ToListAsync();
            return MapperConfigurator.Mapper.Map<List<MealViewModel>>(res);
        }

    }
}
 