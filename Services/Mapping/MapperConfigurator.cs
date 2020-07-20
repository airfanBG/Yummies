using AutoMapper;
using Models.Models;
using Models.Models.IdentityModels;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Mapping
{
    public class MapperConfigurator
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu, MenuViewModel>().ForMember(x=>x.MenuMealCategoryViewModels,o=>o.MapFrom(z=>z.MenuMealCategories)).ReverseMap();
            CreateMap<MenuMealCategoryViewModel, MenuMealCategory>().ForMember(x => x.MealCategory, c => c.MapFrom(m => m.MealCategoryViewModel)).ForMember(z=>z.Menu,m=>m.MapFrom(x=>x.MenuViewModel)).ReverseMap();
            CreateMap<MealCategory, MealCategoryViewModel>().ReverseMap();
            CreateMap<Meal, MealViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
           
        }
    }
}
