Feature: PayVoucher
	In order to pay chip for voucher
	As a back server
	I want to be decrease player balance and create voucher information

@record_mock
Background: 
	Given (PayVoucher)server has player information as:
	|UserName	|NonRefundable	|Refundable	|
	|OhAe		|500			|1800		|
	|Boy		|121.21			|726.29		|
	|Nit		|36.99			|383.21		|
	|Au			|00.00			|3761.99	|

@record_mock
Scenario: ผู้เล่นแลกคูปองด้วยชิฟ มีชิฟตายพอดีสำหรับแลกคูปอง, ระบบอัพเดทข้อมูลผู้เล่นและสร้างข้อมูลคูปองใหม่
	Given The PayVoucherExecutor has been created and initialized
	And (PayVoucher)sent UserName: 'OhAe' the player profile information should recieved
	And player balance(chips, bonus chips) should more than or equal request voucher(Amount: '500')
	And player balance(bonus chips) more than or equal request voucher(Amount: '500')
	And player balance information should be update(UserName: 'OhAe', chips: '1800', bonus chips: '0')
	And voucher code should be generate new code(VoucherCode: 'Ys7S')	
	And voucher information should be create(VoucherCode: 'Ys7S', Amount: '500', UserName: 'OhAe', CanUse: 'true')
	When call PayVoucherExecutor(UserName: 'OhAe', Amount: '500')
	Then the player profile should be update and voucher information should be create
