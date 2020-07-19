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
            //CreateMap<Menu,MenuViewModel>().ForMember(x=>x.MenuMealCategoryViewModels,x=>x.);
            //CreateMap<MenuMealCategory, MenuMealCategoryViewModel>();
            //CreateMap<MenuMealCategoryViewModel, MenuMealCategory>();
            //CreateMap<List<MenuMealCategory>, List<MenuMealCategoryViewModel>>();
            //CreateMap<List<MenuMealCategoryViewModel>, List<MenuMealCategory>>();
            //CreateMap<MealCategoryViewModel, MealCategory>();
            //CreateMap<MealCategory, MealCategoryViewModel>();  
            //CreateMap<List<MealCategoryViewModel>, List<MealCategory>>();
            //CreateMap<List<MealCategory>, List<MealCategoryViewModel>>();
            //CreateMap<List<Menu>, List<MenuViewModel>>();
            //CreateMap<List<MenuViewModel>, List<Menu>>();
            //CreateMap<List<MenuMealCategory>, List<MealCategoryViewModel>>();
            //CreateMap<List<MealCategoryViewModel>, List<MenuMealCategory>>();
            //CreateMap<OrderViewModel, Order>();
            //CreateMap<Order, OrderViewModel>();
            //CreateMap<List<Order>, List<OrderViewModel>>();
            //CreateMap<CustomerViewModel, Customer>();
            //CreateMap<Customer, CustomerViewModel>();
            //CreateMap<List<Customer>, List<CustomerViewModel>>();
            //CreateMap<MealViewModel, Meal>();
            //CreateMap<Meal, MealViewModel>();
            //CreateMap<List<Meal>, List<MealViewModel>>();
            //CreateMap<User, UserViewModel>();
            //CreateMap<UserViewModel, User>();

        }
    }
}
