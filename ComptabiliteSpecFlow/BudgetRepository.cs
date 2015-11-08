using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ComptabiliteSpecFlow.Model;

namespace ComptabiliteSpecFlow
{
    public interface IBudgetRepository
    {
        IReadOnlyCollection<Budget> Budgets { get; }

        void Add(Budget budget);
    }

    public class BudgetRepository : IBudgetRepository
    {
        private readonly IList<Budget> budgets;

        public BudgetRepository()
        {
            budgets = new List<Budget>();
        }

        public IReadOnlyCollection<Budget> Budgets
        {
            get
            {
                return new ReadOnlyCollection<Budget>(budgets);
            }
        }

        public void Add(Budget budget)
        {
            if (budgets.All(x => x.Name != budget.Name))
            {
                budgets.Add(budget);
            }
        }
    }
}
