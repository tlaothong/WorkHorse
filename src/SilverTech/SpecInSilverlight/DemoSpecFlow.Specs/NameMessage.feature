Feature: Simple Name Message
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Enter name and got message
	Given I have entered name 'John'
	When I press Submit
	Then the result should be 'Hello, John.' on the screen

Scenario: Enter name and got message for Tom
	Given I have entered name 'Tom'
	When I press Submit
	Then the result should be 'Hello, Tom.' on the screen

Scenario: Check Name has notify propery changed
	Given I registered to PropertyChanged
	And I have entered name 'John'
	Then the notification should be raised for Name

Scenario: Check Message has notify propery changed
	Given I registered to PropertyChanged
	When I press Submit
	Then the notification should be raised for Message