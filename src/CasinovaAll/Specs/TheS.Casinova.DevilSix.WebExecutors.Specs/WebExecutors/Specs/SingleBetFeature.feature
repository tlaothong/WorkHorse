Feature: SingleBet
	In order to ลงเดิมพันเพื่อคำนวนค่าที่ชนะต่อไป
	As a Web server
	I want ตรวจสอบข้อมูลการลงเดิมพัน เพื่อสร้าง trackingID และส่งข้อมูลไปยัง back service


@record_mock
Scenario:[SingleBet]ระบบได้รับข้อมูลการลงเดิมพันด้วยตัวเองของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The SingleBetExecutor has been created and initialized
	And   SingleBet Informations as : UserName 'Sakanit' RoundID '4' Amount '10'
	And   The system generated TrackingID for SingleBet:'942D2F350FAA4A32870CF9CF9A5C7A2E'
	When  Call SingleBetExecutor() 
	Then  TrackingID for SingleBet should be :'942D2F350FAA4A32870CF9CF9A5C7A2E'

	@record_mock
Scenario Outline:[SingleBet]ระบบได้รับข้อมูลการลงเดิมพันด้วยตัวเองของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The SingleBetExecutor has been created and initialized
	And   SingleBet Informations as : UserName '<UserName>' RoundID '<RoundID>' Amount '<Amount>'
	When  Call SingleBetExecutor() for validate single bet information
	Then  SingleBet get null and skip checking trackingID

	Examples:
	|UserName	|RoundID	| Amount |
	|Nit	 	|-2			|1		 |
	|		 	|4			|10		 |
	|Nit	 	|4			|-20	 |
	|		 	|4			|12		 |
