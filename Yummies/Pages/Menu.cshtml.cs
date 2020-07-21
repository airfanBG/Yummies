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
using Services.Mapping;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class MenuModel : PageModel
    {
        private ServiceConnector ServiceConnector { get; }

        [BindProperty]
        public ICollection<MenuViewModel> Menus { get; set; }


        public MenuModel(ServiceConnector service)
        {
            ServiceConnector = service;
        }
        public async Task OnGet()
        {
            Menus = MapperConfigurator.Mapper.Map<List<MenuViewModel>>(await ServiceConnector.Menus.GetAll());
        }

    }
}