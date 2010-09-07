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
		|TableID	|RoundID	|StartTime	|EndTime	|
		|1			|5			|0:0		|0:0		|
		|2			|6			|0:0		|0:0		|
	When call CreateGameRounds('config1', 1)
	Then the result rounds should be saved to the ICreateGameRound.Create() with data
		|TableID	|RoundID	|StartTime	|EndTime	|
		|1			|5			|0:0		|0:0		|
		|2			|6			|0:0		|0:0		|
		|3			|7			|0:0		|0:0		|
		|1			|8			|0:0		|0:0		|
