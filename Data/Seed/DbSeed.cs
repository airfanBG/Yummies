using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Data.Seed
{
    public class DbSeed
    {
        private ModelBuilder ModelBuilder { get; }
        private List<MealCategory> mealCategories;
        private List<Meal> meals;

        public DbSeed(ModelBuilder builder)
        {
            ModelBuilder = builder;
        }
        public void Generate()
        {
            SeedMenu();

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
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Meals").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Chicken soup",
                    Image="chicken.jpg",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Soups").Id
                },
                new Meal()
                {
                    
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Cake",
                    Image="cake.jpg",
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
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Meals").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Fish soup",
                    Image="fish-soup.jpg",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Soups").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Pancakes",
                    Image="pancakes.jpg",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Desserts").Id
                },new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Water",
                    Image="water.jpg",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Drinks").Id
                }
            };

        }
    }
}
