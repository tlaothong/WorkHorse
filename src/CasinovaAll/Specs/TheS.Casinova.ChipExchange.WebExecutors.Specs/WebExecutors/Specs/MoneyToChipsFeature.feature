Feature: MoneyToChips
	In order to money to chips exchange
	As a system
	I want to sent ExchangeInformation to back server

@record_mock
Scenario:[MoneyToChips]ระบบได้รับข้อมูลครบ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตถูกต้อง ระบบส่งข้อมูลไป back server ได้  
	Given The MoneyToChipsExecutor has been created and initialized
	And  Server has player account information as:
		|UserName	|AccountType|CardType	 |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Boy		|Primary	|Visa		 |4111111111111111	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Boy		|Secondary	|Master	Card |5105105105105100	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|
	
	And Sent AccountType 'Primary' UserName'Boy' Amount '1000' for money to chips exchange
	And Sent AccountType 'Primary' UserName'Boy' the player's account for money to chips exchange should recieved	
	When Call MoneyToChipsExecutor () 
	Then The system can sent money to chips exchange information to back server 

@record_mock
Scenario:[MoneyToChips]ระบบได้รับข้อมูลครบ ระบบตรวจสอบข้อมูลบัตรเครดิต ข้อมูลบัตรเครดิตไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป back server ได้  
	Given The MoneyToChipsExecutor has been created and initialized
	And  Server has player account information as:
		|AccountType|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|FirstName|LastName|
		|Primary	|Boy		|Visa		 |4943129059021346	|0253	|10/31/2010	 |True	|Pongsak  |SriPanya|
		|Secondary	|Boy		|Master	Card |5221000000041804	|4830	|11/30/2010  |True	|Pongsak  |SriPanya|

	And Sent AccountType 'Primary' UserName'Boy' Amount '100' for money to chips exchange
	And Sent AccountType 'Primary' UserName'Boy' the player's account for money to chips exchange should recieved	
	When Call MoneyToChipsExecutor () for validation
	Then The system can't sent money to chips exchange information to back server 

@record_mock
Scenario:[MoneyToChips]ระบบไม่ได้รับข้อมูล AccountType ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตเพื่อแลกเงินเป็นชิพต่อไปได้ 
	Given The MoneyToChipsExecutor has been created and initialized
	And   Sent AccountType '' UserName'Boy' Amount '100' for money to chips exchange
	When  Call MoneyToChipsExecutor () for validation
	Then The system can't sent money to chips exchange information to back server 


@record_mock
Scenario:[MoneyToChips]ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตเพื่อแลกเงินเป็นชิพต่อไปได้  
	Given The MoneyToChipsExecutor has been created and initialized
	And   Sent AccountType 'Primary' UserName'' Amount '100' for money to chips exchange
	When  Call MoneyToChipsExecutor () for validation
	Then The system can't sent money to chips exchange information to back server 

@record_mock
Scenario:[MoneyToChips]ระบบได้รับข้อมูล Amount ไม่ถูกต้อง ระบบไม่สามารถตรวจสอบข้อมูลบัตรเครดิตเพื่อแลกเงินเป็นชิพต่อไปได้ 
	Given The MoneyToChipsExecutor has been created and initialized
	And   Sent AccountType 'Primary' UserName'Boy' Amount '-1' for money to chips exchange
	When  Call MoneyToChipsExecutor () for validation
	Then The system can't sent money to chips exchange information to back server