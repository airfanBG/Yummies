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
            CreateMap<MenuViewModel, Menu>();
            CreateMap<Menu,MenuViewModel>();
            CreateMap<List<Menu>, List<MenuViewModel>>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<List<Order>, List<OrderViewModel>>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<List<Customer>, List<CustomerViewModel>>();
            CreateMap<MealViewModel, Meal>();
            CreateMap<Meal, MealViewModel>();
            CreateMap<List<Meal>, List<MealViewModel>>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

        }
    }
}
