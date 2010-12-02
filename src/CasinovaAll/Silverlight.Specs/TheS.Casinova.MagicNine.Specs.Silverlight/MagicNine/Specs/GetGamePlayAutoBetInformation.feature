Feature: N2N Get list game play auto bet information
	1.Game has display list active game rounds finish (Silverlight)
	2.Send request get list game play information indentify by username to web server (Silverlight)
	3.List game play information where owner name and username is match (Web Server)
	4.Send game play information back to client (Web Server)
	5.Display game play information (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and MagicNine game service
	And Back service have active game rounds are:
		|RoundID|WinnerPoint	|
		|1		|9				|
		|2		|99				|
		|3		|999			|
		|4		|9999			|
	And Web server have game play auto bet information are
		|UserName	|RoundID	|Amount	|Interval	|StratTrackingID						|
		|Sakul		|1			|30		|60			|{200BEB34-FD59-4F8E-A258-C654BD5105D9}	|
		|Sakul		|2			|560	|1			|{15BEFAE8-C361-4A5F-8048-3E6381BEA71E}	|
		|Sakul		|4			|10245	|3600		|{337466C7-652B-4F8B-92B0-571BE53D460E}	|
	When Send request GetListActiveGameRounds() to web server

@record_mock
Scenario: Request auto bet informations, get auto bet informations
	When Send request GetListGamePlayAutoBet( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|RoundID	|WinnerPoint	|Amount	|Interval	|StratTrackingID						|
		|1			|9				|30		|60			|{200BEB34-FD59-4F8E-A258-C654BD5105D9}	|
		|2			|99				|560	|1			|{15BEFAE8-C361-4A5F-8048-3E6381BEA71E}	|
		|3			|999			|0		|0			|{00000000-0000-0000-0000-000000000000}	|
		|4			|9999			|10245	|3600		|{337466C7-652B-4F8B-92B0-571BE53D460E}	|
		
@record_mock
Scenario: Request auo bet but web server not fount username
	When Send request GetListGamePlayAutoBet( 'Mary' )
	Then Tables in GamePlayViewModel display game play information are
		|RoundID	|WinnerPoint	|Amount	|Interval	|StratTrackingID						|
		|1			|9				|0		|0			|{00000000-0000-0000-0000-000000000000}	|
		|2			|99				|0		|0			|{00000000-0000-0000-0000-000000000000}	|
		|3			|999			|0		|0			|{00000000-0000-0000-0000-000000000000}	|
		|4			|9999			|0		|0			|{00000000-0000-0000-0000-000000000000}	|

@record_mock
Scenario: Request auto bet informations, get auto bet informations more than 1 request
	When Send request GetListGamePlayAutoBet( 'Sakul' )
	And Send request GetListGamePlayAutoBet( 'Sakul' )
	And Send request GetListGamePlayAutoBet( 'Sakul' )
	And Send request GetListGamePlayAutoBet( 'Sakul' )
	And Send request GetListGamePlayAutoBet( 'Sakul' )
	And Send request GetListGamePlayAutoBet( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|RoundID	|WinnerPoint	|Amount	|Interval	|StratTrackingID						|
		|1			|9				|30		|60			|{200BEB34-FD59-4F8E-A258-C654BD5105D9}	|
		|2			|99				|560	|1			|{15BEFAE8-C361-4A5F-8048-3E6381BEA71E}	|
		|3			|999			|0		|0			|{00000000-0000-0000-0000-000000000000}	|
		|4			|9999			|10245	|3600		|{337466C7-652B-4F8B-92B0-571BE53D460E}	|