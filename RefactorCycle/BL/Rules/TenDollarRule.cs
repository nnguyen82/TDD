using System;
using System.Collections.Generic;
using System.Text;
using RefactorCycle.Common;
using RefactorCycle.Data;

namespace RefactorCycle.BL.Rules
{
    public class TenDollarRule : ISaleRules
    {
        private readonly ICashRegister _cashRegister;
        public TenDollarRule(ICashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }

        public bool CanSale()
        {
            //Check if there is a $5 dollar change available
            //If Yes, remove $5 bill from the data store and add the $10 to the store. Return true.

            if (_cashRegister.FindBill(Dollar.FiveDollar) > 0)
            {
                _cashRegister.RemoveBill(Dollar.FiveDollar);
                _cashRegister.AddBill(Dollar.TenDollar);

                return true;
            }

            return false;
        }

        public bool IsMatch(int amount)
        {
            if (amount == Dollar.TenDollar)
                return true;

            return false;
        }
    }
}
