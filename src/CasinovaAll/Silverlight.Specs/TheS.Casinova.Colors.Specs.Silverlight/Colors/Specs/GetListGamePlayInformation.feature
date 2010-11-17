Feature: N2N Get list game play information
	1.Game has display list active game rounds finish (Silverlight)
	2.Send request get list game play information indentify by username to web server (Silverlight)
	3.List game play information where owner name and username is match (Web Server)
	4.Send game play information back to client (Web Server)
	5.Display game play information (Silverlight)
	6.Looking TrackingID and OnGoingTrackingID (Silverlight)
		6.1 OnGoingTrackingID and TrackingID not match (Silverlight)
			6.1.1 Display waiting icon (Silverlight)
			6.1.2 Request get list game play information until TrackingID and OnGoingTrackingID is match (Silverlight)
		6.2 OnGoingTrackingID and TrackingID match (Silverlight)
			6.2.1 Remove waiting icon (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and Colors game service
	And Web server have game play information are
		|UserName	|TableID|RoundID|TrackingID								|OnGoingTrackingID						|TotalBetAmountOfBlack	|TotalBetAmountOfWhite	|
		|Sakul		|1		|12		|{EADA0D2A-0F50-4BDA-8CB5-0E937D163A84}	|{EADA0D2A-0F50-4BDA-8CB5-0E937D163A84}	|100					|20						|
		|Miolynet	|4		|15		|{91FFE007-9030-4F94-84DF-05729B120019}	|{5107D995-51BD-494C-87C1-44E29D701DE3}	|0						|71						|
		|Sakul		|1		|12		|{EADA0D2A-0F50-4BDA-8CB5-0E937D163A84}	|{EADA0D2A-0F50-4BDA-8CB5-0E937D163A84}	|150					|20						|
		|Miolynet	|4		|15		|{91FFE007-9030-4F94-84DF-05729B120019}	|{5107D995-51BD-494C-87C1-44E29D701DE3}	|9						|71						|
		|Miolynet	|5		|16		|{3A1C868C-867C-4FD3-82E2-A9CBDF7EC828}	|{3A1C868C-867C-4FD3-82E2-A9CBDF7EC828}	|1024					|768					|
		|Miolynet	|4		|15		|{91FFE007-9030-4F94-84DF-05729B120019}	|{5107D995-51BD-494C-87C1-44E29D701DE3}	|9						|71						|

@record_mock
Scenario: Send request get list game play information to web server 
web server have any game play information is owner name and username match
	When Send request GetListGamePlayInformation( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|12		|290	|250			|40				|

@record_mock
Scenario: Send request get list game play information to web server 
web server don't have any game play information is owner name and username match
	When Send request GetListGamePlayInformation( 'Mary' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|

@record_mock
Scenario: Send request get list game play information to web server 
TrackingID and OnGoingTrackingID is not match
	When Send request GetListGamePlayInformation( 'Miolynet' )
	And TrackingID and OnGoingTrackingID not match repeat request GetListGamePlayInformation until TrackingID and OnGoingTrackingID is match
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|15		|231	|18				|213			|
		|16		|1792	|1024			|768			|

@record_mock
Scenario: Send request get list game play information to web server 
TrackingID and OnGoingTrackingID is match
	When Send request GetListGamePlayInformation( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|12		|290	|250			|40				|

@record_mock
Scenario: Send request get list game play information  but username is null to web server, Incorrect
	When Send request GetListGamePlayInformation( 'null' )
	Then Display error message

@record_mock
Scenario: Send request get list game play information  but username is empty to web server, Incorrect
	When Send request GetListGamePlayInformation( '' )
	Then Display error message