Feature: VoucherToBonusChips
	In order to exchange voucher to bonus chips
	As a back server
	I want to be given some bonus chips to player and update used voucher
@record_mock
Background: 
	Given (VoucherToBonusChips)server has voucher information as:
	|Code	|Amount		|UserName	|CanUser	|
	|jK2A	|500		|Boy		|true		|
	|K9a1	|1000		|Tao		|true		|
	|Gh5E	|5000		|Nit		|false		|
	
	Given (VoucherToBonusChips)server has exchange setting information as:
	|Name		|MinChipToMoneyExchange	|MinMoneyToChipExchange |MoneyToChipRate |MoneyToBonusChipRate |ChipToBonusChipRate |VoucherToBonusChipRate	|
	|exchange1	|1000					|1000					|1				 |2					   |1					|1						|									
	|Boy		|2000					|2000					|1				 |2					   |1.5					|1						|				

@record_mock
Scenario: ผู้เล่นแลกคูปองเป็นชิฟตาย มีคูปองตามรหัสที่ระบุและคูปองยังไม่ถูกใช้งาน, ระบบตรวจสอบคูปองและเพิ่มชิฟตายให้กับผู้เล่น
	Given The VoucherToBounusChipsExecutor has been created and initialized
	And (VoucherToBonusChips)sent Code: 'jK2A' the voucher information should recieved
	And (VoucherToBonusChips)request voucher avaliable for exchange
	And (VoucherToBonusChips)sent ExchangeSettingName: 'exchange1' the exchange setting should recieved 
	And (VoucherToBonusChips)voucher should be update(Code: 'jK2A')
	And (VoucherToBonusChips)the user bonus chips should be adding(UserName: 'OhAe', Amount:'500')
	When call VoucherToBonusChipsExecutor(Code: 'jK2A', UserName: 'OhAe')
	Then the player profile should be update

@record_mock
Scenario: ผู้เล่นแลกคูปองเป็นชิฟตาย มีคูปองตามรหัสที่ระบุและคูปองถูกใช้งานแล้ว, ระบบตรวจสอบคูปองและแจ้งเตือน
	Given The VoucherToBounusChipsExecutor has been created and initialized
	And (VoucherToBonusChips)sent Code: 'Gh5E' the voucher information should recieved
	And (VoucherToBonusChips)request voucher not avaliable for exchange
	When call VoucherToBonusChipsExecutor(Code: 'Gh5E', UserName: 'OhAe')
	Then abort operation

@record_mock
Scenario: ผู้เล่นแลกคูปองเป็นชิฟตาย ไม่มีคูปองตามรหัสที่ระบุ, ระบบตรวจสอบคูปองและแจ้งเตือน
	Given The VoucherToBounusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task
