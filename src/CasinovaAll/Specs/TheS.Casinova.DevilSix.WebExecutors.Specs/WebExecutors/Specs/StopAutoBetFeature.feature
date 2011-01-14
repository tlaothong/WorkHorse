Feature: StopAutoBet
	In order to  คืนเงินที่เหลือให้ผู้เล่น
	As a User
	I want  หยุดการทำงานของ AutoBet Engine และคืนเงินให้ผู้เล่น
	
@record_mock
Scenario:[StopAutoBet]ระบบได้รับข้อมูลเพื่อหยุดการลงเดิมพันแบบอัตโนมัติ ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The StopAutoBetExecutor has been created and initialized
	And   Sent StopAutoBetInformation userName'Nit', roundId '4'
	And   The system generated TrackingID for stop auto bet:'955D6ACDE4E04D1C90ACF3715BB2685A'
	When  Call StopAutoBetExecutor() 
	Then  TrackingID for stop auto bet should be :'955D6ACDE4E04D1C90ACF3715BB2685A'

@record_mock
Scenario Outline:[StopAutoBet]ระบบได้รับข้อมูลเพื่อหยุดการลงเดิมพันแบบอัตโนมัติ ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The StopAutoBetExecutor has been created and initialized
	And   Sent StopAutoBetInformation userName'<UserName>', roundId '<RoundID>'
	When  Call StopAutoBetExecutor() for validation
	Then  StopAutoBet get null and skip checking trackingID

  Examples:
	|UserName	|RoundID	|
	|			|1			|
	|Nit		|0			|