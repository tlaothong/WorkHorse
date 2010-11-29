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
		|UserName	|TableID|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBetAmountOfBlack	|TotalBetAmountOfWhite	|Winner	|
		|Zazzy		|5		|16			|{EC3DACCA-3474-4FCA-B1F6-112E043A5C44}	|{EC3DACCA-3474-4FCA-B1F6-112E043A5C44}	|72						|565					|Black	|
		|Zazzy		|6		|17			|{EB4A0CEB-9766-4E33-B932-D16246039808}	|{EB4A0CEB-9766-4E33-B932-D16246039808}	|55						|21						|Black	|
		|Zazzy		|7		|18			|{3424E571-F05F-47AF-ACCA-0EF095A9A883}	|{3424E571-F05F-47AF-ACCA-0EF095A9A883}	|43						|44						|Black	|
		|Sakul		|1		|12			|{EADA0D2A-0F50-4BDA-8CB5-0E937D163A84}	|{9D559F32-A146-40DE-8FA5-CF0600394692}	|100					|20						|Black	|
		|Sakul		|1		|12			|{58D6267D-AAEC-4CAD-B1EF-DB861C9D5603}	|{58D6267D-AAEC-4CAD-B1EF-DB861C9D5603}	|150					|20						|Black	|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{63089E73-26AD-4034-A07F-97B6F9DD89A5}	|0						|71						|Black	|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{FCA0EA8F-1C7B-4EF1-A9B9-7357E4C25FCC}	|9						|71						|Black	|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{5107D995-51BD-494C-87C1-44E29D701DE3}	|9						|71						|Black	|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{6B6017D0-A709-4AA3-81AD-20FD483C2D79}	|20						|71						|Black	|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{6B6017D0-A709-4AA3-81AD-20FD483C2D79}	|140					|71						|Black	|

@record_mock
Scenario: Web server have game play information match
	When Send request GetListGamePlayInformation( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|12		|170	|150			|20				|

@record_mock
Scenario: Web server don't have game play information match
	When Send request GetListGamePlayInformation( 'Mary' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|

@record_mock
Scenario: Web server have multi game play information match
	When Send request GetListGamePlayInformation( 'Zazzy' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|16		|637	|72				|565			|
		|17		|76		|55				|21				|
		|18		|87		|43				|44				|

@record_mock
Scenario: Send request get TrackingID and OnGoingTrackingID is match
	When Send request GetListGamePlayInformation( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|12		|170	|150			|20				|

@record_mock
Scenario: TrackingID and OnGoingTrackingID is not match, request until match
	Given Web service execute new bet are
		|UserName	|TableID|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBetAmountOfBlack	|TotalBetAmountOfWhite	|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{888B4811-BD2A-44CD-8360-D62CC9E577FA}	|145					|71						|
		|Miolynet	|4		|15			|{91FFE007-9030-4F94-84DF-05729B120019}	|{840DBB7D-3EE8-4EA5-8300-D67139F1CD69}	|160					|71						|
		|Miolynet	|4		|15			|{5F4C2F9C-D2C1-4EB3-ADAD-A7BF557E80BF}	|{5F4C2F9C-D2C1-4EB3-ADAD-A7BF557E80BF}	|175					|90						|
	When Send request GetListGamePlayInformation( 'Miolynet' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Amount	|TotalBetBlack	|TotalBetWhite	|
		|15		|265	|175			|90				|