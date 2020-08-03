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
    public class DrinkCategoriesModel : PageModel
    {
        private CategoryService CategoryService { get; }

        [BindProperty]
        public List<DrinkCategoryViewModel> DrinkCategoryViewModels { get; set; }
        public DrinkCategoriesModel(CategoryService categoryService)
        {
            CategoryService = categoryService;
        }
        public async Task<IActionResult> OnGet(string id)
        {

            var res = await CategoryService.GetDrinkCategories(id);

            DrinkCategoryViewModels = MapperConfigurator.Mapper.Map<List<DrinkCategoryViewModel>>(res);

            return Page();
        }

    }
}