Feature: N2N Get winner
	1.Player click get winner button (Silverlight)
	2.Check account balance (Silverlight)
		2.1 Balance lowthan cost of winner information display error end (Silverlight)
	3.Save player action in PayLog, subtract account balance and display waiting status (Silverlight)
	4.Send get winner identify by username, roundID to web server (Silverlight)
	5.Web server generate trakingID and send it back to client (Web Server)
	6.Save trackingID into PayLog and sent trackingID to Observer for follow lot until found this trackingID (Silverlight)
	7.Send request get list game play information to web server (Silverlight)
	8.Server list game play information and send it back to client (Web Server)
	9.Display game play information TotalAmountOfBlack, TotalAmountOfWhite and Winner (Silverlight)
	10.If OnGoingTrackingID not equal TrackingID and PayLog count low than one repeat step 5 (Silverlight)
	11.Delete trackingID in PayLog (Silverlight)
	12.If observer don't follow anything, remove waiting state (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and Colors game service

@record_mock
Scenario: Get winner button has click save player action in PayLog
	Given Setup trackingID for getwinner {60AD85F6-3978-48AA-9286-E5A7344B77EC}
	When Click get winner in game round 20 
	Then PayLog has save RoundID='20', Count='1'
	And Lot of TrackingID='{60AD85F6-3978-48AA-9286-E5A7344B77EC}' Is Retrieved
	And PayLog has empty

@record_mock
Scenario: Get winner button has click save player action in PayLog 3 times
	Given Setup web service trackingID are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
	When Click get winner in game round 20 
	And Click get winner in game round 20 
	And Click get winner in game round 20 
	Then PayLog has save RoundID='20', Count='3'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
	And PayLog has empty

@record_mock
Scenario: Get winner 3 times using another game roundID
	Given Setup web service trackingID are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
	When Click get winner in game round 20 
	And Click get winner in game round 21 
	And Click get winner in game round 22 
	Then PayLog has save RoundID='20', Count='1'
	And PayLog has save RoundID='21', Count='1'
	And PayLog has save RoundID='22', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
	And PayLog has empty

@record_mock
Scenario: Get winner 6 times using another game roundID
	Given Setup web service trackingID are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
		|{50EA817A-512E-469E-982F-8377F0EF84A6}		|
	When Click get winner in game round 20 
	And Click get winner in game round 21 
	And Click get winner in game round 22 
	And Click get winner in game round 22 
	And Click get winner in game round 23 
	And Click get winner in game round 22 
	Then PayLog has save RoundID='20', Count='1'
	And PayLog has save RoundID='21', Count='1'
	And PayLog has save RoundID='22', Count='3'
	And PayLog has save RoundID='23', Count='1'
	And Lot of TrackingIDs has Retrieved are
		|TrackingID									|
		|{60AD85F6-3978-48AA-9286-E5A7344B77EC}		|
		|{A82FA8E6-1BCC-443E-A61A-F81B8B4DED83}		|
		|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}		|
		|{2C8EE9D1-A106-4216-AA57-E44554F822A8}		|
		|{89D5613E-8007-4AAA-8A4D-AF16014B2D5F}		|
		|{50EA817A-512E-469E-982F-8377F0EF84A6}		|
	And PayLog has empty