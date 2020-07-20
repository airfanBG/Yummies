using Data;
using Services.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests
{
    public class ServiceConnectorTest
    {
        [Fact]
        public void Test_Service()
        {
            var service = new ServiceConnector(new ApplicationDbContext());
            Assert.NotNull(service);
        }
        [Fact]
        public void Test_Service_GetAll_method()
        {
            var service = new ServiceConnector(new ApplicationDbContext());
            var res = service.Meals.GetAll();
            Assert.NotEmpty(res.Result);
        }
    }
}
