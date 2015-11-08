using System;
using System.Collections.Generic;
using System.Linq;
using ComptabiliteSpecFlow.Model;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using TechTalk.SpecFlow;

namespace ComptabiliteSpecFlow.Tests
{
    [Binding]
    public class ComptabiliteSpecFlowSteps
    {
        private ComptabiliteService service;
        private Mock<IBudgetRepository> budgetRepositoryMock;
        private IFixture fixture;

        [BeforeScenario]
        public void Initialization()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());

            budgetRepositoryMock = fixture.Freeze<Mock<IBudgetRepository>>();

            service = fixture.Create<ComptabiliteService>();
        }

        [Given(@"a budget")]
        public void GivenABudget(Table table)
        {
            var budgets = (from row in table.Rows 
                    let budgetName = row["Name"] 
                    let amount = decimal.Parse(row["Amount"]) 
                select new Budget(budgetName, amount)).ToList();

            budgetRepositoryMock.Setup(x => x.Budgets)
                    .Returns(budgets);
        }

        [Given(@"I spent (.*)£ for the ""(.*)""")]
        public void GivenAnExpense(string amount, string budget)
        {
            var debitAmount = decimal.Parse(amount);

            var flux = new Flow(budget, DateTime.Now, debitAmount, FlowType.Debit, "description");
            service.Add(flux);
        }

        [When(@"I press compute")]
        public void WhenIPressCompute()
        {
            service.Compute();
        }

        [Then(@"the net value should display (.*)£ for the budget ""(.*)""")]
        public void ThenTheNetValueShouldDisplay(string amount, string budgetName)
        {
            var budget = service.Get(budgetName);
            Assert.That(budget.NetValue, Is.EqualTo(Convert.ToDecimal(amount)));
        }
    }
}
