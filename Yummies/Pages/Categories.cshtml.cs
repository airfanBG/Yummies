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

            var res =await CategoryService.GetMenuCategories(id);

            MealCategoryViewModels=res.Select(x => new MealCategoryViewModel()
            {
               CategoryName=x.MealCategoryViewModel.CategoryName,
               Image=x.MealCategoryViewModel.Image,
               MealCategoryId=x.MealCategoryId,
               Meals=x.MealCategoryViewModel.Meals
            }).ToList();
            
            return Page();
        }

    }
}