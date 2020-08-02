using Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Interfaces;
using Models.Models;
using Models.Models.IdentityModels;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private IConfigurationRoot configuration;
        private DbContext Context { get; }
        public ApplicationDbContext(DbContext context)
        {
            //Debugger.Launch();
            Context = context;
        }
        public ApplicationDbContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMeals> OrderMeals { get; set; }
        public DbSet<ShoppingCard> ShoppingCards { get; set; }
        public DbSet<MenuMealCategory> MenuMealCategories { get; set; }

        public DbSet<MealCategory> MealCategories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingradient> Ingradients { get; set; }
        public DbSet<MealRate> MealRates { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngradients> RecepeeIngradients { get; set; }
        public DbSet<IngradientMetric> IngradientMetrics { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(@"C:\Users\airfan\AppData\Roaming\Microsoft\UserSecrets\aspnet-Yummies-E2CE51DC-08AA-4BA0-96E9-49E9F3FF58C5\"/*Assembly.GetExecutingAssembly().Location*/)).AddJsonFile("secrets.json").Build();
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //DbSeed seed = new DbSeed(builder);
            //seed.Generate();

            base.OnModelCreating(builder);
        }

        private void ApplyEntityChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => (x.Entity is BaseEntity || x.Entity is User) && x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified).ToList();

            foreach (var entry in entries)
            {
                if (entry.Entity is User)
                {
                    var entity = (User)entry.Entity;

                    if (entry.State == EntityState.Added)
                    {
                        entity.Id = Guid.NewGuid().ToString();
                        entity.CreatedAt = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        entity.DeletedAt = DateTime.Now;

                    }
                    else
                    {
                        entity.ModifiedAt = DateTime.Now;
                    }
                }
                else
                {
                    var entity = (BaseEntity)entry.Entity;

                    if (entry.State == EntityState.Added)
                    {
                        entity.Id = Guid.NewGuid().ToString();
                        entity.CreatedAt = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        entity.DeletedAt = DateTime.Now;

                    }
                    else
                    {
                        entity.ModifiedAt = DateTime.Now;
                    }
                }
               
            }
        }
        public override int SaveChanges()
        {
            return SaveChanges(true);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyEntityChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyEntityChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(true);
        }
    }
}
