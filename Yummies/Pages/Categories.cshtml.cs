using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Services.Implementations;
using Services.Mapping;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class CategoriesModel : PageModel
    {
        private ServiceConnector ServiceConnector { get; }

        [BindProperty]
        public List<MealCategoryViewModel> MealCategoryViewModels { get; set; }
        public CategoriesModel(ServiceConnector categoryService)
        {
            ServiceConnector = categoryService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            var res =await ServiceConnector.MealCategories.GetAll(x=>x.Id==id);
            
            MealCategoryViewModels = res.Select(x => new MealCategoryViewModel()
            {
                Id=x.Id,
                MealCategoryId=x.Id,
                CategoryName = x.CategoryName,
                Image = x.Image,
                Meals = x.Meals.Select(z =>MapperConfigurator.Mapper.Map<MealViewModel>(z)).ToList()
                
            }).ToList();
            return Page();
        }

    }
}