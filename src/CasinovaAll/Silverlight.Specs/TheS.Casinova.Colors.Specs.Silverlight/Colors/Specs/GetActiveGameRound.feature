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
	Given Create and initialize GamePlayViewModel and Colors game service

@record_mock
Scenario: Request active game rounds web server send active list
	Given Back service have active game rounds are:
		|RoundID|StartTime				|EndTime				|
		|1		|2010-11-17 09:00:00	|2010-11-17 09:15:00	|
		|2		|2010-11-17 09:15:00	|2010-11-17 09:30:00	|
		|3		|2010-11-17 09:30:00	|2010-11-17 09:45:00	|
	When Send request GetListActiveGameRounds() to web server
	Then Tables in GamePlayViewModel has create from ListActivegameRounds
		|Name	|Round	|StartTime				|EndTime				|
		|Colors	|1		|2010-11-17 09:00:00	|2010-11-17 09:15:00	|
		|Colors	|2		|2010-11-17 09:15:00	|2010-11-17 09:30:00	|
		|Colors	|3		|2010-11-17 09:30:00	|2010-11-17 09:45:00	|


@record_mock
Scenario: Request active game rounds web server don't have active game rounds
	Given Back service have active game rounds are:
		|RoundID|StartTime				|EndTime				|
	When Send request GetListActiveGameRounds() to web server
	Then Tables in GamePlayViewModel don't create ListActivegameRounds
		|Name	|Round	|StartTime				|EndTime				|

@record_mock
Scenario: Request active game rounds web server send active list (Request more thand 1 request)
	Given Back service have active game rounds are:
		|RoundID|StartTime				|EndTime				|
		|1		|2010-11-17 09:00:00	|2010-11-17 09:15:00	|
		|2		|2010-11-17 09:15:00	|2010-11-17 09:30:00	|
		|3		|2010-11-17 09:30:00	|2010-11-17 09:45:00	|
	When Send request GetListActiveGameRounds() to web server
	And Send request GetListActiveGameRounds() to web server
	And Send request GetListActiveGameRounds() to web server
	And Send request GetListActiveGameRounds() to web server
	And Send request GetListActiveGameRounds() to web server
	Then Tables in GamePlayViewModel has create from ListActivegameRounds
		|Name	|Round	|StartTime				|EndTime				|
		|Colors	|1		|2010-11-17 09:00:00	|2010-11-17 09:15:00	|
		|Colors	|2		|2010-11-17 09:15:00	|2010-11-17 09:30:00	|
		|Colors	|3		|2010-11-17 09:30:00	|2010-11-17 09:45:00	|