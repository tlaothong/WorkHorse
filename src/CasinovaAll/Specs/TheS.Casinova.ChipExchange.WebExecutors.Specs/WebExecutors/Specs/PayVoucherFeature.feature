Feature: PayVoucher
	In order to pay voucher
	As a system
	I want to pay voucher by bonus chips or chips

@record_mock
Background:
Given Server has user profile information for pay voucher:
|UserName	|Password	|Email					|CellPhone	 | Upline |Refundable|NonRefundable|Active|
|OhAe		|1234		|sirinarin@hotmail.com	|0892165437	 |Nit	  |500		 |200		   |True  |
|Boy		|5843		|pongsak@gmail.com		|0862202260  |Nit	  |4500		 |500		   |True  |
|Nit		|1311		|nayit_nit@hotmail.com	|0892131356  |	      |300		 |589		   |True  |

@record_mock
Scenario: ระบบได้รับข้อมูล userName และ amount ครบ ระบบตรวจสอบจำนวนชิพทั้งหมดมีเพียงพอ ระบบสามารถส่งข้อมูลไป back server ได้ 
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'Nit' the player's profile should recieved
	And   Expected executed PayVoucherCommand
	When  Call PaVoucherExecutor(UserName'Nit', Amount'500')
	Then  The system can sent information to back server #PayVoucher

@record_mock
Scenario: ระบบได้รับข้อมูล userName และ amount ครบ ระบบตรวจสอบจำนวนชิพทั้งหมดมีไม่เพียงพอ ระบบไม่สามารถส่งข้อมูลไป back server ได้ 
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'Nit' the player's profile should recieved
	When  Call PaVoucherExecutor(UserName'Nit', Amount'1000')
	Then  The system can't sent information to back server #PayVoucher


@record_mock
Scenario: ระบบได้รับข้อมูล userName และ amount ครบ แต่ไม่มี userName ใน server ระบบไม่สามารถตรวจสอบจำนวนชิพทั้งหมดได้
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'Noy' the player's profile should recieved null
	When  Call PaVoucherExecutor(UserName'Noy', Amount'1000')
	Then  The system can't sent information to back server #PayVoucher

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถตรวจสอบจำนวนชิพทั้งหมดได้
	Given The PayVoucherExecutor has been created and initialized
	When  Call PaVoucherExecutor(UserName'', Amount'1000')
	Then  The system can't sent information to back server #PayVoucher

@record_mock
Scenario: ระบบได้รับข้อมูล amount ไม่ถูกต้อง ระบบไม่สามารถตรวจสอบจำนวนชิพทั้งหมดได้
	Given The PayVoucherExecutor has been created and initialized
	When  Call PaVoucherExecutor(UserName'Nit', Amount'-1000')
	Then  The system can't sent information to back server #PayVoucher