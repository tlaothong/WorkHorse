Feature: ChipsToMoney
	In order to exchange chips to money
	As a back server
	I want to be update user profile and sent cheque by user address

@record_mock
Background:
	Given (ChipsToMoney)server has player information as:
	|UserName	|NonRefundable	|Refundable	|
	|OhAe		|500			|1800		|
	|Boy		|700			|726.29		|
	|Nit		|36.99			|383.21		|
	|Au			|150.00			|3761.99	|

		
	Given (ChipsToMoney)server has exchange setting information as:
	|Name		|MinChipToMoneyExchange	|MinMoneyToChipExchange |MoneyToChipRate |MoneyToBonusChipRate |ChipToBonusChipRate |VoucherToBonusChipRate	|
	|Exchange1	|1000					|1000					|1				 |2					   |1					|1						|									
	|Boy		|2000					|2000					|1				 |2					   |1.5					|1						|				

@record_mock
Scenario: (ChipsToMoney)ผู้เล่นแลกชิฟเป็นเป็นเงิน โดยระบุข้อมูลที่อยู่ ระบุชิฟที่ต้องการแลกมากกว่าขั้นต่ำ และมีชิฟเป็นมากกว่าจำนวนที่ต้องการแลก, ระบบบันทึกข้อมูลการแลกเช็ค
	Given The ChipsToMoneyExecutor has been created and initialized
	And (ChipsToMoney)sent UserName: 'OhAe' the player profile information should recieved
	And (ChipsToMoney)player balance information should be update(UserName: 'OhAe', chips: '1800', bonus chips: '0')
	And Cheque information should be create(UserName: 'OhAe', Address: '12 Road Srijun SubDistrict Naimueng District MuengKhonKaen 40000', Amount: '500')
	When call ChipsToMoneyExecutor(UsserName: 'OhAe', Address: '12 Road Srijun SubDistrict Naimueng District MuengKhonKaen 40000', Amount: '500')
	Then the player profile should be update and cheque information should be create
