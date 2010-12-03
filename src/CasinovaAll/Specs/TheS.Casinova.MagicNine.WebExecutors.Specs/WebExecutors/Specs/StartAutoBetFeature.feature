Feature: StartAutoBet
	In order to start auto bet
	As a system
	I want to sent StartAutoBet information to back server

@record_mock
Scenario Outline:[StartAutoBet]ระบบได้รับข้อมูลการลงเดิมพันแบบอัตโนมัติ ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The StartAutoBetExecutor has been created and initialized
	And   Sent StartAutoBetInformation userName'<UserName>', roundId '<RoundID>',amount '<Amount>', Interval '<Interval>'
	When  Call StartAutoBetExecutor() for validation
	Then  Get null and skip checking trackingID for start auto bet

  Examples:
	|UserName	|RoundID	|Amount	|Interval	|
	|			|1			|100	|10			|
	|Nit		|0			|100	|10			|
	|Nit		|1			|-100	|1			|
	|Nit		|1			|100	|0			|
	
@record_mock
Scenario:[StartAutoBet]ระบบได้รับข้อมูลการลงเดิมพันแบบอัตโนมัติ ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The StartAutoBetExecutor has been created and initialized
	And   Sent StartAutoBetInformation userName'Bebo', roundId '2',amount '50', Interval '2'
	And   The system generated TrackingID for start auto bet:'955D6ACDE4E04D1C90ACF3715BB2685A'
	When  Call StartAutoBetExecutor() 
	Then  TrackingID for start auto bet should be :'955D6ACDE4E04D1C90ACF3715BB2685A'
