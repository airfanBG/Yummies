using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using Models.Models.IdentityModels;
using Microsoft.Extensions.Logging;
using Yummies.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using Yummies.InnerServices;
using Services.Implementations;
using Services.Interfaces;
using Services.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Yummies
{
    public class Startup
    {
        private string _appApiKey = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _appApiKey = Configuration["Yummies:ServiceApiKey"];

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>(options =>
           {
               options.SignIn.RequireConfirmedAccount = true;
               options.SignIn.RequireConfirmedEmail = true;

           })
               
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI();

            //services
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //store services
            services.AddScoped<UserManager<User>>();
            //services.AddScoped<CustomerService>();
            services.AddScoped<SignInManager<User>>();
            services.AddScoped<IndexService>();
            services.AddScoped<OrderService>();
            services.AddScoped<MenuService>();
            services.AddScoped<MealService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<KitchenService>();
            services.AddScoped<IServiceConnector, ServiceConnector>();
            services.AddScoped<ServiceConnector>();
            services.AddScoped<ILogger<RegisterModel>, Logger<RegisterModel>>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            //email services
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            //facebook login
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddSession(session =>
            {
                session.Cookie.HttpOnly = true;
                session.Cookie.IsEssential = true;
                session.IdleTimeout = TimeSpan.FromSeconds(60 * 5);

            });
            services.ConfigureApplicationCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromDays(5);
                o.SlidingExpiration = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.Name = "OnTime";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Identity/Account/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.Use(async (context, next) =>
            {
                AddHeaderInfoAsync(context);
                await next();
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
        public void AddHeaderInfoAsync(HttpContext context)
        {
            context.Request.Headers.Add("X-Name", "Yummies");

        }
    }
}
