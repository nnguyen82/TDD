using System;
using System.Collections.Generic;
using System.Text;

namespace GreenCycle.BL.Rules
{
    public class FiveDollarRule : ISaleRules
    {
        public bool CanSale(int amount)
        {
            //Add $5 to data store

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
