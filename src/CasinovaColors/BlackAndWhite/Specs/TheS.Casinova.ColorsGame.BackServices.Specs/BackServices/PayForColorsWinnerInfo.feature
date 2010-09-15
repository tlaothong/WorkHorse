Feature: PayForColorsWinnerInfo
	In order to pay money for winner information
	As a back server
	I want to be decrease player money

@mytag
Scenario: ผู้ใช้มีเงินพอ, ระบบหักเงิน
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
