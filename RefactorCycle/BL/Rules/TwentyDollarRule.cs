using System;
using System.Collections.Generic;
using System.Text;
using RefactorCycle.Common;
using RefactorCycle.Data;

namespace RefactorCycle.BL.Rules
{
    public class TwentyDollarRule : ISaleRules
    {
        private readonly IRepository _repository;
        public TwentyDollarRule(IRepository repository)
        {
            _repository = repository;
        }

        public bool CanSale()
        {
            //Check if there is a $5 and $10 dollar change available
            //If Yes, remove $5 and $10 bill from the data store and add the $20 to the store. Return true.
            //Else return false.
            bool bReturn = false;

            if (_repository.FindBill(Dollar.TenDollar) > 0 && _repository.FindBill(Dollar.FiveDollar) > 0)
            {
                _repository.RemoveBill(Dollar.FiveDollar);
                _repository.RemoveBill(Dollar.TenDollar);

                bReturn = true;
            }
            else if(_repository.FindBill(Dollar.FiveDollar) > 2)
            {
                _repository.RemoveBill(Dollar.FiveDollar);
                _repository.RemoveBill(Dollar.FiveDollar);
                _repository.RemoveBill(Dollar.FiveDollar);

                bReturn = true;
            }

            _repository.AddBill(Dollar.TwentyDollar);

            return bReturn;
        }

        public bool IsMatch(int amount)
        {
            if (amount == Dollar.TwentyDollar)
                return true;

            return false;
        }
    }
}
