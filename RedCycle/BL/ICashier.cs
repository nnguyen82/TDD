using System;
using System.Collections.Generic;
using System.Text;

namespace RedCycle.BL
{
    public interface ICashier
    {
        bool SaleTicket(int amount);
    }
}
