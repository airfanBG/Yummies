using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class MenuService
    {
        public IServiceConnector ServiceConnector { get; }
        public MenuService(IServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }
        

    }
}
