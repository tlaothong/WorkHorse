Feature: RangeBet
	In order to Range bet
	As a system
	I want to sent range bet information to back server
		
@record_mock
Scenario:[RangeBet]ระบบได้รับข้อมูล RangeBet ถูกต้อง ระบบสามารถ generate trackingID และส่งข้อมูลไปยัง back server ได้
	Given The RangeBetExecutor has been created and initialized
	And   Sent UserName'Nayit' RoundID '1' FromAmount'1' ThruAmount'20'
	And   TrackingID for RangeBet is '4A3D921113824255ABA59FCC6A4EC168'
	When  Call RangeBetExecutor()
	Then  TrackingID for RangeBet should be :'4A3D921113824255ABA59FCC6A4EC168'	

@record_mock
Scenario Outline:[RangeBet]ระบบได้รับข้อมูล RangeBet ไม่ถูกต้อง ระบบไม่สามารถ generate trackingID และส่งข้อมูลไปยัง back server ได้
	Given The RangeBetExecutor has been created and initialized
	And   Sent UserName'<UserName>' RoundID '<RoundID>' FromAmount'<FromAmount>' ThruAmount'<ThruAmount>' for Range bet validation
	When  Call RangeBetExecutor() for validate input
	Then  RangeBet get null and skip checking trackingID	

	Examples:
			|UserName	|RoundID	|FromAmount	|ThruAmount	|
			|			|1			|150		|200		|
			|Nayit		|-1			|89			|98			|
			|Nayit		|2			|0			|40			|
			|Nayit		|2			|10			|0			|
			|Nayit		|2			|10			|5			|