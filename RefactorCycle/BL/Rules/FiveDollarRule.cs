using System;
using System.Collections.Generic;
using System.Text;
using RefactorCycle.Common;
using RefactorCycle.Data;

namespace RefactorCycle.BL.Rules
{
    public class FiveDollarRule : ISaleRules
    {
        private readonly ICashRegister _cashRegister;
        public FiveDollarRule(ICashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }
        public bool CanSale()
        {
            //Add $5 to data store
            _cashRegister.AddBill(Dollar.FiveDollar);

            return true;
        }

        public bool IsMatch(int amount)
        {
            if (amount == Dollar.FiveDollar)
                return true;

            return false;
        }
    }
}
