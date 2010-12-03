Feature: N2N Auto bet start
	1.Player have click auto bet start (Silverlight)
	2.Sent auto bet start to web server (Silverlight)
	3.Generate trackingID and sent it back to client (web Server)
	4.Follo trackingID by observer (Silverlight)
	5.Found trackingID decrease amount in auto bet (Silverlight) 
		5.1.If amount int auto bet is zero, remove paylog (Silverlight)
	6.Request get bet log from server (Silverlight)
	7.List bet log and sent it back to client (Web Server)
	8.Display bet log (Silverlight)

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
	And Setup web service trackingID for AutoBet are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
		|{50EA817A-512E-469E-982F-8377F0EF84A6}		|
	When Send request GetListActiveGameRounds() to web server	

@record_mock
Scenario: Auto bet start normal case
	When I press AutoBetStart button in game roundID=1, Amount=1
	And Send request GetListBetlog( 'Sakul' ) RoundID='1'
	Then PayLog has save RoundID='1', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
	And PayLog has empty
	And Auto bet has been turned off in active game roundID=1 and amount=0
	And Dispaly bet log int game roundID=1 are
		|BetOrder	|BetDateTime			|
		|72			|2010-11-17 09:00:00	|
		|11			|2010-11-17 09:00:30	|

@record_mock
Scenario: Auto bet start auto bet amount 2
	When I press AutoBetStart button in game roundID=1, Amount=2
	And Send request GetListBetlog( 'Sakul' ) RoundID='1'
	Then PayLog has save RoundID='1', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
	And PayLog has empty
	And Auto bet has been turned off in active game roundID=1 and amount=0
	And Dispaly bet log int game roundID=1 are
		|BetOrder	|BetDateTime			|
		|72			|2010-11-17 09:00:00	|
		|11			|2010-11-17 09:00:30	|

@record_mock
Scenario: Auto bet start but lot not retrive all
	When I press AutoBetStart button in game roundID=1, Amount=3
	And Send request GetListBetlog( 'Sakul' ) RoundID='1'
	Then PayLog has save RoundID='1', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
	And PayLog has save RoundID='1', Count='1'
	And Auto bet has been turned on in active game roundID=1 and amount=2
	And Dispaly bet log int game roundID=1 are
		|BetOrder	|BetDateTime			|
		|72			|2010-11-17 09:00:00	|
		|11			|2010-11-17 09:00:30	|