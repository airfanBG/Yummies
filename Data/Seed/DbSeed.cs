using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

            var roleAdmin = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", };
            var roleCustomer = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Customer", };
            var roleCheff = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Cheff", };

            var ur = new IdentityUserRole<string>();
            ur.RoleId = roleAdmin.Id;
            ur.UserId = user.Id;
            
            //Debugger.Launch();


            var customer = new Customer()
            {
                Id=Guid.NewGuid().ToString(),
               // User = user,
                UserId=user.Id,
                
            };
            customerId = customer.Id;
            ModelBuilder.Entity<User>().HasData(user);
            ModelBuilder.Entity<IdentityRole>().HasData(roleAdmin, roleCheff, roleCustomer);
            ModelBuilder.Entity<IdentityUserRole<string>>().HasData(ur);
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
            var ingradientMetricNumber = new IngradientMetric()
            {
                Id = Guid.NewGuid().ToString(),
                MetricValue = "Number"
            };
            var ingradientMetricGrams = new IngradientMetric()
            {
                Id = Guid.NewGuid().ToString(),
                MetricValue = "Grams"
            };
            var ingradientMetricLiters = new IngradientMetric()
            {
                Id = Guid.NewGuid().ToString(),
                MetricValue = "Liters"
            };

            var ingradientEgg = new Ingradient()
            {
                Id = Guid.NewGuid().ToString(),
                IngradientName = "Egg",
                IngradientMetricId=ingradientMetricNumber.Id
            };
            var ingradientMeet = new Ingradient()
            {
                Id = Guid.NewGuid().ToString(),
                IngradientName = "Meet",
                IngradientMetricId=ingradientMetricGrams.Id
            };

            var ingradientSalt = new Ingradient()
            {
                Id = Guid.NewGuid().ToString(),
                IngradientName = "Salt",
                IngradientMetricId=ingradientMetricGrams.Id
            };
            var ingradientShugar = new Ingradient()
            {
                Id = Guid.NewGuid().ToString(),
                IngradientName = "Sugar",
                IngradientMetricId=ingradientMetricGrams.Id
            };
            var ingradientMilk = new Ingradient()
            {
                Id = Guid.NewGuid().ToString(),
                IngradientName = "Milk",
                IngradientMetricId=ingradientMetricLiters.Id
            };
            var recepeeCake = new Recepee()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt=DateTime.Now,
                //RecepeeIngradients=new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(),IngradientId=ingradientEgg.Id,IngradientQuantity=3 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientMilk.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientShugar.Id, IngradientQuantity = 300 } },
                MealName="Cake",TimeForPrepare="30min",
                Description = "First add ..."
            };
            var recepeeSoup = new Recepee()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients = new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientEgg.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientSalt.Id, IngradientQuantity = 1 }},
                MealName = "Chiken soup",
                TimeForPrepare = "20min",
                Description="First add ..."
            };
            var recepeePancakes = new Recepee()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients = new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientEgg.Id, IngradientQuantity = 5 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientSalt.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientMilk.Id, IngradientQuantity = 1 } },
                MealName = "Pancakes",
                TimeForPrepare = "20min",
                Description = "First add ..."
            };

            ModelBuilder.Entity<IngradientMetric>().HasData(ingradientMetricGrams, ingradientMetricLiters, ingradientMetricNumber);

            ModelBuilder.Entity<Ingradient>().HasData(ingradientEgg, ingradientMeet, ingradientMilk, ingradientShugar);
            ModelBuilder.Entity<Recepee>().HasData(recepeeCake,recepeeSoup,recepeePancakes);


           

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
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Desserts").Id,
                    RecepeeId=recepeeCake.Id
                    
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
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Drinks").Id,
                    
                }
            };

            var rateCake = new MealRate()
            {
                Id = Guid.NewGuid().ToString(),
                MealId = meals[2].Id,
                Rate = 8
            }; 
            var rateCake1 = new MealRate()
            {
                Id = Guid.NewGuid().ToString(),
                MealId = meals[2].Id,
                Rate = 9
            };
            var ratePizza = new MealRate()
            {
                Id = Guid.NewGuid().ToString(),
                MealId = meals[0].Id,
                Rate = 10
            };
            var ratePizza1 = new MealRate()
            {
                Id = Guid.NewGuid().ToString(),
                MealId = meals[0].Id,
                Rate = 9
            };
            var rateChicken = new MealRate()
            {
                Id = Guid.NewGuid().ToString(),
                MealId = meals[1].Id,
                Rate = 9
            };
            var rateChicken1 = new MealRate()
            {
                Id = Guid.NewGuid().ToString(),
                MealId = meals[1].Id,
                Rate = 7
            };
            ModelBuilder.Entity<MealRate>().HasData(rateCake, rateCake1, rateChicken, rateChicken1, ratePizza, ratePizza1);
        }
    }
}
