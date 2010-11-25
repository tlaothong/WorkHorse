Feature: N2N Get game statistics
	1.Game timeout (Silverlight)
	2.Send request get game result identify game round by roundID to web server (Silverlight)
	3.Send POT TotalAmountOfBlack and TotablAmountOfWhite where GameRoundID and roundID match back to client (Web Server)
	4.Compare POT between TotalAmountOfBlack and TotalAmountOfWhite for winner (Silverlight)
	5.Display winner, TotalAmountOfBlack and TotalAmountOfWhite (Silverlight)
	6.If player have bet in winner pot gmae has display congratulation and pay award (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and Colors game service
	And Web server have game results are
		|RoundID	|BlackPot	|WhitePot	|HandCount	|
		|1			|1523		|4526		|452		|
		|2			|445		|12399		|1155		|
		|3			|75663		|45266		|5632		|
		|4			|500		|500		|100		|


@record_mock
Scenario: Request game result to web server, server have roundID match (roundID = 1)
	When Request GetGameResult( roundID = '1' )
	Then Game has display game result Winner='Black', BlackPot='1523', WhitePot='4526', Hands='452'

@record_mock
Scenario: Request game result to web server, server have roundID match (roundID = 2)
	When Request GetGameResult( roundID = '2' )
	Then Game has display game result Winner='Black', BlackPot='445', WhitePot='12399', Hands='1155'

@record_mock
Scenario: Request game result to web server, server have roundID match (roundID = 3)
	When Request GetGameResult( roundID = '3' )
	Then Game has display game result Winner='White', BlackPot='75663', WhitePot='45266', Hands='5632'

@record_mock
Scenario: Black pot and White pot are equal, White win
	When Request GetGameResult( roundID = '4' )
	Then Game has display game result Winner='White', BlackPot='500', WhitePot='500', Hands='100'

@record_mock
Scenario: Request game result to web server, server don't have roundID match (roundID = 99)
	When Request GetGameResult( roundID = '99' )
	Then Game result is null

@record_mock
Scenario: Request game result to web server, server don't have roundID match (roundID = -1)
	When Request GetGameResult( roundID = '-1' )
	Then Game result is null