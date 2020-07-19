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
        private CategoryService CategoryService { get; }

        [BindProperty]
        public List<MealCategoryViewModel> MealCategoryViewModels { get; set; }
        public CategoriesModel(CategoryService categoryService)
        {
            CategoryService = categoryService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            var res =await CategoryService.GetAll(id);
            MealCategoryViewModels = res.Select(x => new MealCategoryViewModel()
            {
                CategoryName = x.MealCategory.CategoryName,
                Image = x.MealCategory.Image,
                Meals = x.MealCategory.Meals.Select(z =>MapperConfigurator.Mapper.Map<MealViewModel>(z)).ToList()

            }).ToList();
            return Page();
        }
    }
}