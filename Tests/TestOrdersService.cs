using Data;
using Models.Interfaces;
using Models.Models;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
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

            BaseEntity order = new Order()
            {
                Id = "499ffbad-8dba-4f5b-afa4-a30ccb4857e",
                HasPaid = true,
                CustomerId = "499ffbad-8dba-4f5b-afa4-a30cab4857e2",
                //OrderedMeals = new List<Meal>() { new Meal() { Id = "499ffbad-8dba-4f5b-afa4-a30ccb4857ea", MealName = "Pizza", Price = 10, TimeForPrepare = "30" }, new Meal() { Id = "499ffbad-8dba-4f5b-afa4-a30ccb4857eq", MealName = "Pizza", Price = 10, TimeForPrepare = "30" } }

            };

            await OrderService.Add(order);

        }
        [Fact]
        public async Task Test_Edit_Order_Method_SaveChangesAsync()
        {
            OrderService = new OrderService(Context);
            var id = "499ffbad-8dba-4f5b-afa4-a30ccb4857e";
            var res = Context.Orders.FirstOrDefault(x => x.Id == id);
            res.HasPaid = false;

            await OrderService.Update(res);

            var afterUpdate = Context.Orders.FirstOrDefault(x => x.Id == id);

            Assert.False(afterUpdate.HasPaid);

        }
        [Fact]
        public async Task Test_Get_All_Orders_Method_SaveChangesAsync()
        {
            OrderService = new OrderService(Context);
            var res = await OrderService.GetAll();

            Assert.Collection(res, model => Assert.Contains("499ffbad-8dba-4f5b-afa4-a30ccb4857e", model.Id));
        }
        [Fact]
        public async Task Test_TotalSum_Of_Order()
        {
            var clientId = "499ffbad-8dba-4f5b-afa4-a30cab4857e2";
            OrderService = new OrderService(Context);
            await OrderService.Add(new Order()
            {
                CustomerId = clientId,
                OrderComment = "Test",
                OrderedMeals = new List<OrderMeals>() { new OrderMeals() { MealId = "499ffbad-8dba-4f5b-afa4-a30ccb4857ea" } }
            });
            var res= await OrderService.TotalSum(clientId);
            Assert.Equal((decimal)9.97, res);
        }
        [Fact]
        public async Task Test_Finish_Order()
        {
            OrderService = new OrderService(Context);
            var orderId = "381b3cd1-5f3b-4c68-a5d9-b9dae8183913";
            var res= await OrderService.FinishOrder(orderId);
            Assert.Equal(1, res);
        }
    }
}
