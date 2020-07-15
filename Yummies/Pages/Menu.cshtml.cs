using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Interfaces;
using Models.Models;
using Services.Implementations;

namespace Yummies.Pages
{
    public class MenuModel : PageModel
    {
        private MenuService MenuService { get; }

        [BindProperty]
        public ICollection<BaseEntity> Menus { get; set; }
        public MenuModel(MenuService menuService)
        {
            MenuService = menuService;
        }
        public async Task OnGet()
        {
            Menus = await MenuService.GetAll();
        }
    }
}