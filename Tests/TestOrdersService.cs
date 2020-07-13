using Data;
using Models.Interfaces;
using Models.Models;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class TestOrdersService
    {
        private ApplicationDbContext Context { get; }
        private OrderService OrderService { get; set; }
        public TestOrdersService()
        {
            Context = new ApplicationDbContext();
           
        }
        [Fact]
        public async Task Test_Add_Order_Method_SaveChangesAsync()
        {
            OrderService = new OrderService(Context);

            IBaseEntity order = new Order()
            {
                Id= "499ffbad-8dba-4f5b-afa4-a30ccb4857e",
                HasPaid = true,
               CustomerId= "499ffbad-8dba-4f5b-afa4-a30cab4857e2",
               OrderedMeals=new List<Meal>() { new Meal() {Id="499ffbad-8dba-4f5b-afa4-a30ccb4857ea", MealName = "Pizza", Price = 10, TimeForPrepare = "30" }, new Meal() {Id="499ffbad-8dba-4f5b-afa4-a30ccb4857eq", MealName = "Pizza", Price = 10, TimeForPrepare = "30" } }
               
            };
            
             await OrderService.Add(order);
         
        }
    }
}
