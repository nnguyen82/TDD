using System;
using System.Collections.Generic;
using System.Text;

namespace GreenCycle.BL.Rules
{
    public class TwentyDollarRule : ISaleRules
    {
        public bool CanSale(int amount)
        {
            //Check if there is a $5 and $10 dollar change available
            //If Yes, remove $5 and $10 bill from the data store and add the $20 to the store. Return true.
            //Else return false.

            return true;
        }

        public bool IsMatch(int amount)
        {
            if (amount == 20)
                return true;

            return false;
        }
    }
}
