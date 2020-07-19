using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Interfaces;
using Models.Models;
using Services.Implementations;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class MenuModel : PageModel
    {
        private MenuService MenuService { get; }

        [BindProperty]
        public ICollection<MenuViewModel> Menus { get; set; }


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