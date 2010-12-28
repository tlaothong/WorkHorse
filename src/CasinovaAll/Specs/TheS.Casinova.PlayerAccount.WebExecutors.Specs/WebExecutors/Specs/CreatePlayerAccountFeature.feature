Feature: CreatePlayerAccount
	In order to create player account
	As a system
	I want to create player account information to back server

@record_mock
Scenario Outline:[CreatePlayerAccount]ระบบได้รับข้อมูล PlayerAccount ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไปทำการสร้างบัญชีผู้ใช้ได้
	Given The CreatePlayerAccountExecutor has been created and initialized
	And  Sent player account information: UserName '<UserName>' CardType'<CardType>' AccountNo'<AccountNo>' CVV'<CVV>' ExpireDate'<ExpireDate>'	
	When Call CreatePlayerAccountExecutor() for validate input
	Then  Skip credit card validation to create player account
	
	Examples:
	|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |
	|			|Visa		 |5585067151394716	|3223	|12/31/2011  |
	|Nit		|			 |5585067151394716	|3223	|12/31/2011  |
	|Nit		|Visa		 |001221454454		|3223	|12/31/2011  |
	|Nit		|Visa		 |					|3223	|12/31/2011  |
	|Nit		|Visa		 |55850671513947164	|3223	|12/31/2011  |
	|Nit		|Visa		 |5585067151394716	|3		|12/31/2011  |
	|Nit		|Visa		 |5585067151394716	|3456	|12/31/2011  |
	|Nit		|Visa		 |0012214544542345	|3456	|12/31/2011  |

@record_mock
Scenario:[CreatePlayerAccount]ระบบได้รับข้อมูล PlayerAccount ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลถูกต้อง ระบบสามารถส่งข้อมูลไปทำการสร้างบัญชีผู้ใช้ได้
	Given The CreatePlayerAccountExecutor has been created and initialized
	And   Sent player account information: UserName 'Nit' CardType'MasterCard' AccountNo'5585067151394716' CVV'3223' ExpireDate'12/31/2011'	
	When  Call CreatePlayerAccountExecutor()
	Then  System can sent credit card information to create player account to back server 
	