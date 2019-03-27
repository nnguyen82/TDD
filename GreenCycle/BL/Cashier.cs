using GreenCycle.BL.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GreenCycle.Data;

namespace GreenCycle.BL
{
    public class Cashier : ICashier
    {
        private List<ISaleRules> _saleRules = new List<ISaleRules>();
        public Cashier(ICashRegister cashRegister)
        {
            _saleRules.Add(new FiveDollarRule(cashRegister));
            _saleRules.Add(new TenDollarRule(cashRegister));
            _saleRules.Add(new TwentyDollarRule(cashRegister));
            _saleRules.Add(new OtherDollarRule(cashRegister));
        }

        public bool SaleTicket(int amount)
        {
            return _saleRules.FirstOrDefault(s => s.IsMatch(amount)).CanSale(amount);
        }
    }
}
