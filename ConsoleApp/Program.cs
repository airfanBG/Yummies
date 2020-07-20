using Data;
using Services.Implementations;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sc = new ServiceConnector(new ApplicationDbContext());
            var t=sc.Menus.GetAll().Result;
           
        }
    }
}
