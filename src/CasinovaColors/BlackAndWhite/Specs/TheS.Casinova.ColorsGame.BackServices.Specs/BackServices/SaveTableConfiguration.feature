Feature: Save Table Configuration to the data store
	In order to use the table configuration again and again
	As back server
	I want to save the table configuration to the persistence store

@record_mock
Scenario: Save GameTable configuration to the data store
	Given The SaveTableConfiguration has been created and initialized
	And Expect the tables should be saved by calling IColorsGameDataAccess.Create()
	When call SaveTableConfiguration(name: 'config1', tables: as follows)
		|TableID	|GameDuration	|Interval	|
		|1			|20				|5			|
		|2			|20				|5			|
		|3			|20				|5			|
		|4			|20				|5			|
	Then the tables should be saved by calling IColorsGameDataAccess.Create()

@record_mock
Scenario: Save GameTable configuration to the data store2
	Given The SaveTableConfiguration has been created and initialized
	And Expect the tables should be saved by calling IColorsGameDataAccess.Create()
	When call SaveTableConfiguration(name: 'config2', tables: as follows)
		|TableID	|GameDuration	|Interval	|
		|1			|30				|15			|
		|2			|20				|10			|
		|3			|10				|5			|
		|4			|20				|10			|
		|5			|20				|10			|
	Then the tables should be saved by calling IColorsGameDataAccess.Create()

