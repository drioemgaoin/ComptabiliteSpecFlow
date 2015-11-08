using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ComptabiliteSpecFlow.Model
{
    public class Budget
    {
        private readonly IList<Flow> flows;

        public Budget(string name, decimal amount)
        {
            Name = name;
            Amount = amount;

            flows = new List<Flow>();
        }

        public string Name { get; private set; }

        public decimal Amount { get; private set; }

        public decimal NetValue { get; private set; }

        public void Add(Flow flow)
        {
            flows.Add(flow);
        }

        public void Compute()
        {
            NetValue = Amount + flows.Sum(flow => flow.Amount*(flow.Type == FlowType.Credit ? 1 : -1));
        }
    }
}
