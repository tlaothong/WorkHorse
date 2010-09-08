Feature: N2N Save Table Configuration to the data store
	In order to use the table configuration again and again
	As an Administrator
	I want to save the table configuration to the persistence store

@record_mock
Scenario: Save GameTable configuration to the data store
	Given The GameTableConfigurator has been created and initialized
	And Expect the tables should be saved by calling ICreateGameTableConfiguration.Create()
	When call SaveTableConfiguration(name: 'config1', tables: as follows)
		|GameDuration	|Interval	|
		|20				|5			|
		|20				|5			|
		|20				|5			|
		|20				|5			|
	Then the tables should be saved by calling ICreateGameTableConfiguration.Create()
