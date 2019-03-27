using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GreenCycle.Data
{
    public class CashRegister : ICashRegister
    {
        private List<int> _billStore;
        public CashRegister()
        {
            _billStore = new List<int>();
        }
        public bool AddBill(int amount)
        {
            _billStore.Add(amount);

            return true;
        }

        public int FindBill(int amount)
        {
            return _billStore.Where(w => w == amount).Count();
        }

        public bool RemoveBill(int amount)
        {
            _billStore.Remove(amount);

            return true;
        }
    }
}
