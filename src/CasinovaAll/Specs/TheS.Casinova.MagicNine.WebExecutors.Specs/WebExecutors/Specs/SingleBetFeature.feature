Feature: SingleBet
	In order to single bet
	As a system
	I want to get trackingID to return client and sent single bet information to back server

@record_mock
Scenario Outline:[SingleBet]ระบบได้รับข้อมูลการลงเดิมพันในเกม MagicNine ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The SingleBetExecutor has been created and initialized
	And   SingleBet Informations as : UserName '<UserName>' RoundID '<RoundID>'
	When  Call SingleBetExecutor() for validate single bet information
	Then  Get null and skip checking trackingID

	Examples:
	|UserName	|RoundID	|
	|Nit	 	|-2			|
	|		 	|4			|

@record_mock
Scenario:[SingleBet]ระบบได้รับข้อมูลการลงเดิมพันในเกม MagicNine ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The SingleBetExecutor has been created and initialized
	And   SingleBet Informations as : UserName 'Sakanit' RoundID '4'
	And   The system generated TrackingID for SingleBet:'942D2F350FAA4A32870CF9CF9A5C7A2E'
	When  Call SingleBetExecutor() 
	Then  TrackingID for SingleBet should be :'942D2F350FAA4A32870CF9CF9A5C7A2E'