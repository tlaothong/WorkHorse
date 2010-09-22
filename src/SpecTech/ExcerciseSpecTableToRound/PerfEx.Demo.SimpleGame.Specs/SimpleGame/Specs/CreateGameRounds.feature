Feature: Create Game Rounds
	In order to create round from table configuration
	As an Administrator
	I want to read the configuration and create the neccessary rounds.

@record_mock
Scenario: Create GameRounds from the table configuration
	Given The GameTableConfigurator has been created and initialized
	And the table configuration set 'config1' has the following data
		|TableID	|GameDuration	|Interval	|
		|1			|20				|5			|
		|2			|20				|5			|
		|3			|20				|5			|
	And the active GameRounds are
		|TableID	|RoundID	|StartTime		|EndTime		|
		|1			|5			| 10:00			| 10:20			|
		|2			|6			| 10:05			| 10:25			|
	And Expect result should be add 
		|TableID	|RoundID	|StartTime		|EndTime		|
		|3			|7			| 10:10			| 10:30			|
		|1			|8			| 10:15			| 10:35			|

	When call CreateGameRounds('config1', 1)
	Then the result rounds should be saved to the ICreateGameRound.Create() with data
		|TableID	|RoundID	|StartTime		|EndTime		|
		|1			|5			| 10:00			| 10:20			|
		|2			|6			| 10:05			| 10:25			|
		|3			|7			| 10:10			| 10:30			|
		|1			|8			| 10.15			| 10.35			|

@record_mock
Scenario: Create GameRounds from the table configuration2 that interval value not same at all
	Given The GameTableConfigurator has been created and initialized
	And the table configuration set 'config2' has the following data
		|TableID	|GameDuration	|Interval	|
		|1			|20				|5			|
		|2			|20				|10			|
		|3			|20				|7			|
	And the active GameRounds are
		|TableID	|RoundID	|StartTime		|EndTime		|
		|1			|5			| 10:00			| 10:20			|
		|2			|6			| 10:05			| 10:30			|
	And Expect result should be add 
		|TableID	|RoundID	|StartTime		|EndTime		|
		|3			|7			| 10:15			| 10:35			|
		|1			|8			| 10:25			| 10:45			|

	When call CreateGameRounds('config2', 1)
	Then the result rounds should be saved to the ICreateGameRound.Create() with data
		|TableID	|RoundID	|StartTime		|EndTime		|
		|1			|5			| 10:00			| 10:20			|
		|2			|6			| 10:05			| 10:25			|
		|3			|7			| 10:15			| 10:35			|
		|1			|8			| 10:22			| 10:42			|

@record_mock
Scenario: Create GameRounds from the table configuration3 that interval value not same at all
	Given The GameTableConfigurator has been created and initialized
	And the table configuration set 'config2' has the following data
		|TableID	|GameDuration	|Interval	|
		|1			|20				|5			|
		|2			|20				|10			|
		|3			|20				|7			|
	And the active GameRounds are
		|TableID	|RoundID	|StartTime		|EndTime		|
		|1			|5			| 10:00			| 10:20			|
		|2			|6			| 10:05			| 10:30			|
	And Expect result should be add 
		|TableID	|RoundID	|StartTime		|EndTime		|
		|3			|7			| 10:15			| 10:35			|
		|1			|8			| 10:25			| 10:45			|
		|2			|9			| 10:50			| 11:10			|

	When call CreateGameRounds('config2', 1)
	Then the result rounds should be saved to the ICreateGameRound.Create() with data
		|TableID	|RoundID	|StartTime		|EndTime		|
		|1			|5			| 10:00			| 10:20			|
		|2			|6			| 10:05			| 10:25			|
		|3			|7			| 10:15			| 10:35			|
		|1			|8			| 10:25			| 10:45			|
		|2			|9			| 10:50			| 11:10			|

