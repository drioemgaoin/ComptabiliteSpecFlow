Feature: ComptabiliteSpecFlow
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given a budget
		| Name		| Amount	|
		| Budget1	| 50		|

Scenario: Calculate net value with more expenses than expected
	Given I spent 30£ for the "Budget1"
	And I spent 40£ for the "Budget1"
	When I press compute
	Then the net value should display -20£ for the budget "Budget1"

Scenario: Calculate net value with exactly expenses expected
	Given I spent 20£ for the "Budget1"
	And I spent 30£ for the "Budget1"
	When I press compute
	Then the net value should display 0£ for the budget "Budget1"

Scenario: Calculate net value with less expenses than expected
	Given I spent 10£ for the "Budget1"
	And I spent 20£ for the "Budget1"
	When I press compute
	Then the net value should display 20£ for the budget "Budget1"