Feature: StartAutoBet
	In order to ให้ผู้เล่นลงพนันได้ต่อเนื่อง และไม่ต้องเฝ้าอยู่ที่หน้าเกมส์
	As a User
	I want ให้ Server หักเงินลงพนันให้ผู้เล่นโดยอัตโนมัติ
	
@record_mock
Scenario:[StartAutoBet]ระบบได้รับข้อมูลการลงเดิมพันแบบอัตโนมัติ ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The StartAutoBetExecutor has been created and initialized
	And   Sent StartAutoBetInformation UserName 'Bebo' RoundID '3' Amount '50' Interval '2' TotalAmount '100' 
	And   The system generated TrackingID for start auto bet:'955D6ACDE4E04D1C90ACF3715BB2685A'
	When  Call StartAutoBetExecutor() 
	Then  TrackingID for StartAutoBet should be :'955D6ACDE4E04D1C90ACF3715BB2685A'

@record_mock
Scenario Outline:[StartAutoBet]ระบบได้รับข้อมูลการลงเดิมพันแบบอัตโนมัติ ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The StartAutoBetExecutor has been created and initialized
	And   Sent StartAutoBetInformation UserName '<UserName>' RoundID '<RoundID>' Amount '<Amount>' Interval '<Interval>' TotalAmount '<TotalAmount>'
	When  Call StartAutoBetExecutor() for validation
	Then  StartAutoBet get null and skip checking trackingID 
  Examples:
	|UserName	|RoundID	|Amount	|Interval	|TotalAmount|
	|			|1			|1		|10			|20			| 
	|Nit		|-1			|1		|1			|200		|
	|Nit		|6			|1		|1			|22			|
	|Nit		|1			|10		|1			|20			|
	|Nit		|1			|1		|0			|20			|
	|Nit		|4			|500	|5			|200		|
