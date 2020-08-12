using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Models.Models.IdentityModels;
using Services.Implementations;
using Services.Interfaces;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IndexService _indexService;
        [BindProperty]
        public List<MealViewModel> TopOrdered { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IndexService service)
        {
            _logger = logger;
            _indexService = service;
        }

        public async Task OnGet()
        {
            TopOrdered =await _indexService.MostOrderedMealsAsync();
            
        }
    }
}
