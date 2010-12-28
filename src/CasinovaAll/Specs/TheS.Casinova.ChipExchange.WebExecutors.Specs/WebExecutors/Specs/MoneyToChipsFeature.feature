Feature: MoneyToChips
	In order to money to chips exchange
	As a system
	I want to sent ExchangeInformation to back server

@record_mock
Scenario:[MoneyToChips]ระบบได้รับข้อมูลครบ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตถูกต้อง ระบบส่งข้อมูลไป back server ได้  
	Given The MoneyToChipsExecutor has been created and initialized
	And  Server has player account information as:
		|AccountType|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059300146	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000041804	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|
	
	And Sent AccountType 'Primary' UserName'Boy' the player's account should recieved
	And The chips exchange information for money to chips :
		|UserName	|Amount	|AccountType|CardType	 |AccountNo			|CVV	| ExpireDate |FirstName|LastName|
		|Boy		|1000	|Primary	|Visa		 |4943129059300146	|0253	|10/31/2010	 |Pongsak  |SriPanya|

	And  Expected executed MoneyToChipsCommand
	When Call MoneyToChipsExecutor (AccountType 'Primary' Amonut '1000' UserName'Boy') for money to chips
	Then The system can sent chips exchange information to back server #MoneyToChips

@record_mock
Scenario:[MoneyToChips]ระบบได้รับข้อมูลครบ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToChipsExecutor has been created and initialized
	And  Server has player account information as:
		|AccountType|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059021346	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000041804	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|

	And  Sent AccountType 'Primary' UserName'Boy' the player's account should recieved
	When Call MoneyToChipsExecutor (AccountType 'Primary' Amonut '1000' UserName'Boy') for money to chips
	Then The system can't sent chips exchange information to back server #MoneyToChips

@record_mock
Scenario:[MoneyToChips]ระบบไม่ได้รับข้อมูล AccountType ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตได้_MoneyToChips 
	Given The MoneyToChipsExecutor has been created and initialized
	When  Call MoneyToChipsExecutor (AccountType '' Amonut '1000' UserName'Boy') for money to chips
	Then  The system can't sent chips exchange information to back server #MoneyToChips

@record_mock
Scenario:[MoneyToChips]ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตได้_MoneyToChips 
	Given The MoneyToChipsExecutor has been created and initialized
	When  Call MoneyToChipsExecutor (AccountType 'Primary' Amonut '1000' UserName'') for money to chips
	Then  The system can't sent chips exchange information to back server #MoneyToChips

@record_mock
Scenario:[MoneyToChips]ระบบไม่ได้รับข้อมูล Amount ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตได้_MoneyToChips 
	Given The MoneyToChipsExecutor has been created and initialized
	When  Call MoneyToChipsExecutor (AccountType 'Primary' Amonut '' UserName'Boy') for money to chips
	Then  The system can't sent chips exchange information to back server #MoneyToChips