Feature: ChangeEmail
	In order to change email
	As a system
	I want to change new email

@record_mock
Scenario Outline:[ChangeNewEmail]ระบบได้รับข้อมูลอีเมลใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน email ใหม่ได้
	Given The ChangeEmailExecutor has been created and initialized
	And   Sent UserName '<UserName>' OldEmail '<OldEmail>' NewEmail '<NewEmail>' 
	When  Call ChangeEmailExecutor() for validate input
	Then  Skip call membership service to change new email

Examples:
	|UserName|OldEmail				|NewEmail				   |
	|		 |nayit_nit@hotmail.com	|nittaya@perfenterprise.com|
	|Nit	 |						|nittaya@perfenterprise.com|
	|Nit	 |nayit_nit@hotmail.com	|						   |
	|Nit	 |nayit_nit@hotmail.com	|perfenterprise			   |
	
@record_mock
Scenario:[ChangeNewEmail]ระบบได้รับข้อมูลอีเมลใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The ChangeEmailExecutor has been created and initialized
	And   Sent UserName 'Nit' OldEmail 'nayit_nit@hotmail.com' NewEmail 'nittaya@perfenterprise.com'
	And   Call membership service to validate change email information : UserName 'Nit' OldEmail 'nayit_nit@hotmail.com' NewEmail 'nittaya@perfenterprise.com'
	When  Call ChangeEmailExecutor() 
	Then  Membership service can change new email 

