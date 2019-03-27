using GreenCycle.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenCycle.BL.Rules
{
    public class FiveDollarRule : ISaleRules
    {
        private readonly ICashRegister _cashRegister;
        public FiveDollarRule(ICashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }

        public bool CanSale(int amount)
        {
            //Add $5 to data store
            _cashRegister.AddBill(5);
            return true;
        }

        public bool IsMatch(int amount)
        {
            if (amount == 5)
                return true;

            return false;
        }
    }
}
