Feature: CreatePlayerAccount
	In order to create player account
	As a system
	I want to create player account information

@record_mock
Scenario Outline: ระบบได้รับข้อมูล PlayerAccount ระบบทำการตรวจสอบข้อมูล แล้วส่งข้อมูลไปยัง backserver
	Given The CreatePlayerAccountExecutor has been created and initialized
	And Sent UserName '<UserName>' AccountType'<AccountType>' AccountNo'<AccountNo>' CVV'<CVV>' ExpireDate<ExpireDate>	
	When Call CreatePlayerAccountExecutor
	Then System can sent PlayerAccount to backserver 
	Then System can't sent PlayerAccount to backserver 
	
	Examples:
	|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |
	|Nit		|Visa		 |0012214544543212	|3223	|12/31/2010  |
	|			|Visa		 |0012214544543212	|3223	|12/31/2010  |
	|Nit		|			 |0012214544543212	|3223	|12/31/2010  |
	|Nit		|Visa		 |001221454454		|3223	|12/31/2010  |
	|Nit		|Visa		 |0012214544543212	|3		|12/31/2010  |
	|Nit		|Visa		 |0012214544543212	|3223	|12/31/2005  |