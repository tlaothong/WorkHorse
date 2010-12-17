Feature: CreatePlayerAccount
	In order to create player account
	As a system
	I want to create player account information

@record_mock
Scenario Outline:[CreatePlayerAccount]ระบบได้รับข้อมูล PlayerAccount ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The CreatePlayerAccountExecutor has been created and initialized
	And  Sent player account information: UserName '<UserName>' CardType'<CardType>' AccountNo'<AccountNo>' CVV'<CVV>' ExpireDate'<ExpireDate>'	
	When Call CreatePlayerAccountExecutor() for validate input
	Then  Get null and skip checking trackingID
	
	Examples:
	|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |
	|			|Visa		 |0012214544543212	|3223	|12/31/2011  |
	|Nit		|			 |0012214544543212	|3223	|12/31/2011  |
	|Nit		|Visa		 |001221454454		|3223	|12/31/2011  |
	|Nit		|Visa		 |00122145445455234	|3223	|12/31/2011  |
	|Nit		|Visa		 |0012214544543212	|3		|12/31/2011  |

@record_mock
Scenario:[CreatePlayerAccount]ระบบได้รับข้อมูล PlayerAccount ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The CreatePlayerAccountExecutor has been created and initialized
	And   Sent player account information: UserName 'Nit' CardType'Visa' AccountNo'0012214544543212' CVV'3223' ExpireDate'12/31/2011'	
	And   The system generated TrackingID for CreatePlayerAccount :'DEDE6BFD17484312848E13F26345C597'
	When  Call CreatePlayerAccountExecutor()
	Then  TrackingID for CreatePlayerAccount should be : 'DEDE6BFD17484312848E13F26345C597'
	