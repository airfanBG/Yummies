using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Models.Models;
using Services.Common;
using Services.Implementations;
using Services.Interfaces;
using Services.ViewModels;

namespace Yummies.Areas.Admin.Pages
{
    public class AddModel : PageModel
    {
        
        private readonly IServiceConnector serviceConnector;
        private readonly FilesManager filesManager;
        private readonly IWebHostEnvironment hostEnvironment;

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public List<IFormFile> Images { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public string Description { get; set; }
        
        public List<CategoryViewModel> Categories { get; set; }
        [BindProperty]
        public List<SelectListItem> Types { get; set; }
        [BindProperty]
        public string Type { get; set; }
        public AddModel(IServiceConnector connector, FilesManager filesManager,IWebHostEnvironment hostEnvironment)
        {
            serviceConnector = connector;
            this.filesManager = filesManager;
            this.hostEnvironment = hostEnvironment;
            Images = new List<IFormFile>();
            Categories = new List<CategoryViewModel>();
          //  this.configuration = configurationRoot;
        }
        public void OnGet()
        {
            Types = new List<SelectListItem>() { new SelectListItem() { Text = ProductTypes.Meal, Value = ProductTypes.Meal }, new SelectListItem() { Text = ProductTypes.Drink, Value = ProductTypes.Drink } };
        }
        public async Task<IActionResult> OnGetProductType(string type)
        {
            if (type==ProductTypes.Meal)
            {
                Categories =await serviceConnector.Context.Set<Category>().Select(x => new CategoryViewModel { Id = x.Id, CategoryName = x.CategoryName }).ToListAsync();
                return Partial("_Categories", Categories);
            }
            else
            {
                Categories =await serviceConnector.Context.Set<DrinkCategory>().Select(x => new CategoryViewModel { Id = x.Id, CategoryName = x.Category.CategoryName }).ToListAsync();
                return Partial("_Categories", Categories);
            }

        }
        public async Task OnPost()
        {
            var paths=await filesManager.AddFile(Images,hostEnvironment.WebRootPath,"images");
            if (true)
            {

            }
        }
       
    }
}
