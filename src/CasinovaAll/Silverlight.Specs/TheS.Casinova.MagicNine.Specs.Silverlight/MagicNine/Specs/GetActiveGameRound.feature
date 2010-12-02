Feature: N2N Get active game round
	1.Game table page loaded (Silverlight)
	2.Game has create and initialize game play viewmodel and game service (Silverlight)
	3.Send request GetListActiveGameRounds to web server (Silverlight)
	4.Web server get request (Web Server)
		4.1 Web server have list active game rounds (Web Server)
			4.1.1 List active game rounds (Web server)
			4.1.2 Send list active game rounds back to client (Web Server)
		4.2 Web server don't have list active game round (Web Server)
			4.2.1 Send empty list active game round back to client (Web Server)
	5.Create game table from list active game rounds and display game tables (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and MagicNine game service

@record_mock
Scenario: Request active game rounds, get active game rounds
	Given Back service have active game rounds are:
		|RoundID|WinnerPoint	|
		|1		|9				|
		|2		|99				|
		|3		|999			|
		|4		|9999			|
	When Send request GetListActiveGameRounds() to web server
	Then Tables in GamePlayViewModel has create from ListActivegameRounds
		|RoundID|WinnerPoint	|
		|1		|9		|
		|2		|99		|
		|3		|999	|
		|4		|9999	|


@record_mock
Scenario: Request active game rounds,web server don't have game active
	Given Back service have active game rounds are:
		|RoundID|WinnerPoint	|
	When Send request GetListActiveGameRounds() to web server
	Then Tables in GamePlayViewModel has create from ListActivegameRounds
		|RoundID|WinnerPoint	|

@record_mock
Scenario: Request active game rounds more than one request
	Given Back service have active game rounds are:
		|RoundID|WinnerPoint	|
		|1		|9				|
		|2		|99				|
		|3		|999			|
		|4		|9999			|
	When Send request GetListActiveGameRounds() to web server
	And Send request GetListActiveGameRounds() to web server
	And Send request GetListActiveGameRounds() to web server
	And Send request GetListActiveGameRounds() to web server
	Then Tables in GamePlayViewModel has create from ListActivegameRounds
		|RoundID|WinnerPoint	|
		|1		|9		|
		|2		|99		|
		|3		|999	|
		|4		|9999	|
