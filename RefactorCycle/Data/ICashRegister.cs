using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorCycle.Data
{
    public interface ICashRegister
    {
        bool AddBill(int amount);
        bool RemoveBill(int amount);
        bool RemoveBill(int amount, int times);
        int FindBill(int amount);
    }
}
