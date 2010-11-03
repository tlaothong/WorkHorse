Feature: MoneyToBonusChips
	In order to exchange money to bonus chips
	As a back server
	I want to be payment exhcange cost by credit card and given some bonus chips to player

@record_mock
Background: 
	Given (MoneyToBonusChips)server has exchange setting information as:
	|Name		|MinChipToMoneyExchange	|MinMoneyToChipExchange |MoneyToChipRate |MoneyToBonusChipRate |ChipToBonusChipRate |VoucherToBonusChipRate	|
	|exchange1	|1000					|1000					|1				 |2					   |1					|1						|									
	|Boy		|2000					|2000					|1				 |2					   |1.5					|1						|				

	And (MoneyToBonusChips)server has player account information as:
	|UserName	|FirstName	|LastName	|AccountType	|CardType	|AccountNo		|CVV	|ExpireDate	|Active	|
	|OhAe		|Sirinarin	|AAA		|Primary		|VISA		|123445677891	|1234	|2009/12	|True	|
	|OhAe		|Siriwasan	|AAA		|Secondary		|Mastercard	|852612246578	|5135	|2009/9		|True	|
	|Nit		|Nittaya	|BBB		|Primary		|Mastercard	|551654787921	|1549	|2009/10	|True	|

	And (MoneyToBonusChips)server has MLN information as:
	|UserName	|Bonus		|
	|OhAe		|200		|
	|Nit		|2000		|
	|Boy		|420		|

@record_mock
Scenario: ผู้เล่นแลกเงินเป็นชิฟตาย บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนเงินมากกว่าจำนวนขั้นต่ำ, ระบบตรวจสอบบัตรเครดิตเพื่อชำระเงินและเพิ่มชิฟตายให้กับผู้เล่น
	Given The MoneyToBonusChipsExecutor has been created and initialized
	And sent UserName: 'OhAe' the MLN information should recieved
	And (MoneyToBonusChips)sent ExchangeSettingName: 'exchange1' the exchange setting should recieved 
	And (MoneyToBonusChips)exchange amount: '2000' should be more than minimum exchange rate
	And sent UserName: 'OhAe', AccountType: 'Primary' the player account information should recieved
	And the PayExchangeEngine should be call and complete transaction sent UserName: 'OhAe', Amount: '2000', CardType: 'VISA', FistName: 'Sirinarin', LastName: 'AAA', AccountNo: '123445677891', CVV: '1234', ExpireDate: '2009/12'
	And the user bonus chips should be adding(UserName: 'OhAe', Amount:'8000')
	When call MoneyToBonusChipsExecutor(UserName: 'OhAe', Amount: '4000', AccountType: 'Secondary')
	Then the result should be update

Scenario: ผู้เล่นแลกเงินเป็นชิฟตาย บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนน้อยกว่าจำนวนขั้นต่ำ, ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task

Scenario: ผู้เล่นแลกเงินเป็นชิฟตาย บัตรเครดิตของผู้เล่นไม่ถูกต้อง ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task
