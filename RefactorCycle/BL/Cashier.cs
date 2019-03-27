using RefactorCycle.BL.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RefactorCycle.Data;
using Microsoft.Extensions.DependencyInjection;

namespace RefactorCycle.BL
{
    public class Cashier : ICashier
    {
        private IServiceProvider _serviceProvider;

        public Cashier(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool SaleTicket(int amount)
        {
            var sale = _serviceProvider.GetServices<ISaleRules>().ToList().FirstOrDefault(s => s.IsMatch(amount));

            if(sale == null)
            {
                return false;
            }

            return sale.CanSale();
        }
    }
}
