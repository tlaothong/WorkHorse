Feature: ChangeBet
	In order to change bet information
	As a system
	I want to sent change bet information to back server 

@record_mock
Scenario:[ChangeBet]ระบบได้รับข้อมูล ChangeBet ถูกต้อง ระบบสามารถ generate trackingID และส่งข้อมูลไปยัง back server ได้
	Given The ChangeBetExecutor has been created and initialized
	And   Sent ChangeBet information UserName'Nayit' RoundID '1' Amount'100' HandID'3'
	And   TrackingID for ChangeBet is '4A3D921113824255ABA59FCC6A4EC168'
	When  Call ChangeBetExecutor()
	Then  TrackingID for ChangeBet should be :'4A3D921113824255ABA59FCC6A4EC168'	

@record_mock
Scenario Outline:[ChangeBet]ระบบได้รับข้อมูล ChangeBet ไม่ถูกต้อง ระบบไม่สามารถ generate trackingID และส่งข้อมูลไปยัง back server ได้
	Given The ChangeBetExecutor has been created and initialized
	And   Sent ChangeBet information UserName'<UserName>' RoundID '<RoundID>' Amount'<Amount>' HandID'<HandID>' for change bet validation
	When  Call ChangeBetExecutor() for validate input
	Then  ChangeBet get null and skip checking trackingID	

	Examples:
			|UserName	|RoundID	|Amount	|HandID	|
			|			|1			|200	|23		|
			|Nayit		|-1			|89		|23		|
			|Nayit		|2			|0		|23		|
			|Nayit		|2			|45		|-2		|