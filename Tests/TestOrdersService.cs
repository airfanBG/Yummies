using Data;
using Models.Interfaces;
using Models.Models;
using Services.Implementations;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class TestOrdersService
    {
        private ApplicationDbContext Context { get; set; }
        private OrderService OrderService { get; set; }
       
        [Fact]
        public async Task Test_Add_Order_Method_SaveChangesAsync()
        {
            Context = new ApplicationDbContext();
            OrderService = new OrderService(Context);

            OrderViewModel order = new OrderViewModel()
            {
                Id = "499ffbad-8dba-4f5b-afa4-a30ccb4857e",
                HasPaid = true,
                CustomerId = "e5ea694e-cd4e-43a3-bde1-58d13e81f468",
                OrderedMeals=new List<OrderMealsViewModel>() { new OrderMealsViewModel() { MealId= "e5ea694e-cd4e-43a3-bde1-58d13e01f468",Id= "e5ea694e-cd4e-43a3-bde1-58d13e01f460" } }
                //OrderedMeals = new List<Meal>() { new Meal() { Id = "499ffbad-8dba-4f5b-afa4-a30ccb4857ea", MealName = "Pizza", Price = 10, TimeForPrepare = "30" }, new Meal() { Id = "499ffbad-8dba-4f5b-afa4-a30ccb4857eq", MealName = "Pizza", Price = 10, TimeForPrepare = "30" } }

            };

            await OrderService.Add(order);

        }
        [Fact]
        public async Task Test_Edit_Order_Method_SaveChangesAsync()
        {
            Context = new ApplicationDbContext();
            OrderService = new OrderService(Context);
            var id = "e95779c4-f474-4363-814a-5cb30bb5a138";
            var res =await OrderService.FindOrder(id);

            res.HasPaid = false;

            await OrderService.Update(res);

            var afterUpdate = Context.Orders.FirstOrDefault(x => x.Id == id);

            Assert.False(afterUpdate.HasPaid);

        }
        [Fact]
        public async Task Test_Get_All_Orders_Method_SaveChangesAsync()
        {
            Context = new ApplicationDbContext();
            OrderService = new OrderService(Context);
            var res = await OrderService.GetAll();

            Assert.NotEmpty(res);
        }
        [Fact]
        public async Task Test_TotalSum_Of_Order()
        {
            Context = new ApplicationDbContext();
            var clientId = "e5ea694e-cd4e-43a3-bde1-58d13e81f468";
            OrderService = new OrderService(Context);
            await OrderService.Add(new OrderViewModel()
            {
                CustomerId = clientId,
                OrderComment = "Test",
                OrderedMeals = new List<OrderMealsViewModel>() { new OrderMealsViewModel() { MealId = "e5ea694e-cd4e-43a3-bde1-58d13e01f468" } }
            });
            var res= await OrderService.TotalSum(clientId);
            Assert.Equal((decimal)9.708737, res);
        }
        [Fact]
        public async Task Test_Finish_Order()
        {
            Context = new ApplicationDbContext();
            OrderService = new OrderService(Context);
            var orderId = "e95779c4-f474-4363-814a-5cb30bb5a138";
            var res= await OrderService.FinishOrder(orderId);
            Assert.Equal(1, res);
        }
        [Fact]
        public async Task Get_Not_Finished_Orders()
        {
            Context = new ApplicationDbContext();
            var userId = "57b577f9-8fa6-49c4-b07c-fccb29f1cf54";
            OrderService = new OrderService(Context);
           var res= await OrderService.GetNotFinishedOrders(userId);
            Assert.NotEmpty(res);
        }
    }
}
