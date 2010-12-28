Feature: EditplayerAccount
	In order to edit player account
	As a system
	I want to edit player account information

@record_mock
Scenario Outline:[EditPlayerAccount]ระบบได้รับข้อมูล PlayerAccount ที่มีการแก้ไข ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไปทำการแก้ไขบัญชีผู้ใช้ได้
	Given The EditPlayerAccountExecutor has been created and initialized
	And   Sent UserName '<UserName>' AccountType'<AccountType>' CardType'<CardType>' AccountNo'<AccountNo>' CVV'<CVV>' ExpireDate'<ExpireDate>'	
	When  Call EditPlayerAccountExecutor() for validate input
	Then  Skip credit card validation to edit player account
	
	Examples:
	|UserName	|AccountType |CardType	 |AccountNo			|CVV	| ExpireDate |
	|			|Primary	 |Visa		 |5585067151394716	|3223	|12/31/2011  |
	|Nit		|			 |			 |5585067151394716	|3223	|12/31/2011  |
	|Nit		|Primary	 |Visa		 |001221454454		|3223	|12/31/2011  |
	|Nit		|Primary	 |Visa		 |					|3223	|12/31/2011  |
	|Nit		|Primary	 |Visa		 |55850671513947164	|3223	|12/31/2011  |
	|Nit		|Primary	 |Visa		 |5585067151394716	|3		|12/31/2011  |
	|Nit		|Primary	 |Visa		 |5585067151394716	|3456	|12/31/2011  |
	|Nit		|Primary	 |Visa		 |0012214544542345	|3456	|12/31/2011  |

@record_mock				 
Scenario:[EditPlayerAccount]ระบบได้รับข้อมูล PlayerAccount ที่มีการแก้ไข ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลถูกต้อง ระบบสามารถส่งข้อมูลไปทำการแก้ไขบัญชีผู้ใช้ได้
	Given The EditPlayerAccountExecutor has been created and initialized
	And   Sent UserName 'Nit' AccountType'Primary' CardType'MasterCard' AccountNo'5585067151394716' CVV'1234' ExpireDate'12/31/2010'	
	When  Call EditPlayerAccountExecutor() 
	Then  System can sent credit card information to sent player account to back server
