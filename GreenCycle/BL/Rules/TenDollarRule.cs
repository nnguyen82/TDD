using System;
using System.Collections.Generic;
using System.Text;
using GreenCycle.Data;

namespace GreenCycle.BL.Rules
{
    public class TenDollarRule : ISaleRules
    {
        private readonly ICashRegister _cashRegister;
        public TenDollarRule(ICashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }
        public bool CanSale(int amount)
        {
            //Check if there is a $5 dollar change available
            //If Yes, remove $5 bill from the data store and add the $10 to the store. Return true.
            //Else return false.

            if (_cashRegister.FindBill(5) > 0)
            {
                _cashRegister.RemoveBill(5);
                _cashRegister.AddBill(10);

                return true;
            }

            return false;
        }

        public bool IsMatch(int amount)
        {
            if (amount == 10)
                return true;

            return false;
        }
    }
}
