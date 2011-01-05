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
Scenario:[MoneyToBonusChips]ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสมีเพียงพอสามารถแลกชิพตายได้ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตถูกต้อง ระบบส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And Server has player account information for money to bonus chips exchange:
		|CardType	|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4111111111111111	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5105105105105100	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|
	
	And Sent UserName'Boy' the player's bonus points should recieved
	And Sent AccountType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieved
	And Sent AccountType 'Primary' Amonut '1000' UserName'Boy' for money to bonuschips exchange
	When Call MoneyToBonusChipsExecutor ()
	Then The system can sent money to bonuschips exchange information to back server

@record_mock
Scenario:[MoneyToBonusChips]ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสมีเพียงพอสามารถแลกชิพตายได้ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And  Server has player account information for money to bonus chips exchange:
		 |AccountType|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		 |Primary	|Boy		|Visa		 |4943129059873928	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		 |Secondary	|Boy		|Master	Card |5221000000234534	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|

	And Sent UserName'Boy' the player's bonus points should recieved
	And Sent AccountType 'Primary' UserName'Boy' the player's account for money to bonus chips should recieved
	And Sent AccountType 'Primary' Amonut '1000' UserName'Boy' for money to bonuschips exchange
	When Call MoneyToBonusChipsExecutor () for validation
	Then The system can't sent money to bonuschips exchange information to back server

@record_mock
Scenario:[MoneyToBonusChips]ระบบได้รับข้อมูลครบ ระบบตรวจสอบโบนัส จำนวนโบนัสไม่เพียงพอที่จะแลกชิพตายได้ ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And Sent UserName'Boy' the player's bonus points should recieved
	And Sent AccountType 'Primary' Amonut '2000' UserName'Boy' for money to bonuschips exchange
	When Call MoneyToBonusChipsExecutor () for validation
	Then The system can't sent money to bonuschips exchange information to back server

@record_mock
Scenario:[MoneyToBonusChips]ระบบไม่ได้รับข้อมูล AccountType ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตเพื่อทำการแลกเงินเป็นชิพตายได้
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And  Sent AccountType '' Amonut '1000' UserName'Boy' for money to bonuschips exchange
	When Call MoneyToBonusChipsExecutor () for validation
	Then The system can't sent money to bonuschips exchange information to back server

@record_mock
Scenario:[MoneyToBonusChips]ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตเพื่อทำการแลกเงินเป็นชิพตายได้ 
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And  Sent AccountType 'Primary' Amonut '1000' UserName'' for money to bonuschips exchange
	When Call MoneyToBonusChipsExecutor () for validation
	Then The system can't sent money to bonuschips exchange information to back server

@record_mock
Scenario:[MoneyToBonusChips]ระบบได้รับข้อมูล Amount ไม่ถูกต้อง ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตเพื่อทำการแลกเงินเป็นชิพตายได้
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And  Sent AccountType 'Primary' Amonut '0' UserName'Boy' for money to bonuschips exchange
	When Call MoneyToBonusChipsExecutor () for validation
	Then The system can't sent money to bonuschips exchange information to back server