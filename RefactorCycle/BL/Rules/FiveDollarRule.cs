using System;
using System.Collections.Generic;
using System.Text;
using RefactorCycle.Common;
using RefactorCycle.Data;

namespace RefactorCycle.BL.Rules
{
    public class FiveDollarRule : ISaleRules
    {
        private readonly IRepository _repository;
        public FiveDollarRule(IRepository repository)
        {
            _repository = repository;
        }
        public bool CanSale()
        {
            //Add $5 to data store
            _repository.AddBill(Dollar.FiveDollar);

            return true;
        }

        public bool IsMatch(int amount)
        {
            if (amount == Dollar.FiveDollar)
                return true;

            return false;
        }
    }
}
