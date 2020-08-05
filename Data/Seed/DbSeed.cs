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
        private List<Category> mealCategories=new List<Category>();
        private List<Meal> meals=new List<Meal>();
        private string customerId;

        public DbSeed(ModelBuilder builder)
        {
            ModelBuilder = builder;

        }
        public void Generate()
        {
            SeedUser();
            SeedMenu();
            //SeedOrders(customerId, meals);
        }
        private void SeedUser()
        {

            //var user = new User
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    FirstName = "airfan",
            //    LastName = "airfan",
            //    Email = "fall_out@abv.bg",
            //    NormalizedEmail = "FALL_OUT@ABV.BG",
            //    UserName = "airfan",
            //    NormalizedUserName = "AIRFAN",
            //    PhoneNumber = "+111111111111",
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString("D"),

            //};
            //var password = new PasswordHasher<User>();
            //var hashed = password.HashPassword(user, "12345!@");
            //user.PasswordHash = hashed;

            var roleAdmin = new IdentityRole() { Name = "Admin".ToUpper(), };
            var roleCustomer = new IdentityRole() { Name = "Customer".ToUpper(), };
            var roleCheff = new IdentityRole() { Name = "Cheff".ToUpper(), };

            //var ur = new RoleStore<UserRole>(Mode)
            //ur.RoleId = roleAdmin.Id;
            //ur.UserId = user.Id;

            //Debugger.Launch();


            //var customer = new Customer()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    // User = user,
            //    UserId = user.Id,

            //};
            //customerId = customer.Id;
            //ModelBuilder.Entity<User>().HasData(user);
            ModelBuilder.Entity<IdentityRole>().HasData(roleAdmin, roleCheff, roleCustomer);
          //  ModelBuilder.Entity<IdentityUserRole<string>>().HasData(ur);
           // ModelBuilder.Entity<Customer>().HasData(customer);

        }
        private void SeedOrders(string customerId, List<Meal> meals)
        {
            var orderMeals = new List<OrderMeals>();
            var order = new Order()
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                HasPaid = false,
                
            };
            foreach (var item in meals)
            {
                orderMeals.Add(new OrderMeals()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealId = item.Id,
                    OrderId = order.Id,
                    Quantity = 1,
                });
            }

            ModelBuilder.Entity<Order>().HasData(order);
            ModelBuilder.Entity<OrderMeals>().HasData(orderMeals);

        }
        private void SeedMenu()
        {
            SeedCategories();
            SeedMeals();
            SeedDrinks();

            var menuId = Guid.NewGuid().ToString();

            // Debugger.Launch();
            var menu = new Menu()
            {
                Id = menuId,
                MenuName = "Standard",
                Image = "book_left_image.jpg"
            };

            ModelBuilder.Entity<Menu>().HasData(menu);
           
           


            var menumealcat1 = new MenuMealCategory()
            {
               // Id = Guid.NewGuid().ToString(),
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Soups").Id,
                // MealCategory = mealCategories.FirstOrDefault(x => x.CategoryName == "Soups"),
                MenuId = menuId,
                //Menu = menu

            };
            var menumealcat2 = new MenuMealCategory()
            {
                //Id = Guid.NewGuid().ToString(),
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Meals").Id,
                // MealCategory = mealCategories.FirstOrDefault(x => x.CategoryName == "Meals"),
                MenuId = menuId,
                // Menu = menu
            };
            var menumealcat3 = new MenuMealCategory()
            {
                //Id = Guid.NewGuid().ToString(),
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
            var cat1 = new Category()
            {
                //Id = Guid.NewGuid().ToString(),
                CategoryName = "Soups",
                Image = "soup.jpg",
                
            };
            var cat2 = new Category()
            {
                //Id = Guid.NewGuid().ToString(),
                CategoryName = "Meals",
                Image = "meal.jpg"
            };
              var cat3=  new Category()
                {
                    //Id = Guid.NewGuid().ToString(),
                    CategoryName = "Desserts",
                    Image = "desserts.jpg"
                };

            var cat4 = new Category()
            {
                //Id = Guid.NewGuid().ToString(),
                CategoryName = "Drinks",
                Image = "drinks.jpg"
            };
            mealCategories.Add(cat1);
            mealCategories.Add(cat2);
            mealCategories.Add(cat3);
            mealCategories.Add(cat4);

            ModelBuilder.Entity<Category>().HasData(cat1,cat2,cat3,cat4);
        }
        private void SeedMeals()
        {
            var ingradientMetricNumber = new IngradientMetric()
            {
                //Id = Guid.NewGuid().ToString(),
                MetricValue = "Number"
            };
            var ingradientMetricGrams = new IngradientMetric()
            {
                //Id = Guid.NewGuid().ToString(),
                MetricValue = "Grams"
            };
            var ingradientMetricLiters = new IngradientMetric()
            {
                //Id = Guid.NewGuid().ToString(),
                MetricValue = "Liters"
            };

            var ingradientEgg = new Ingradient()
            {
                //Id = Guid.NewGuid().ToString(),
                IngradientName = "Egg",
                IngradientMetricId = ingradientMetricNumber.Id
            };
            var ingradientMeet = new Ingradient()
            {
                //Id = Guid.NewGuid().ToString(),
                IngradientName = "Meet",
                IngradientMetricId = ingradientMetricGrams.Id
            };

            var ingradientSalt = new Ingradient()
            {
                //Id = Guid.NewGuid().ToString(),
                IngradientName = "Salt",
                IngradientMetricId = ingradientMetricGrams.Id
            };
            var ingradientShugar = new Ingradient()
            {
                //Id = Guid.NewGuid().ToString(),
                IngradientName = "Sugar",
                IngradientMetricId = ingradientMetricGrams.Id
            };
            var ingradientMilk = new Ingradient()
            {
                //Id = Guid.NewGuid().ToString(),
                IngradientName = "Milk",
                IngradientMetricId = ingradientMetricLiters.Id
            };
            var recepeeCake = new Recipe()
            {
                //Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients=new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(),IngradientId=ingradientEgg.Id,IngradientQuantity=3 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientMilk.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientShugar.Id, IngradientQuantity = 300 } },
                MealName = "Cake",
                TimeForPrepare = "30min",
                Description = "First add ..."
            };
            var recepeeSoup = new Recipe()
            {
                //Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients = new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientEgg.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientSalt.Id, IngradientQuantity = 1 }},
                MealName = "Chiken soup",
                TimeForPrepare = "20min",
                Description = "First add ..."
            };
            var recepeeFishsSoup = new Recipe()
            {
                //Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients = new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientEgg.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientSalt.Id, IngradientQuantity = 1 }},
                MealName = "Fish soup",
                TimeForPrepare = "20min",
                Description = "First add ..."
            };
            var recepeePancakes = new Recipe()
            {
                //Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients = new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientEgg.Id, IngradientQuantity = 5 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientSalt.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientMilk.Id, IngradientQuantity = 1 } },
                MealName = "Pancakes",
                TimeForPrepare = "20min",
                Description = "First add ..."
            };
            var recepeePizza = new Recipe()
            {
                //Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients = new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientEgg.Id, IngradientQuantity = 5 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientSalt.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientMilk.Id, IngradientQuantity = 1 } },
                MealName = "Pizza",
                TimeForPrepare = "20min",
                Description = "First add ..."
            };

            var recepeeFish = new Recipe()
            {
                //Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                //RecepeeIngradients = new List<RecepeeIngradients>() { new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientEgg.Id, IngradientQuantity = 5 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientSalt.Id, IngradientQuantity = 1 }, new RecepeeIngradients() { Id = Guid.NewGuid().ToString(), IngradientId = ingradientMilk.Id, IngradientQuantity = 1 } },
                MealName = "Fish",
                TimeForPrepare = "20min",
                Description = "First add ..."
            };

            ModelBuilder.Entity<IngradientMetric>().HasData(ingradientMetricGrams, ingradientMetricLiters, ingradientMetricNumber);

            ModelBuilder.Entity<Ingradient>().HasData(ingradientEgg, ingradientMeet, ingradientMilk, ingradientShugar);
            ModelBuilder.Entity<Recipe>().HasData(recepeeCake, recepeeSoup, recepeePancakes, recepeeFishsSoup, recepeePizza, recepeeFish);





            var meal1 = new Meal()
            {
                //Id = Guid.NewGuid().ToString(),
                MealName = "Pizza",
                Image = "pizza.jpg",
                Price = 10,
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Meals").Id,
                RecipeId = recepeePizza.Id
            };
            var meal2 = new Meal()
            {
                //Id = Guid.NewGuid().ToString(),
                MealName = "Chicken soup",
                Image = "chicken.jpg",
                Price = 20,
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Soups").Id,
                RecipeId = recepeeSoup.Id
            };
            var meal3 = new Meal()
            {

                //Id = Guid.NewGuid().ToString(),
                MealName = "Cake",
                Image = "cake.jpg",
                Price = 5,
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Desserts").Id,
                RecipeId = recepeeCake.Id

            };
            var meal4 = new Meal()
            {
                //Id = Guid.NewGuid().ToString(),
                MealName = "Fish",
                Image = "fish.jpg",
                Price = 15,
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Meals").Id,


            };
            var meal5 = new Meal()
            {
                //Id = Guid.NewGuid().ToString(),
                MealName = "Fish soup",
                Image = "fish-soup.jpg",
                Price = 10,
                MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Soups").Id,
                RecipeId = recepeeFishsSoup.Id
            };
             var meal6=   new Meal()
                {
                    //Id = Guid.NewGuid().ToString(),
                    MealName = "Pancakes",
                    Image = "pancakes.jpg",
                    Price = 7,
                    MealCategoryId = mealCategories.FirstOrDefault(x => x.CategoryName == "Desserts").Id,
                    RecipeId = recepeePancakes.Id
                };
            meals.Add(meal1);
            meals.Add(meal2);
            meals.Add(meal3);
            meals.Add(meal4);
            meals.Add(meal5);
            meals.Add(meal6);


            ModelBuilder.Entity<Meal>().HasData(meal1,meal2,meal3,meal4,meal5,meal6);

            var rateCake = new MealRate()
            {
                //Id = Guid.NewGuid().ToString(),
                MealId = meals[2].Id,
                Rate = 8
            };
            var rateCake1 = new MealRate()
            {
                //Id = Guid.NewGuid().ToString(),
                MealId = meals[2].Id,
                Rate = 9
            };
            var ratePizza = new MealRate()
            {
                //Id = Guid.NewGuid().ToString(),
                MealId = meals[0].Id,
                Rate = 10
            };
            var ratePizza1 = new MealRate()
            {
                //Id = Guid.NewGuid().ToString(),
                MealId = meals[0].Id,
                Rate = 9
            };
            var rateChicken = new MealRate()
            {
                //Id = Guid.NewGuid().ToString(),
                MealId = meals[1].Id,
                Rate = 9
            };
            var rateChicken1 = new MealRate()
            {
                //Id = Guid.NewGuid().ToString(),
                MealId = meals[1].Id,
                Rate = 7
            };
            ModelBuilder.Entity<MealRate>().HasData(rateCake, rateCake1, rateChicken, rateChicken1, ratePizza, ratePizza1);
        }
        public void SeedDrinks()
        {
            var categoyVine = new Category()
            {
                CategoryName="Vines",
                Image= "wine.jpg",
                //Id = Guid.NewGuid().ToString()
            };
            var categoyWater = new Category()
            {
                CategoryName = "Waters",
                Image = "water.jpg",
                //Id = Guid.NewGuid().ToString(),
            };
            var categoyFuzzyDrinks = new Category()
            {
                CategoryName = "FuzzyDrinks",
                Image = "orange-juice.jpg",
                //Id = Guid.NewGuid().ToString(),
            };

            

            var drinkwine = new Drink()
            {
                //Id = Guid.NewGuid().ToString(),
                DrinkName = "Merlot",
                Image = "wine.jpg",
                Price = 20,
              
            };
            var water = new Drink()
            {
                //Id = Guid.NewGuid().ToString(),
                DrinkName = "Spring life",
                Image = "water.jpg",
                Price = 3,
               
            };
            var fuzzy = new Drink()
            {
                //Id = Guid.NewGuid().ToString(),
                DrinkName = "Orange juice",
                Image = "orange-juice.jpg",
                Price = 3,
                
            };
            var drinkCategories1 = new DrinkCategory()
            {
                //Id = Guid.NewGuid().ToString(),
                CategoryId = categoyVine.Id,
                DrinkId = drinkwine.Id
            };
            var drinkCategories2 = new DrinkCategory()
            {
                //Id = Guid.NewGuid().ToString(),
                CategoryId = categoyWater.Id,
                DrinkId = water.Id
            };

            var drinkCategories3 = new DrinkCategory()
            {
                //Id = Guid.NewGuid().ToString(),
                CategoryId = categoyFuzzyDrinks.Id,
                DrinkId = fuzzy.Id
            };


            ModelBuilder.Entity<Category>().HasData(categoyVine, categoyWater, categoyFuzzyDrinks);

            ModelBuilder.Entity<Drink>().HasData(drinkwine,water,fuzzy);
            ModelBuilder.Entity<DrinkCategory>().HasData(drinkCategories1,drinkCategories2,drinkCategories3);
        }
    }
}
