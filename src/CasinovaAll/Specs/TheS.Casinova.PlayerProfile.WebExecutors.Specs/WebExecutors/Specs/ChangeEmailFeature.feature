Feature: ChangeEmail
	In order to change email
	As a system
	I want to change new email

@record_mock
Scenario Outline:[ChangeNewEmail]ระบบได้รับข้อมูลอีเมลใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The ChangeEmailExecutor has been created and initialized
	And   Sent UserName '<UserName>' OldEmail '<OldEmail>' NewEmail '<NewEmail>' 
	When  Call ChangeEmailExecutor() for validate input
	Then  Get null and skip checking trackingID for change email

Examples:
	|UserName|OldEmail				|NewEmail				   |
	|		 |nayit_nit@hotmail.com	|nittaya@perfenterprise.com|
	|Nit	 |						|nittaya@perfenterprise.com|
	|Nit	 |nayit_nit@hotmail.com	|						   |
	|Nit	 |nayit_nit@hotmail.com	|nittaya@perfenterprise.com|
	|Nit	 |nayit_nit@hotmail.com	|nittaya@perfenterprise.com|
	|Nit	 |nayit_nit@hotmail.com	|perfenterprise.com		   |
	
@record_mock
Scenario:[ChangeNewEmail]ระบบได้รับข้อมูลอีเมลใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The ChangeEmailExecutor has been created and initialized
	And   Sent UserName 'Nit' OldEmail 'nayit_nit@hotmail.com' NewEmail 'nittaya@perfenterprise.com'
	And   The system generated TrackingID for change email:'942D2F350FAA4A32870CF9CF9A5C7A2E'
	When  Call ChangeEmailExecutor() 
	Then  TrackingID for change email should be :'942D2F350FAA4A32870CF9CF9A5C7A2E'

