Feature: Generate table configuration
	As a system
	I want to generate table config

@mytag
Scenario: paramiter are correct
	Given amountOfTable is 12 , durationTime is 60 min and nextGen is 5 min 
	When I press create
	Then the result should have amount of table list is equal 12
