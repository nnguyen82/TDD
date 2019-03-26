using System;
using Microsoft.Extensions.DependencyInjection;
using RedCycle.BL;

namespace RedCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddScoped<ICashier, Cashier>()
                .BuildServiceProvider();

        }
    }
}
