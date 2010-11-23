Feature: N2N Bet
	1.Player insert amount and select Color for bet and click bet button (Silverlight)
	2.Save player action in PayLog, subtract account balance and display waiting status (Silverlight)
	3.Send Bet identify by username, roundID, amount and color to web server (Silverlight)
	4.Web server generate trakingID and send it back to client (Web Server)
	5.Save trackingID into PayLog and sent trackingID to Observer for follow lot until found this trackingID (Silverlight)
	6.Send request get list game play information to web server (Silverlight)
	7.Server list game play information and send it back to client (Web Server)
	8.Display game play information TotalAmountOfBlack, TotalAmountOfWhite and Winner (Silverlight)
	9.If OnGoingTrackingID not equal TrackingID and PayLog count low than one repeat step 5 (Silverlight)
	10.Delete trackingID in PayLog (Silverlight)
	11.If observer don't follow anything, remove waiting state (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and Colors game service
	And Setup trackingID for bet {E8481A68-7F9F-4466-B7B8-1355ED2D32C6}

@record_mock
Scenario: Bet button has click save player action in PayLog
	When Click Bet black amount=30 in game round=15
	Then PayLog count='1' are 
	And Lot of TrackingID='{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}' Is Retrieved
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|

@record_mock
Scenario: Bet button has click more than one, save player action in PayLog
	When Click Bet black amount=30 in game round=15
	And Click Bet black amount=45 in game round=15
	And Click Bet black amount=50 in game round=15
	And Click Bet black amount=55 in game round=15
	And Click Bet black amount=1 in game round=15
	Then PayLog count='5' are 
	And Lot of TrackingID='{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}' Is Retrieved
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|
		|15			|45		|Black	|
		|15			|50		|Black	|
		|15			|55		|Black	|
		|15			|1		|Black	|

@record_mock
Scenario: Bet button has click more than one and difference colors, save player action in PayLog
	When Click Bet black amount=30 in game round=15
	And Click Bet white amount=45 in game round=15
	And Click Bet white amount=50 in game round=15
	And Click Bet black amount=55 in game round=15
	And Click Bet white amount=1 in game round=15
	Then PayLog count='5' are 
	And Lot of TrackingID='{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}' Is Retrieved
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|
		|15			|45		|White	|
		|15			|50		|White	|
		|15			|55		|Black	|
		|15			|1		|White	|

@record_mock
Scenario: Bet button has click more than one and difference roundID, save player action in PayLog
	When Click Bet black amount=30 in game round=15
	And Click Bet black amount=45 in game round=16
	And Click Bet black amount=50 in game round=17
	And Click Bet black amount=55 in game round=18
	And Click Bet black amount=1 in game round=19
	Then PayLog count='5' are 
	And Lot of TrackingID='{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}' Is Retrieved
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|
		|16			|45		|Black	|
		|17			|50		|Black	|
		|18			|55		|Black	|
		|19			|1		|Black	|

@record_mock
Scenario: Bet button has click more than one and difference roundID and colors, save player action in PayLog
	When Click Bet white amount=30 in game round=15
	And Click Bet black amount=45 in game round=16
	And Click Bet white amount=50 in game round=17
	And Click Bet white amount=55 in game round=18
	And Click Bet black amount=1 in game round=19
	And Click Bet black amount=100 in game round=15
	Then PayLog count='6' are 
	And Lot of TrackingID='{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}' Is Retrieved
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|White	|
		|16			|45		|Black	|
		|17			|50		|White	|
		|18			|55		|White	|
		|19			|1		|Black	|
		|15			|100	|Black	|