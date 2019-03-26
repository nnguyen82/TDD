using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorCycle.BL
{
    public interface ICashier
    {
        bool SaleTicket(int amount);
    }
}
