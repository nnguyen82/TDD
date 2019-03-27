using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RefactorCycle.Data
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
            try
            {
                _billStore.Add(amount);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int FindBill(int amount)
        {
            try
            {
                return _billStore.Where(w => w == amount).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveBill(int amount)
        {
            try
            {
                _billStore.Remove(amount);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveBill(int amount, int times)
        {
            try
            {
                for (int i = 0; i < times; i++)
                {
                    _billStore.Remove(amount);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
