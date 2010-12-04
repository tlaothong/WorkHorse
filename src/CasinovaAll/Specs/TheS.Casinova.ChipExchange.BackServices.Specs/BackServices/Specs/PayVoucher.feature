Feature: PayVoucher
	In order to pay chip for voucher
	As a back server
	I want to be decrease player balance and create voucher information

@record_mock
Background:
	Given (PayVoucher)server has player information as:
	|UserName	|NonRefundable	|Refundable	|
	|OhAe		|500			|1800		|
	|Boy		|700			|726.29		|
	|Nit		|36.99			|383.21		|
	|Au			|150.00			|3761.99	|

@record_mock
Scenario: (PayVoucher)ผู้เล่นแลกคูปองด้วยชิฟ มีชิฟพอสำหรับแลกโดยมีชิฟตายพอดีกับคูปองที่แลก, ระบบอัพเดทข้อมูลผู้เล่นและสร้างข้อมูลคูปองใหม่
	Given The PayVoucherExecutor has been created and initialized
	And (PayVoucher)sent UserName: 'OhAe' the player profile information should recieved
	And player balance information should be update(UserName: 'OhAe', chips: '1800', bonus chips: '0')
	And voucher code should be generate new code(VoucherCode: 'Ys7S')	
	And voucher information should be create(VoucherCode: 'Ys7S', Amount: '500', UserName: 'OhAe')
	When call PayVoucherExecutor(UsserName: 'OhAe', Amount: '500')
	Then the player profile should be update and voucher information should be create

@record_mock
Scenario: (PayVoucher)ผู้เล่นแลกคูปองด้วยชิฟ มีชิฟพอสำหรับแลกโดยมีชิฟตายมากกว่าคูปองที่แลก, ระบบอัพเดทข้อมูลผู้เล่นและสร้างข้อมูลคูปองใหม่
	Given The PayVoucherExecutor has been created and initialized
	And (PayVoucher)sent UserName: 'Boy' the player profile information should recieved
	And player balance information should be update(UserName: 'Boy', chips: '726.29', bonus chips: '200')
	And voucher code should be generate new code(VoucherCode: 'HAsd')	
	And voucher information should be create(VoucherCode: 'HAsd', Amount: '500', UserName: 'Boy')
	When call PayVoucherExecutor(UsserName: 'Boy', Amount: '500')
	Then the player profile should be update and voucher information should be create

@record_mock
Scenario: (PayVoucher)ผู้เล่นแลกคูปองด้วยชิฟ มีชิฟพอสำหรับแลกโดยมีชิฟตายไม่พอกับคูปองที่แลก หักชิฟเป็นเพิ่ม, ระบบอัพเดทข้อมูลผู้เล่นและสร้างข้อมูลคูปองใหม่
	Given The PayVoucherExecutor has been created and initialized
	And (PayVoucher)sent UserName: 'Au' the player profile information should recieved
	And player balance information should be update(UserName: 'Au', chips: '3411.99', bonus chips: '0')
	And voucher code should be generate new code(VoucherCode: 'HSUa')	
	And voucher information should be create(VoucherCode: 'HSUa', Amount: '500', UserName: 'Au')
	When call PayVoucherExecutor(UsserName: 'Au', Amount: '500')
	Then the player profile should be update and voucher information should be create

@record_mock
Scenario: (PayVoucher)ผู้เล่นแลกคูปองด้วยชิฟ มีชิฟไม่พอสำหรับแลกคูปอง, ระบบแจ้งเตือนผู้เล่น
	Given The PayVoucherExecutor has been created and initialized
	And (PayVoucher)sent UserName: 'Nit' the player profile information should recieved
	When Expected exception and call PayVoucherExecutor(UsserName: 'Nit', Amount: '500')
	Then the player profile should be update and voucher information should be create
