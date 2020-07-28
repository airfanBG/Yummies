using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seed
{
    public class DbSeed
    {
        private ModelBuilder ModelBuilder { get; }
        private List<MealCategory> mealCategories;
        private List<Meal> meals;
        private string customerId;
       
        public DbSeed(ModelBuilder builder)
        {
            ModelBuilder = builder;
           
        }
        public void Generate()
        {
            SeedUser();
            SeedMenu();
            SeedOrders(customerId, meals);
        }
        private void SeedUser()
        {
           
            var user = new User
            {
                Id=Guid.NewGuid().ToString(),
                FirstName = "airfan",
                LastName = "airfan",
                Email = "fall_out@abv.bg",
                NormalizedEmail = "FALL_OUT@ABV.BG",
                UserName = "airfan",
                NormalizedUserName = "AIRFAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
             
            };
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(user, "12345!@");
            user.PasswordHash = hashed;

            //Debugger.Launch();
         

            var customer = new Customer()
            {
                Id=Guid.NewGuid().ToString(),
               // User = user,
                UserId=user.Id,
                
            };
            customerId = customer.Id;
            ModelBuilder.Entity<User>().HasData(user);
            ModelBuilder.Entity<Customer>().HasData(customer);

        }
        private void SeedOrders(string customerId, List<Meal> meals)
        {
            var orderMeals = new List<OrderMeals>();
            var order = new Order()
            {
                Id=Guid.NewGuid().ToString(),
                CustomerId = customerId,
                HasPaid = false,
               // OrderedMeals = orderMeals
            };
            foreach (var item in meals)
            {
                orderMeals.Add(new OrderMeals()
                {
                    Id=Guid.NewGuid().ToString(),
                    MealId = item.Id,
                    OrderId = order.Id,
                    Quantity = 1,
                    //Order=order
                });
            }

            ModelBuilder.Entity<Order>().HasData(order);
            ModelBuilder.Entity<OrderMeals>().HasData(orderMeals);
            
        }
        private void SeedMenu()
        {
            SeedCategories();
            SeedMeals();
            
            var menuId = Guid.NewGuid().ToString();

           // Debugger.Launch();
            var menu = new Menu()
            {
                Id =menuId,
                MenuName ="Standard",
                Image="book_left_image.jpg"
            };

            ModelBuilder.Entity<Menu>().HasData(menu);
            ModelBuilder.Entity<MealCategory>().HasData(mealCategories);
            ModelBuilder.Entity<Meal>().HasData(meals);


            var menumealcat1=new MenuMealCategory()
            {
                Id = Guid.NewGuid().ToString(),
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Soups").Id,
               // MealCategory = mealCategories.FirstOrDefault(x => x.CategoryName == "Soups"),
                MenuId = menuId,
                //Menu = menu
               
            };
            var menumealcat2 = new MenuMealCategory()
            {
                Id = Guid.NewGuid().ToString(),
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Meals").Id,
               // MealCategory = mealCategories.FirstOrDefault(x => x.CategoryName == "Meals"),
                MenuId = menuId,
               // Menu = menu
            };
            var menumealcat3 = new MenuMealCategory()
            {
                Id = Guid.NewGuid().ToString(),
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Desserts").Id,
                //MealCategory = mealCategories.FirstOrDefault(x => x.CategoryName == "Desserts"),
                MenuId = menuId,
                //Menu = menu
            };



            ModelBuilder.Entity<MenuMealCategory>().HasData(menumealcat1);
            ModelBuilder.Entity<MenuMealCategory>().HasData(menumealcat2);
            ModelBuilder.Entity<MenuMealCategory>().HasData(menumealcat3);




        }
        private void SeedCategories()
        {
            mealCategories = new List<MealCategory>()
            {
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Soups",
                    Image="soup.jpg"
                },
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Meals",
                    Image="meal.jpg"
                },
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Desserts",
                    Image="desserts.jpg"
                },
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Drinks",
                    Image="drinks.jpg"
                }
            };
        }
        private void SeedMeals()
        {
            meals = new List<Meal>()
            {
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Pizza",
                    Image="pizza.jpg",
                    Price=10,
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Meals").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Chicken soup",
                    Image="chicken.jpg",
                     Price=20,
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Soups").Id
                },
                new Meal()
                {
                    
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Cake",
                    Image="cake.jpg",
                     Price=5,
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Desserts").Id
                },new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Wine",
                    Image="wine.jpg",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Drinks").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Fish",
                    Image="fish.jpg",
                     Price=15,
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Meals").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Fish soup",
                    Image="fish-soup.jpg",
                     Price=10,
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Soups").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Pancakes",
                    Image="pancakes.jpg",
                     Price=7,
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Desserts").Id
                },new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Water",
                    Image="water.jpg",
                     Price=3,
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Drinks").Id
                }
            };

        }
    }
}
