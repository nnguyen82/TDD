using GreenCycle.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenCycle.BL.Rules
{
    public class TwentyDollarRule : ISaleRules
    {
        private readonly ICashRegister _cashRegister;
        public TwentyDollarRule(ICashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }
        public bool CanSale(int amount)
        {
            //Check if there is a $5 and $10 dollar change available
            //If Yes, remove $5 and $10 bill from the data store and add the $20 to the store. Return true.
            //Else return false.
            bool bReturn = false;

            if (_cashRegister.FindBill(10) > 0 && _cashRegister.FindBill(5) > 0)
            {
                _cashRegister.RemoveBill(5);
                _cashRegister.RemoveBill(10);

                bReturn = true;
            }
            else if (_cashRegister.FindBill(5) > 2)
            {
                _cashRegister.RemoveBill(5);
                _cashRegister.RemoveBill(5);
                _cashRegister.RemoveBill(5);

                bReturn = true;
            }

            _cashRegister.AddBill(20);

            return bReturn;
        }

        public bool IsMatch(int amount)
        {
            if (amount == 20)
                return true;

            return false;
        }
    }
}
