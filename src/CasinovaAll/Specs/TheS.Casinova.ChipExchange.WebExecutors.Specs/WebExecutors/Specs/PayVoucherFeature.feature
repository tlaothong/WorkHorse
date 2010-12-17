Feature: PayVoucher
	In order to pay voucher
	As a system
	I want to pay voucher by bonus chips or chips

@record_mock
Background:
Given Server has user profile information for pay voucher:
|UserName	|Refundable	 |NonRefundable|
|OhAe		|500		 |200		   |
|Boy		|4500		 |500		   |
|Nit		|300		 |589		   |

@record_mock
Scenario:[PayVoucher]ระบบได้รับข้อมูล userName และ amount ถูกต้อง ระบบตรวจสอบจำนวนชิพทั้งหมดมีเพียงพอ ระบบสามารถ generate trackingID ได้
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'Nit' Amount'500' for pay voucher
	And   Sent UserName'Nit' the player's profile should recieved
	And   The system generated TrackingID for PayVoucher:'942D2F350FAA4A32870CF9CF9A5C7A2E'
	When  Call PayVoucherExecutor()
	Then  TrackingID for PayVoucher should be :'942D2F350FAA4A32870CF9CF9A5C7A2E'

@record_mock
Scenario:[PayVoucher]ระบบได้รับข้อมูล userName และ amount ถูกต้อง ระบบตรวจสอบจำนวนชิพทั้งหมดมีไม่เพียงพอ ระบบไม่สามารถ generate trackingID ได้ 
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'Nit' Amount'1000' for pay voucher
	And   Sent UserName'Nit' the player's profile should recieved
	When  Call PayVoucherExecutor()
	Then  Get null and skip checking trackingID for pay voucher


@record_mock
Scenario:[PayVoucher]ระบบได้รับข้อมูล userName และ amount ครบ แต่ไม่มี userName ใน server ระบบไม่สามารถ generate trackingID ได้ 
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'Noy' Amount'1000' for pay voucher
	And   Sent UserName'Noy' the player's profile should recieved 
	When  Call PayVoucherExecutor()
	Then  Get null and skip checking trackingID for pay voucher

@record_mock
Scenario:[PayVoucher]ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถตรวจสอบจำนวนชิพทั้งหมดได้
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'' Amount'1000' for pay voucher
	When  Call PayVoucherExecutor() for validate input
	Then  Get null and skip checking trackingID

@record_mock
Scenario:[PayVoucher]ระบบได้รับข้อมูล amount ไม่ถูกต้อง ระบบไม่สามารถตรวจสอบจำนวนชิพทั้งหมดได้
	Given The PayVoucherExecutor has been created and initialized
	And   Sent UserName'' Amount'1000' for pay voucher
	When  Call PayVoucherExecutor() for validate input
	Then  Get null and skip checking trackingID