Feature: MoneyToBonusChips
	In order to money to BonusChips exchange
	As a system
	I want to sent ExchangeInformation to back server

@record_mock
Background:
	Given Server has bonus point information as :
		|UserName	|Bonus	|
		|Nit		|500	|
		|Ae			|900	|
		|Boy		|1000	|

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสมีพอสามารถแลกชิพตายได้ ระบบตรวจสอบเลขบัตรเครดิต เลขบัตรเครดิตถูกต้อง ระบบส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And Server has player account information for money to bonus chips:
		|CardType	|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059300146	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000041804	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|
	
	And Sent UserName'Boy' the player's bonus point should recieve
	And Sent CardType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieve
	And The chips exchange information for money to bonus chips :
		|UserName	|Amount	|CardType	|AccountType |AccountNo			|CVV	| ExpireDate |FirstName|LastName|
		|Boy		|1000	|Primary	|Visa		 |4943129059300146	|0253	|10/31/2010	 |Pongsak  |SriPanya|

	And Expected executed MoneyToBonusChipsCommand
	When Call MoneyToBonusChipsExecutor (CardType 'Primary' Amonut '1000' UserName'Boy') for money to bonus chips
	Then The system can sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสมีพอสามารถแลกชิพตายได้ ระบบตรวจสอบเลขบัตรเครดิต เลขบัตรเครดิตไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And  Server has player account information for money to bonus chips:
		|CardType	|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059873928	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000234534	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|

	And  Sent UserName'Boy' the player's bonus point should recieve
	And  Sent CardType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieve
	When Call MoneyToBonusChipsExecutor (CardType 'Primary' Amonut '1000' UserName'Boy') for money to bonus chips
	Then The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสไม่เพียงพอที่จะแลกชิพตายได้ ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Boy' the player's bonus point should recieve
	When  Call MoneyToBonusChipsExecutor (CardType 'Primary' Amonut '1500' UserName'Boy') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล CardType ระบบไม่สามารถตรวจสอบเลขบัตรเครดิตได้_MoneyToBonusChips
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When  Call MoneyToBonusChipsExecutor (CardType '' Amonut '1000' UserName'Boy') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถตรวจสอบเลขบัตรเครดิตได้_MoneyToBonusChips 
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When  Call MoneyToBonusChipsExecutor (CardType 'Primary' Amonut '1000' UserName'') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล Amount ระบบไม่สามารถตรวจสอบเลขบัตรเครดิตได้_MoneyToBonusChips 
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When  Call MoneyToBonusChipsExecutor (CardType 'Primary' Amonut '' UserName'Boy') for money to bonus chips
	Then  The system can't sent chips exchange information to back server #MoneyToBonusChips