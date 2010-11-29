Feature: N2N Get bet log
	1.Game play has loaded (Silverlight)
	2.Send request bet log to web server identify by roundID (Silverlight)
	3.List bet log and send it back to client (Web Server)
	4.Display bet log (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and MagicNine game service
	And Web server have list bet log are
		|RoundID	|UserName	|BetOrder	|BetDateTime			|
		|1			|Sakul		|72			|2010-11-17 09:00:00	|
		|1			|Sakul		|11			|2010-11-17 09:00:00	|
		|2			|Sakul		|91			|2010-11-17 09:00:00	|
		|3			|Sakul		|0			|2010-11-17 09:00:00	|
		|1			|Miolynet	|12			|2010-11-17 09:00:00	|
		|1			|Miolynet	|13			|2010-11-17 09:00:00	|

@record_mock
Scenario: Send request get bet log to web server roundID = 1
	When Send request GetListBetlog( 'Sakul' ) RoundID='1'
	Then Dispaly bet log are
		|Round	|BetOrder	|BetDateTime			|
		|1		|72			|2010-11-17 09:00:00	|
		|1		|11			|2010-11-17 09:00:00	|

@record_mock
Scenario: Send request get bet log to web server roundID = 2
	When Send request GetListBetlog( 'Sakul' ) RoundID='2'
	Then Dispaly bet log are
		|Round	|BetOrder	|BetDateTime			|
		|2		|91			|2010-11-17 09:00:00	|

@record_mock
Scenario: Send request get bet log to web server roundID = 3
	When Send request GetListBetlog( 'Sakul' ) RoundID='3'
	Then Dispaly bet log are
		|Round	|BetOrder	|BetDateTime			|
		|3		|0			|2010-11-17 09:00:00	|

@record_mock
Scenario: Send request get bet log (more than 1)
	When Send request GetListBetlog( 'Sakul' ) RoundID='1'
	And Send request GetListBetlog( 'Sakul' ) RoundID='1'
	And Send request GetListBetlog( 'Sakul' ) RoundID='1'
	And Send request GetListBetlog( 'Sakul' ) RoundID='1'
	And Send request GetListBetlog( 'Sakul' ) RoundID='1'
	Then Dispaly bet log are
		|Round	|BetOrder	|BetDateTime			|
		|1		|72			|2010-11-17 09:00:00	|
		|1		|11			|2010-11-17 09:00:00	|

@record_mock
Scenario: Send request get bet log to web server don't have username match
	When Send request GetListBetlog( 'Mary' ) RoundID='1'
	Then Dispaly bet log are
		|Round	|BetOrder	|BetDateTime		|

@record_mock
Scenario: Send request get bet log to web server don't have rounID match
	When Send request GetListBetlog( 'Sakul' ) RoundID='999'
	Then Dispaly bet log are
		|Round	|BetOrder	|BetDateTime		|

@record_mock
Scenario: Send request get bet log to web server RoundID is minus
	When Send request GetListBetlog( 'Sakul' ) RoundID='-1'
	Then Dispaly bet log are
		|Round	|BetOrder	|BetDateTime		|