using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Implementations;
using Services.Mapping;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class MealsModel : PageModel
    {
        private ServiceConnector ServiceConnector { get; }
        [BindProperty]
        public ICollection<MealViewModel> MealViewModels { get; set; }
        public MealsModel(ServiceConnector mealService)
        {
            ServiceConnector = mealService;
        }
        public async Task OnGet(string categoryId)
        {
            var res =await ServiceConnector.Meals.GetAll(x=>x.MealCategoryId== categoryId);
            MealViewModels = MapperConfigurator.Mapper.Map<List<MealViewModel>>(res);
        }
    }
}