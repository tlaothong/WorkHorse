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
		|TableID	|RoundID	|UserName	|TrackingID	|OnGoingTrackingID	|LastUpdate|
		|9			|11			|sakul		|2d5e2		|2d5e2				|15-08-2010|

@record_mock
Scenario: Request pay for colors winner information get trackingID accept
	Given Server respond TrackingID: 2d5e2
	When I press GetWinner( TableID: 9, RoundID: 11 )
	Then the result should be TrackingID: 2d5e2
