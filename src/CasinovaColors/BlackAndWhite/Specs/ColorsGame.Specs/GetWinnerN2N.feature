Feature: N2N Get winner information
	1.Request pay for colors winner information (Silverlight)
		1.1 Check account balance (Silverlight)
		1.2 if this first request substract account balance by 1 dollar (Silverlight)
		1.3 if this second request substract account balance by 0.25 cent (Silverlight)
		1.4 send request pay for colors winner information to server by trackingID and roundID (Silverlight)
	2.Substract account balance by first or second request (Web Server)
		2.1 Generate tracking id (Web Server)
		2.2 Send tracking id to client (Web Server)
		2.3 Send tracking id to back server (Web Server)
	3.Update game information (Web Server)
		3.1 Save Ongoing tracking ID (Web Server)
	4.Get game play information from server (Silverlight)
	5.Check game play information (Silverlight)
	6.Display winner (Silverlight)

Background: 
	Given Create and initialize ShowWinnerPageViewModel and Colors game service
	And Back server have game play information are:
		|TableID	|RoundID	|UserName	|TrackingID									|OnGoingTrackingID						|LastUpdate|
		|9			|11			|sakul		|{955D6ACD-E4E0-4D1C-90AC-F3715BB2685A}		|{955D6ACD-E4E0-4D1C-90AC-F3715BB2685A}	|15-08-2010|
		|10			|12			|sakul		|{77C1905A-CD47-4FB4-BF56-4D8EC739474E}		|{48A4E591-A1EA-4C9D-8D38-623F9EBA3128}	|15-08-2010|

@record_mock
Scenario: Request pay for colors winner information get trackingID accept
	When I press GetWinner( TableID: 9, RoundID: 11 )
	Then the result should be TrackingID: {955D6ACD-E4E0-4D1C-90AC-F3715BB2685A}

@record_mock
Scenario: Request pay for colors winner information but don't have TableID, get null and skip checking trackingID
	When I press GetWinner( TableID: 1, RoundID: 11 )
	Then Get null and skip checking trackingID

@record_mock
Scenario: Request pay for colors winner information but don't have RoundID, get null and skip checking trackingID
	When I press GetWinner( TableID: 9, RoundID: 1 )
	Then Get null and skip checking trackingID

@record_mock
Scenario: Request pay for colors winner information but don't have TableID and RoundID, get null and skip checking trackingID
	When I press GetWinner( TableID: 1, RoundID: 1 )
	Then Get null and skip checking trackingID

@record_mock
Scenario: Request pay for colors winner information but TableID is minus value, get null and skip checking trackingID
	When I press GetWinner( TableID: -1, RoundID: 11 )
	Then Get null and skip checking trackingID

@record_mock
Scenario: Request pay for colors winner information but RoundID is minus value, get null and skip checking trackingID
	When I press GetWinner( TableID: 9, RoundID: -1 )
	Then Get null and skip checking trackingID

@record_mock
Scenario: Request pay for colors winner information but TableID and RoundID is minus value, get null and skip checking trackingID
	When I press GetWinner( TableID: -1, RoundID: -1 )
	Then Get null and skip checking trackingID