using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
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
            SeedCategories();
            SeedMeals();


            ModelBuilder.Entity<MealCategory>().HasData(mealCategories);
            ModelBuilder.Entity<Meal>().HasData(meals);

        }
        private void SeedCategories()
        {
            mealCategories = new List<MealCategory>()
            {
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Soups"
                },
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Meals"
                },
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Desserts"
                },
                new MealCategory()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryName="Drinks"
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
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Meals").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Chicken soup",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Soups").Id
                },
                new Meal()
                {
                    
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Cake",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Desserts").Id
                },new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Vine",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Drinks").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Fish",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Meals").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Fish soup",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Soups").Id
                },
                new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Pancakes",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Desserts").Id
                },new Meal()
                {
                    Id = Guid.NewGuid().ToString(),
                    MealName= "Water",
                    MealCategoryId= mealCategories.FirstOrDefault(x=>x.CategoryName=="Drinks").Id
                }
            };

        }
    }
}
