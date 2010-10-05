Feature: BetColor
	In order to bet game round
	As a back server
	I want to be update player information and saving bet information

@record_mock
Scenario: BetColor
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
