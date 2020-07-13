using Data;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.Models;
using Services.Implementations;
using System;
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
        public async Task Test_Add_Method_SaveChangesAsync()
        {
            OrderService = new OrderService(Context);

            //IModel order =(IModel) new Order()
            //{
            //    HasPaid=true,
            //    Customer=
            //};
            //await OrderService.Add();
        }
    }
}
