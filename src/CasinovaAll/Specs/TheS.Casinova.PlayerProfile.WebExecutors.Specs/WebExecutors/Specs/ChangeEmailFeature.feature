Feature: ChangeEmail
	In order to change email
	As a system
	I want to change new email

@record_mock
Scenario Outline: ระบบได้รับข้อมูลอีเมลใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล และ update ข้อมูลต่อไป
	Given The ChangeEmailExecutor has been created and initializedr
	And  Server has email information of Nit :
		|UserName	|Email					|
		|Nit		|nayit_nit@hotmail.com	|

	And Sent UserName '<UserName>' OldEmail '<OldEmail>' NewEmail '<NewEmail>'
	When Call ChangeEmailExecutor
	Then The system can update new email
	Then The system can't update new email

Examples:
	|UserName|OldEmail				|NewEmail				   | 
	|Nit	 |nayit_nit@hotmail.com	|nittaya@perfenterprise.com|
	|Nit	 |nayit_n_@hotmail.com	|nittaya@perfenterprise.com|
	|Nit	 |nayit_nit@hotmail.com	|nittaya.com			   |
	|Nit	 |nayit1311				|nittaya@perfenterprise.com|
	|		 |nayit_nit@hotmail.com	|nittaya@perfenterprise.com|
	|Nit	 |						|nittaya@perfenterprise.com|
	|Nit	 |nayit_nit@hotmail.com	|						   |