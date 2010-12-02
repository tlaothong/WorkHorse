Feature: N2N Bet
	1.Player have click Bet button (Silverlight)
	2.Save pay log (Silverlight)
	3.Sent Bet to Web server (Silverlight)
	4.Web server generate trackingID and sent it back to client (Web Server)
	5.Sent trackingID to observer follow trackingID in Lot (Silverlight)
	6.Observer found trackingID in lot remove pay log (Silverlight)
	7.Request get list bet log from web server (Silverlight)
	8.List bet log and sent it back to client (Web Server)
	9.Display bet log information (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and MagicNine game service
	And Back service have active game rounds are:
		|RoundID|WinnerPoint	|
		|1		|9				|
		|2		|99				|
		|3		|999			|
		|4		|9999			|
	And Web server have list bet log are
		|RoundID	|UserName	|BetOrder	|BetDateTime			|
		|1			|Sakul		|72			|2010-11-17 09:00:00	|
		|1			|Sakul		|11			|2010-11-17 09:00:30	|
		|2			|Sakul		|91			|2010-11-17 09:00:59	|
		|3			|Sakul		|0			|2010-11-17 09:01:00	|
		|1			|Miolynet	|12			|2010-11-17 10:11:00	|
		|1			|Miolynet	|13			|2010-11-18 07:23:50	|
	And Setup web service trackingID for Bet are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
		|{50EA817A-512E-469E-982F-8377F0EF84A6}		|
	When Send request GetListActiveGameRounds() to web server

@record_mock
Scenario: Bet normal case round 1
	When I press bet in game round=1
	Then PayLog has save RoundID='1', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
	And PayLog has empty

@record_mock
Scenario: Bet normal case round 2
	When I press bet in game round=2
	Then PayLog has save RoundID='2', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
	And PayLog has empty

@record_mock
Scenario: Bet normal case round 3
	When I press bet in game round=3
	Then PayLog has save RoundID='3', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
	And PayLog has empty

@record_mock
Scenario: Bet more than 1 
	When I press bet in game round=4
	And I press bet in game round=4
	And I press bet in game round=4
	And I press bet in game round=4
	Then PayLog has save RoundID='4', Count='4'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
	And PayLog has empty

@record_mock
Scenario: Bet more than 1 difference roundID
	When I press bet in game round=1
	And I press bet in game round=3
	And I press bet in game round=2
	And I press bet in game round=4
	And I press bet in game round=4
	Then PayLog has save RoundID='1', Count='1'
	And PayLog has save RoundID='2', Count='1'
	And PayLog has save RoundID='3', Count='1'
	And PayLog has save RoundID='4', Count='2'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
	And PayLog has empty

@record_mock
Scenario: Bet but lot don't retrieved trackingID
	When I press bet in game round=3
	Then PayLog has save RoundID='3', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
	Then PayLog has save RoundID='3', Count='1'

@record_mock
Scenario: Bet more than 1 difference roundID and lot don't retrieved trackingID
	When I press bet in game round=1
	And I press bet in game round=3
	And I press bet in game round=2
	And I press bet in game round=4
	And I press bet in game round=4
	Then PayLog has save RoundID='1', Count='1'
	And PayLog has save RoundID='2', Count='1'
	And PayLog has save RoundID='3', Count='1'
	And PayLog has save RoundID='4', Count='2'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
	And PayLog has save RoundID='1', Count='0' 
	And PayLog has save RoundID='2', Count='0'
	And PayLog has save RoundID='3', Count='1'
	And PayLog has save RoundID='4', Count='2'