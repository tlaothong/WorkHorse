Feature: N2N Auto bet stop
	1.Player click auto bet stop (Silverlight)
	2.Sent auto bet stop to web server (Silverlight)
	3.Generate trackingID and sent it back to client (Web Server)
	4.Observer follow trackingID from lot (Silverlight)
	5.Found trackingID change state autobet button to "Start" (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and MagicNine game service
	And Back service have active game rounds are:
		|RoundID|WinnerPoint	|
		|20		|9				|
		|21		|99				|
		|22		|999			|
		|23		|9999			|
		|24		|99999			|
		|25		|999999			|
		|26		|9999999		|
	And Web server have list bet log are
		|RoundID	|UserName	|BetOrder	|BetDateTime			|
		|20			|Sakul		|72			|2010-11-17 09:00:00	|
		|21			|Sakul		|11			|2010-11-17 09:00:30	|
		|22			|Sakul		|91			|2010-11-17 09:00:59	|
		|23			|Sakul		|0			|2010-11-17 09:01:00	|
		|24			|Miolynet	|12			|2010-11-17 10:11:00	|
		|25			|Miolynet	|13			|2010-11-18 07:23:50	|
		|26			|Miolynet	|17			|2010-11-18 07:23:50	|
	And Setup web service trackingID for auto bet stop are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
		|{50EA817A-512E-469E-982F-8377F0EF84A6}		|
		|{37C87086-FFBB-4C9A-87F9-F9A4C0CF6FB0}		|
	When Send request GetListActiveGameRounds() to web server
	

@record_mock
Scenario: Request stop auto bet
	Given Setup Amount=20 in game roundID=20
	When I press AutoBetStop() in game roundID=20
	Then PayLog has save RoundID='20', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
	And PayLog has empty
	And IsAutoBetOn is false, in game roundID=20

@record_mock
Scenario: Request stop auto bet (request more than 1 )
	Given Setup Amount=20 in game roundID=20
	When I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	Then PayLog has save RoundID='20', Count='7'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
		|{50EA817A-512E-469E-982F-8377F0EF84A6}		|
		|{37C87086-FFBB-4C9A-87F9-F9A4C0CF6FB0}		|
	And PayLog has empty
	And IsAutoBetOn is false, in game roundID=20

@record_mock
Scenario: Request stop auto bet (request more than 1 ) difference game roundID
	Given Setup Amount=20 in game roundID=20
	And Setup Amount=20 in game roundID=21
	And Setup Amount=20 in game roundID=22
	And Setup Amount=20 in game roundID=23
	And Setup Amount=20 in game roundID=24
	And Setup Amount=20 in game roundID=25
	And Setup Amount=20 in game roundID=26
	When I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=21
	And I press AutoBetStop() in game roundID=22
	And I press AutoBetStop() in game roundID=23
	And I press AutoBetStop() in game roundID=24
	And I press AutoBetStop() in game roundID=25
	And I press AutoBetStop() in game roundID=26
	Then PayLog has save RoundID='20', Count='1'
	Then PayLog has save RoundID='21', Count='1'
	Then PayLog has save RoundID='22', Count='1'
	Then PayLog has save RoundID='23', Count='1'
	Then PayLog has save RoundID='24', Count='1'
	Then PayLog has save RoundID='25', Count='1'
	Then PayLog has save RoundID='26', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
		|{50EA817A-512E-469E-982F-8377F0EF84A6}		|
		|{37C87086-FFBB-4C9A-87F9-F9A4C0CF6FB0}		|
	And PayLog has empty
	And IsAutoBetOn is false, in game roundID=20
	And IsAutoBetOn is false, in game roundID=21
	And IsAutoBetOn is false, in game roundID=22
	And IsAutoBetOn is false, in game roundID=23
	And IsAutoBetOn is false, in game roundID=24
	And IsAutoBetOn is false, in game roundID=25
	And IsAutoBetOn is false, in game roundID=26

@record_mock
Scenario: Request stop auto bet, lot don't retrive all
	Given Setup Amount=20 in game roundID=20
	When I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	And I press AutoBetStop() in game roundID=20
	Then PayLog has save RoundID='20', Count='7'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
	And PayLog has save RoundID='20', Count='4'
	And IsAutoBetOn is false, in game roundID=20
