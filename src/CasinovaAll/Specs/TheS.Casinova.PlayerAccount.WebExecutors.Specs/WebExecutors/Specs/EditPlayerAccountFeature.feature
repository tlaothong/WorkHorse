Feature: EditplayerAccount
	In order to edit player account
	As a system
	I want to edit player account information

@record_mock
Scenario Outline:[EditPlayerAccount]ระบบได้รับข้อมูล PlayerAccount ที่มีการแก้ไข ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The EditPlayerAccountExecutor has been created and initialized
	And   Sent UserName '<UserName>' AccountType'<AccountType>' CardType'<CardType>' AccountNo'<AccountNo>' CVV'<CVV>' ExpireDate'<ExpireDate>'	
	When  Call EditPlayerAccountExecutor() for validate input
	Then  Get null and skip checking trackingID for edit player account
	
	Examples:
	|UserName	|AccountType |CardType	 |AccountNo			 |CVV	| ExpireDate |
	|			|Primary	 |Visa		 |0012214544543212	 |3223	|12/31/2011  |
	|Nit		|			 |Visa		 |0012214544543212	 |3223	|12/31/2011  |
	|Nit		|Primary	 |			 |0012214544543212	 |3223	|12/31/2011  |
	|Nit		|Primary	 |Visa		 |001221454454		 |3223	|12/31/2011  |
	|Nit		|Primary	 |Visa		 |0012214544543212	 |3		|12/31/2011  |
	|Nit		|Primary	 |Visa		 |001221454454321278 |3223	|12/31/2011  |

@record_mock
Scenario:[EditPlayerAccount]ระบบได้รับข้อมูล PlayerAccount ที่มีการแก้ไข ระบบทำการตรวจสอบข้อมูล มีการกรอกข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The EditPlayerAccountExecutor has been created and initialized
	And   Sent UserName 'Nit' AccountType'Primary' CardType'Visa' AccountNo'1557423113245675' CVV'1234' ExpireDate'12/31/2010'	
	And   The system generated TrackingID for EditPlayerAccount :'DEDE6BFD17484312848E13F26345C597'
	When  Call EditPlayerAccountExecutor() 
	Then  TrackingID for EditPlayerAccount should be : 'DEDE6BFD17484312848E13F26345C597'
