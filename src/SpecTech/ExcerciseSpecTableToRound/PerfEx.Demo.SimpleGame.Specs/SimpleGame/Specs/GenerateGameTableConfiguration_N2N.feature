Feature: N2N Generate GameTable Configuration
	In order to avoid silly mistakes and repetitive tasks
	As a lazy Administrator
	I want to generate the table configurations from simple values

Scenario: Generate GameTable from simple values
	Given The GameTableConfigurator has been created and initialized
	When call GenerateTableConfiguration(tableCount: 4, gameDuration: 20, gameInterval: 5)
	Then the result should be equivalent to the following table

		|GameDuration	|Interval	|
		|20				|5			|
		|20				|5			|
		|20				|5			|
		|20				|5			|
