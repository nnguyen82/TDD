using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorCycle.Data
{
    public interface IRepository
    {
        bool AddBill(int amount);
        bool RemoveBill(int amount);
        int FindBill(int amount);
    }
}
