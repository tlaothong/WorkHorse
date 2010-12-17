Feature: SingleBet
	In order to single bet
	As a system
	I want to sent single bet information to back server
		
@record_mock
Scenario:[SingleBet]ระบบได้รับข้อมูล SingleBet ถูกต้อง ระบบสามารถ generate trackingID และส่งข้อมูลไปยัง back server ได้
	Given The SingleBetExecutor has been created and initialized
	And   Sent UserName'Nayit' RoundID '1' Amount'100'
	And   TrackingID for SibgleBet is '4A3D921113824255ABA59FCC6A4EC168'
	When  Call SingleBetExecutor()
	Then  TrackingID for SingleBet should be :'4A3D921113824255ABA59FCC6A4EC168'	

@record_mock
Scenario Outline:[SingleBet]ระบบได้รับข้อมูล SingleBet ไม่ถูกต้อง ระบบไม่สามารถ generate trackingID และส่งข้อมูลไปยัง back server ได้
	Given The SingleBetExecutor has been created and initialized
	And   Sent UserName'<UserName>' RoundID '<RoundID>' Amount'<Amount>' for single bet validation
	When  Call SingleBetExecutor() for validate input
	Then  SingleBet get null and skip checking trackingID	

	Examples:
			|UserName	|RoundID	|Amount	|
			|			|1			|200	|
			|Nayit		|-1			|89		|
			|Nayit		|2			|0		|