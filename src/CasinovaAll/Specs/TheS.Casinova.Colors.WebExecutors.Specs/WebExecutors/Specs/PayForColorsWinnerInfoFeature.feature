Feature: PayForColorsWinnerInformation
	In order to pay for colors winner information 
	As a system
	I want to sent information for pay colors winner

@record_mock
Scenario Outline: ระบบได้รับข้อมูล PayForColorsWinnerInformation ระบบทำการตรวจสอบข้อมูล เพื่อ generate trackingID เพื่อส่งข้อมูลไปยัง back server ต่อไป
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	When Call PayForColorsWinnerInfoExecutor(userName '<UserName>' RoundID '<RoundID>')
	Then  The system can generate trckingID for pay colors winner information
	Then  The system can't generate trackingID for  pay colors winner information

Examples:
	|UserName	|RoundID	|
	|Nit	 	|4			|
	|Nit	 	|-2			|
	|		 	|4			|
	

