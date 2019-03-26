using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorCycle.BL.Rules
{
    public interface ISaleRules
    {
        bool IsMatch(int amount);
        bool CanSale();
    }
}
