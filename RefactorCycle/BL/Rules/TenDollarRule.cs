using System;
using System.Collections.Generic;
using System.Text;
using RefactorCycle.Common;
using RefactorCycle.Data;

namespace RefactorCycle.BL.Rules
{
    public class TenDollarRule : ISaleRules
    {
        private readonly IRepository _repository;
        public TenDollarRule(IRepository repository)
        {
            _repository = repository;
        }

        public bool CanSale()
        {
            //Check if there is a $5 dollar change available
            //If Yes, remove $5 bill from the data store and add the $10 to the store. Return true.

            if (_repository.FindBill(Dollar.FiveDollar) > 0)
            {
                _repository.RemoveBill(Dollar.FiveDollar);
                _repository.AddBill(Dollar.TenDollar);

                return true;
            }

            return false;
        }

        public bool IsMatch(int amount)
        {
            if (amount == Dollar.TenDollar)
                return true;

            return false;
        }
    }
}
