Feature: Bet
	In order to bet colors game
	As a system
	I want to get trackingID to return client and sent bet information to back server

@record_mock
Scenario Outline:[Bet]ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The BetColorsExecutor has been created and initialized
	And   Bet Informations as : UserName '<UserName>' RoundID '<RoundID>', ActionType '<ActionType>', Amount '<Amount>'
	When  Call BetColorsExecutor() for validate bet information
	Then  Get null and skip checking trackingID

	Examples:
	|UserName	|RoundID	|ActionType	|Amount	|
	|Nit	 	|4			| White		|-50	|
	|Nit	 	|4			|			|50		|
	|Nit	 	|-2			| White		|50		|
	|		 	|4			| White		|50		|

@record_mock
Scenario:[Bet]ระบบได้รับข้อมูลการลงเดิมพันในเกม colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The BetColorsExecutor has been created and initialized
	And   Bet Informations as : UserName 'Nit' RoundID '3', ActionType 'White', Amount '300'
	And   The system generated TrackingID:'955D6ACDE4E04D1C90ACF3715BB2685A'
	When  Call BetColorsExecutor() 
	Then  TrackingID should be :'955D6ACDE4E04D1C90ACF3715BB2685A'