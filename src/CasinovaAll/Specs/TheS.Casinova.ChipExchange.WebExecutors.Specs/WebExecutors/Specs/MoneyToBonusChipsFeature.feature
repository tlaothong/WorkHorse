Feature: MoneyToBonusChips
	In order to money to BonusChips exchange
	As a system
	I want to sent ExchangeInformation to back server

@record_mock
Background:
	Given Server has bonus points information for money to bonus chips exchange:
		|UserName	|Bonus	|
		|Nit		|500	|
		|Ae			|900	|
		|Boy		|1000	|

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสมีเพียงพอสามารถแลกชิพตายได้ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตถูกต้อง ระบบส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And Server has player account information for money to bonus chips exchange:
		|CardType	|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059300146	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000041804	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|
	
	And Sent UserName'Boy' the player's bonus points should recieved
	And Sent AccountType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieved
	And The chips exchange information for money to bonus chips exchange:
		|UserName	|Amount	|CardType	|AccountType |AccountNo			|CVV	| ExpireDate |FirstName|LastName|
		|Boy		|1000	|Primary	|Visa		 |4943129059300146	|0253	|10/31/2010	 |Pongsak  |SriPanya|

	And  Expected executed MoneyToBonusChipsCommand
	When Call MoneyToBonusChipsExecutor (AccountType 'Primary' Amonut '1000' UserName'Boy') for money to bonus chips
	Then The system can sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสมีเพียงพอสามารถแลกชิพตายได้ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And  Server has player account information for money to bonus chips exchange:
		 |AccountType|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		 |Primary	|Boy		|Visa		 |4943129059873928	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		 |Secondary	|Boy		|Master	Card |5221000000234534	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|

	And  Sent UserName'Boy' the player's bonus points should recieved
	And  Sent AccountType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieved
	When Call MoneyToBonusChipsExecutor (AccountType 'Primary' Amonut '1000' UserName'Boy') for money to bonus chips
	Then The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสไม่เพียงพอที่จะแลกชิพตายได้ ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Boy' the player's bonus points should recieved
	When  Call MoneyToBonusChipsExecutor (AccountType 'Primary' Amonut '1500' UserName'Boy') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล AccountType ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตได้_MoneyToBonusChips
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When  Call MoneyToBonusChipsExecutor (AccountType '' Amonut '1000' UserName'Boy') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตได้_MoneyToBonusChips 
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When  Call MoneyToBonusChipsExecutor (AccountType 'Primary' Amonut '1000' UserName'') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล Amount ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตได้_MoneyToBonusChips 
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When  Call MoneyToBonusChipsExecutor (AccountType 'Primary' Amonut '' UserName'Boy') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips