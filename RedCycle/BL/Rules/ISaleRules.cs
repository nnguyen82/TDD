using System;
using System.Collections.Generic;
using System.Text;

namespace RedCycle.BL.Rules
{
    public interface ISaleRules
    {
        bool IsMatch(int amount);
        bool CanSale(int amount);
    }
}
