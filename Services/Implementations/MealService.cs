using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MealService
    {
        public IServiceConnector ServiceConnector { get;}

        public MealService(IServiceConnector serviceConnector)
        {
            this.ServiceConnector = serviceConnector;
        }

        
    }
}
