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
		|UserName	|TableID|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBetAmountOfBlack	|TotalBetAmountOfWhite	|
		|Zazzy		|5		|16			|{EC3DACCA-3474-4FCA-B1F6-112E043A5C44}	|{EC3DACCA-3474-4FCA-B1F6-112E043A5C44}	|72						|565					|
		|Zazzy		|6		|17			|{EB4A0CEB-9766-4E33-B932-D16246039808}	|{EB4A0CEB-9766-4E33-B932-D16246039808}	|55						|21						|
		|Zazzy		|7		|18			|{3424E571-F05F-47AF-ACCA-0EF095A9A883}	|{3424E571-F05F-47AF-ACCA-0EF095A9A883}	|43						|44						|
		|Sakul		|1		|12			|{EADA0D2A-0F50-4BDA-8CB5-0E937D163A84}	|{9D559F32-A146-40DE-8FA5-CF0600394692}	|100					|20						|
		|Sakul		|1		|12			|{58D6267D-AAEC-4CAD-B1EF-DB861C9D5603}	|{58D6267D-AAEC-4CAD-B1EF-DB861C9D5603}	|150					|20						|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{63089E73-26AD-4034-A07F-97B6F9DD89A5}	|0						|71						|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{FCA0EA8F-1C7B-4EF1-A9B9-7357E4C25FCC}	|9						|71						|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{5107D995-51BD-494C-87C1-44E29D701DE3}	|9						|71						|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{6B6017D0-A709-4AA3-81AD-20FD483C2D79}	|20						|71						|
		|Miolynet	|4		|15			|{6B6017D0-A709-4AA3-81AD-20FD483C2D79}	|{6B6017D0-A709-4AA3-81AD-20FD483C2D79}	|140					|71						|

@record_mock
Scenario: Send request get list game play information to web server 
web server have any game play information is owner name and username match
	When Send request GetListGamePlayInformation( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|12		|170	|150			|20				|

@record_mock
Scenario: Send request get list game play information to web server 
web server don't have any game play information is owner name and username match
	When Send request GetListGamePlayInformation( 'Mary' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|

@record_mock
Scenario: Send request get list game play information to web server 
web server have any game play information is owner name and username match and multi tableID, roundID
	When Send request GetListGamePlayInformation( 'Zazzy' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|16		|637	|72				|565			|
		|17		|76		|55				|21				|
		|18		|87		|43				|44				|

@record_mock
Scenario: Send request get list game play information to web server 
TrackingID and OnGoingTrackingID is not match, it request get list game play information until TrackingID and OnGoingTrackingID match
	When Send request GetListGamePlayInformation( 'Miolynet' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|15		|211	|140			|71				|

@record_mock
Scenario: Send request get list game play information to web server 
TrackingID and OnGoingTrackingID is match
	When Send request GetListGamePlayInformation( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|12		|170	|150			|20				|