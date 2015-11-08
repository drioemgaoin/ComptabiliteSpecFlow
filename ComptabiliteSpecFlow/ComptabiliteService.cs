using System.Linq;
using ComptabiliteSpecFlow.Model;

namespace ComptabiliteSpecFlow
{
    public class ComptabiliteService
    {
        private readonly IBudgetRepository budgetRepository;

        public ComptabiliteService(
            IBudgetRepository budgetRepository)
        {
            this.budgetRepository = budgetRepository;
        }

        public void Add(Budget budget)
        {
            budgetRepository.Add(budget);
        }

        public void Add(Flow flux)
        {
            var budget = budgetRepository.Budgets.FirstOrDefault(x => x.Name == flux.Budget);
            if (budget != null)
            {
                budget.Add(flux);
            }
        }

        public void Compute()
        {
            foreach (var budget in budgetRepository.Budgets)
            {
                budget.Compute();
            }
        }

        public Budget Get(string budgetName)
        {
            return budgetRepository.Budgets.FirstOrDefault(x => x.Name == budgetName);
        }
    }
}
