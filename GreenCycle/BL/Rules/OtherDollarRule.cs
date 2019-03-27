using GreenCycle.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenCycle.BL.Rules
{
    public class OtherDollarRule : ISaleRules
    {
        private readonly ICashRegister _cashRegister;
        public OtherDollarRule(ICashRegister cashRegister)
        {
            _cashRegister = cashRegister;
        }

        public bool CanSale(int amount)
        {
            //Can't sale
            return false;
        }

        public bool IsMatch(int amount)
        {
            if(amount == 1 || amount == 50 || amount == 100)
            {
                return true;
            }

            return false;
        }
    }
}
