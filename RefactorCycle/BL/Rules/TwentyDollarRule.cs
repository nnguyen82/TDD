using System;
using System.Collections.Generic;
using System.Text;
using RefactorCycle.Common;
using RefactorCycle.Data;

namespace RefactorCycle.BL.Rules
{
    public class TwentyDollarRule : ISaleRules
    {
        private readonly ICashRegister _cashRegister;
        public TwentyDollarRule(ICashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }

        public bool CanSale()
        {
            //Check if there is a $5 and $10 dollar change available
            //If Yes, remove $5 and $10 bill from the data store and add the $20 to the store. Return true.
            //Else return false.
            bool bReturn = false;

            if (_cashRegister.FindBill(Dollar.TenDollar) > 0 && _cashRegister.FindBill(Dollar.FiveDollar) > 0)
            {
                _cashRegister.RemoveBill(Dollar.FiveDollar);
                _cashRegister.RemoveBill(Dollar.TenDollar);

                bReturn = true;
            }
            else if(_cashRegister.FindBill(Dollar.FiveDollar) > 2)
            {
                _cashRegister.RemoveBill(Dollar.FiveDollar, 3);

                bReturn = true;
            }

            _cashRegister.AddBill(Dollar.TwentyDollar);

            return bReturn;
        }

        public bool IsMatch(int amount)
        {
            if (amount == Dollar.TwentyDollar)
                return true;

            return false;
        }
    }
}
