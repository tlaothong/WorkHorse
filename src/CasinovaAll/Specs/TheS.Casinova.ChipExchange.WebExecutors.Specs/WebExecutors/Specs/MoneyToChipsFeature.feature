Feature: MoneyToChips
	In order to money to chips exchange
	As a system
	I want to sent ExchangeInformation to back server

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบเลขบัตรเครดิต เลขบัตรเครดิตถูกต้อง ระบบส่งข้อมูลไป back server ได้  
	Given The MoneyToChipsExecutor has been created and initialized
	And  Server has player account information as:
		|CardType	|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059300146	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000041804	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|
	
	And Sent CardType 'Primary' UserName'Boy' the player's account should recieve
	And The chips exchange information as :
		|UserName	|Amount	|CardType	|AccountType |AccountNo			|CVV	| ExpireDate |FirstName|LastName|
		|Boy		|1000	|Primary	|Visa		 |4943129059300146	|0253	|10/31/2010	 |Pongsak  |SriPanya|

	And  Expected executed MoneyToChipsCommand
	When Call MoneyToChipsExecutor (CardType 'Primary' Amonut '1000' UserName'Boy') for money to chips
	Then The system can sent chips exchange information to back server #MoneyToChip

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบเลขบัตรเครดิต เลขบัตรเครดิตไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToChipsExecutor has been created and initialized
	And  Server has player account information as:
		|CardType	|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059021346	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000041804	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|

	And  Sent CardType 'Primary' UserName'Boy' the player's account should recieve
	When Call MoneyToChipsExecutor (CardType 'Primary' Amonut '1000' UserName'Boy') for money to chips
	Then The system can't sent chips exchange information to back server #MoneyToChip

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล CardType ระบบไม่สามารถตรวจสอบเลขบัตรเครดิตได้_MoneyToChip 
	Given The MoneyToChipsExecutor has been created and initialized
	When  Call MoneyToChipsExecutor (CardType '' Amonut '1000' UserName'Boy') for money to chips
	Then  The system can't sent chips exchange information to back server #MoneyToChip

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถตรวจสอบเลขบัตรเครดิตได้_MoneyToChip 
	Given The MoneyToChipsExecutor has been created and initialized
	When  Call MoneyToChipsExecutor (CardType 'Primary' Amonut '1000' UserName'') for money to chips
	Then  The system can't sent chips exchange information to back server #MoneyToChip

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล Amount ระบบไม่สามารถตรวจสอบเลขบัตรเครดิตได้_MoneyToChips 
	Given The MoneyToChipsExecutor has been created and initialized
	When  Call MoneyToChipsExecutor (CardType 'Primary' Amonut '' UserName'Boy') for money to chips
	Then  The system can't sent chips exchange information to back server #MoneyToChip