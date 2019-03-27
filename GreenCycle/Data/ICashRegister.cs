using System;
using System.Collections.Generic;
using System.Text;

namespace GreenCycle.Data
{
    public interface ICashRegister
    {
        bool AddBill(int amount);
        bool RemoveBill(int amount);
        int FindBill(int amount);
    }
}
