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

namespace Yummies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
          
        }

        public async Task OnGet()
        {
          
        }
    }
}
