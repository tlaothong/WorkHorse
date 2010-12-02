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
	And Back service have active game rounds are:
		|RoundID|StartTime				|EndTime				|
		|1		|2010-11-17 09:00:00	|2010-11-17 09:15:00	|
		|2		|2010-11-17 09:15:00	|2010-11-17 09:30:00	|
		|3		|2010-11-17 09:30:00	|2010-11-17 09:45:00	|
	And Setup web service trackingID for bets
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
		|{A301887F-DF03-4151-AD50-D6C1C7218736}	|
		|{2BEC0C07-975A-4B73-859E-87450CCADE14}	|
		|{4DDB378C-9C75-4E96-BB19-D61FD93207C8}	|
		|{FDAFEA76-CC7C-4C95-86EA-72393C5954A0}	|
		|{098FCF3A-B002-4206-A61F-E6CD765100F5}	|
	And Web server have game play information are
		|UserName	|TableID|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBetAmountOfBlack	|TotalBetAmountOfWhite	|Winner	|
		|Sakul		|1		|1			|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}	|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}	|100					|20						|Black	|
		|Sakul		|2		|2			|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}	|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}	|100					|20						|White	|
		|Sakul		|3		|3			|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}	|{CF24E43D-49FA-482B-9AD2-DCF0159F0C41}	|100					|20						|White	|
	When Send request GetListActiveGameRounds() to web server

@record_mock
Scenario: Bet button has click save player action in PayLog
	When Click Bet black amount=30 in game round=1
	Then PayLog count='1'
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|1			|30		|Black	|
	And Bet Lot has Retrieved are
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
	And PayLog has empty

@record_mock
Scenario: Bet button has click more than one, save player action in PayLog
	When Click Bet black amount=30 in game round=15
	And Click Bet black amount=45 in game round=15
	And Click Bet black amount=50 in game round=15
	And Click Bet black amount=55 in game round=15
	And Click Bet black amount=1 in game round=15
	Then PayLog count='5' 
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|
		|15			|45		|Black	|
		|15			|50		|Black	|
		|15			|55		|Black	|
		|15			|1		|Black	|
	And Bet Lot has Retrieved are
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
		|{A301887F-DF03-4151-AD50-D6C1C7218736}	|
		|{2BEC0C07-975A-4B73-859E-87450CCADE14}	|
		|{4DDB378C-9C75-4E96-BB19-D61FD93207C8}	|
		|{FDAFEA76-CC7C-4C95-86EA-72393C5954A0}	|
	And PayLog has empty

@record_mock
Scenario: Bet button has click more than one and difference colors, save player action in PayLog
	When Click Bet black amount=30 in game round=15
	And Click Bet white amount=45 in game round=15
	And Click Bet white amount=50 in game round=15
	And Click Bet black amount=55 in game round=15
	And Click Bet white amount=1 in game round=15
	Then PayLog count='5'
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|
		|15			|45		|White	|
		|15			|50		|White	|
		|15			|55		|Black	|
		|15			|1		|White	|
	And Bet Lot has Retrieved are
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
		|{A301887F-DF03-4151-AD50-D6C1C7218736}	|
		|{2BEC0C07-975A-4B73-859E-87450CCADE14}	|
		|{4DDB378C-9C75-4E96-BB19-D61FD93207C8}	|
		|{FDAFEA76-CC7C-4C95-86EA-72393C5954A0}	|
	And PayLog has empty

@record_mock
Scenario: Bet button has click more than one and difference roundID, save player action in PayLog
	When Click Bet black amount=30 in game round=15
	And Click Bet black amount=45 in game round=16
	And Click Bet black amount=50 in game round=17
	And Click Bet black amount=55 in game round=18
	And Click Bet black amount=1 in game round=19
	Then PayLog count='5' 
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|
		|16			|45		|Black	|
		|17			|50		|Black	|
		|18			|55		|Black	|
		|19			|1		|Black	|
	And Bet Lot has Retrieved are
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
		|{A301887F-DF03-4151-AD50-D6C1C7218736}	|
		|{2BEC0C07-975A-4B73-859E-87450CCADE14}	|
		|{4DDB378C-9C75-4E96-BB19-D61FD93207C8}	|
		|{FDAFEA76-CC7C-4C95-86EA-72393C5954A0}	|
	And PayLog has empty

@record_mock
Scenario: Bet button has click more than one and difference roundID and colors, save player action in PayLog
	When Click Bet white amount=30 in game round=15
	And Click Bet black amount=45 in game round=16
	And Click Bet white amount=50 in game round=17
	And Click Bet white amount=55 in game round=18
	And Click Bet black amount=1 in game round=19
	And Click Bet black amount=100 in game round=15
	Then PayLog count='6' 
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|White	|
		|16			|45		|Black	|
		|17			|50		|White	|
		|18			|55		|White	|
		|19			|1		|Black	|
		|15			|100	|Black	|
	And Bet Lot has Retrieved are
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
		|{A301887F-DF03-4151-AD50-D6C1C7218736}	|
		|{2BEC0C07-975A-4B73-859E-87450CCADE14}	|
		|{4DDB378C-9C75-4E96-BB19-D61FD93207C8}	|
		|{FDAFEA76-CC7C-4C95-86EA-72393C5954A0}	|
		|{098FCF3A-B002-4206-A61F-E6CD765100F5}	|
	And PayLog has empty

@record_mock
Scenario: Bet more than one, lot not retriev (1 case)
	When Click Bet black amount=30 in game round=15
	And Click Bet black amount=45 in game round=15
	And Click Bet black amount=50 in game round=15
	Then PayLog count='3' 
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|Black	|
		|15			|45		|Black	|
		|15			|50		|Black	|
	And Bet Lot has Retrieved are
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
		|{A301887F-DF03-4151-AD50-D6C1C7218736}	|
	And PayLog have 1 record for looking trackingID in lot

@record_mock
Scenario: Bet more than one, lot not retriev (more than 1 wait lot trackingID)
	When Click Bet white amount=30 in game round=15
	And Click Bet black amount=45 in game round=16
	And Click Bet white amount=50 in game round=17
	And Click Bet white amount=55 in game round=18
	And Click Bet black amount=1 in game round=19
	And Click Bet black amount=100 in game round=15
	Then PayLog count='6' 
	And Paylog have save information are
		|RoundID	|Amount	|Colors	|
		|15			|30		|White	|
		|16			|45		|Black	|
		|17			|50		|White	|
		|18			|55		|White	|
		|19			|1		|Black	|
		|15			|100	|Black	|
	And Bet Lot has Retrieved are
		|TrackingID								|
		|{E8481A68-7F9F-4466-B7B8-1355ED2D32C6}	|
		|{A301887F-DF03-4151-AD50-D6C1C7218736}	|
	And PayLog have 4 record for looking trackingID in lot