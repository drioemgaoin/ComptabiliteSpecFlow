using System;

namespace ComptabiliteSpecFlow.Model
{
    public class Flow
    {
        public Flow(string budget, DateTime date, decimal amount, FlowType type, string description = null)
        {
            Budget = budget;
            Date = date;
            Type = type;
            Description = description;
            Amount = amount;
        }

        public string Budget { get; private set; }

        public FlowType Type { get; private set; }

        public DateTime Date { get; private set; }

        public string Description { get; private set; }

        public decimal Amount { get; private set; }
    }
}
