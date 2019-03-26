using GreenCycle.BL.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GreenCycle.BL
{
    public class Cashier : ICashier
    {
        private List<ISaleRules> _saleRules = new List<ISaleRules>();
        public Cashier()
        {
            _saleRules.Add(new FiveDollarRule());
            _saleRules.Add(new TenDollarRule());
            _saleRules.Add(new TwentyDollarRule());
            _saleRules.Add(new OtherDollarRule());
        }

        public bool SaleTicket(int amount)
        {
            return _saleRules.FirstOrDefault(s => s.IsMatch(amount)).CanSale(amount);
        }
    }
}
