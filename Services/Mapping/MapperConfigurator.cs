using AutoMapper;
using Models.Models;
using Models.Models.IdentityModels;
using Services.Interfaces;
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
            CreateMap<Category, MealCategoryViewModel>().ReverseMap();
            CreateMap<Meal, IMealViewModel>().ForMember(x=>x.Description,z=>z.MapFrom(a=>a.MealDescription)).ForMember(x=>x.Name,z=>z.MapFrom(a=>a.MealName)).ForMember(x=>x.Recepee,z=>z.MapFrom(o=>o.Recipe)).ReverseMap();
            CreateMap<Order, IOrderViewModel>().ReverseMap();
            CreateMap<OrderMeals, IOrderMeal>().ForMember(x=>x.Meal,z=>z.MapFrom(a=>a.Meal)).ReverseMap();
            CreateMap<Customer, ICustomerViewModel>().ReverseMap();
            CreateMap<User, IUserViewModel>().ReverseMap();
            CreateMap<Recipe, RecepeeViewModel>().ForMember(x=>x.RecepeeIngradients,o=>o.MapFrom(z=>z.RecepeeIngradients)).ReverseMap();
            CreateMap<RecipeIngradients, RecepeeIngradientsViewModel>().ForMember(x=>x.Ingradient,o=>o.MapFrom(z=>z.Ingradient)).ReverseMap();
            CreateMap<RecipeIngradients, RecepeeIngradientsViewModel>().ForMember(x => x.Recepee, o => o.MapFrom(z => z.Recipe)).ReverseMap();
            CreateMap<Ingradient, IngradientViewModel>().ForMember(x => x.RecepeeIngradients, z => z.MapFrom(o => o.RecepeeIngradients)).ReverseMap();
            CreateMap<IngradientMetric, IngradientMetricViewModel>().ReverseMap();
            CreateMap<Drink, IDrinkViewModel>().ForMember(x=>x.Name,z=>z.MapFrom(a=>a.DrinkName)).ForMember(x=>x.DrinkCategoryViewModels,o=>o.MapFrom(z=>z.DrinkCategories)).ReverseMap();
            CreateMap<Category, CategoryViewModel>().ForMember(x=>x.DrinkCategories,o=>o.MapFrom(z=>z.DrinkCategories)).ReverseMap();
            CreateMap<DrinkCategory, DrinkCategoryViewModel>().ForMember(x => x.CategoryViewModel, o => o.MapFrom(z => z.Category)).ForMember(z => z.DrinkViewModel, o => o.MapFrom(x => x.Drink)).ReverseMap();
            CreateMap<OrderDrinks, OrderDrinksViewModel>().ForMember(x=>x.Drink,o=>o.MapFrom(z=>z.Drink)).ReverseMap();
            CreateMap<IOrderItemViewModel, OrderDrinksViewModel>().ReverseMap();
            CreateMap<OrderMealsViewModel, IOrderItemViewModel>().ReverseMap();
        }
    }
}
