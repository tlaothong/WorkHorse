Feature: MoneyToChips
	In order to exchange money to chips
	As a back server
	I want to be payment exhcange cost by credit card and given some chips to player

@record_mock
Background: 
	Given (MoneyToChips)server has exchange setting information as:
	|Name		|MinChipToMoneyExchange	|MinMoneyToChipExchange |MoneyToChipRate |MoneyToBonusChipRate |ChipToBonusChipRate |VoucherToBonusChipRate	|
	|exchange1	|1000					|1000					|1				 |1					   |1					|1						|									
	|Boy		|2000					|2000					|1				 |2					   |1.5					|1						|				

	And (MoneyToChips)server has player account information as:
	|UserName	|FirstName	|LastName	|AccountType	|CardType	|AccountNo		|CVV	|ExpireDate	|Active	|
	|OhAe		|Sirinarin	|AAA		|Primary		|VISA		|123445677891	|1234	|2009/12	|True	|
	|OhAe		|Siriwasan	|AAA		|Secondary		|Mastercard	|852612246578	|5135	|2009/9		|True	|
	|Nit		|Nittaya	|BBB		|Primary		|Mastercard	|551654787921	|1549	|2009/10	|True	|

@record_mock
Scenario: ผู้เล่นแลกเงินเป็นชิฟเป็น บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนเงินมากกว่าจำนวนขั้นต่ำ, ระบบตรวจสอบบัตรเครดิตเพื่อชำระเงินและเพิ่มชิฟเป็นให้กับผู้เล่น
	Given The MoneyToChipsExecutor has been created and initialized
	And sent ExchangeSettingName: 'exchange1' the exchange setting should recieved 
	And exchange amount: '2000' should be more than minimum exchange rate
	And sent UserName: 'OhAe', AccountType: 'Primary' the player account information should recieved
	And the PayExchangeEngine should be call and complete transaction sent UserName: 'OhAe', Amount: '2000', CardType: 'VISA', FistName: 'Sirinarin', LastName: 'AAA', AccountNo: '123445677891', CVV: '1234', ExpireDate: '2009/12'
	And the user chips should be adding(UserName: 'OhAe', Amount:'2000')
	When call MoneyToChipsExecutor(UserName: 'OhAe', Amount: '2000', AccountType: 'Primary')
	Then the result should be update

@record_mock
Scenario: ผู้เล่นแลกเงินเป็นชิฟเป็น บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนน้อยกว่าจำนวนขั้นต่ำ, ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToChipsExecutor has been created and initialized
	And sent ExchangeSettingName: 'exchange1' the exchange setting should recieved 
	And exchange amount: '500' should be less than minimum exchange rate
	When call MoneyToChipsExecutor(UserName: 'OhAe', Amount: '500', AccountType: 'Primary')
	Then the result should be update

@record_mock
Scenario: ผู้เล่นแลกเงินเป็นชิฟเป็น บัตรเครดิตของผู้เล่นไม่ถูกต้อง ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task

  



