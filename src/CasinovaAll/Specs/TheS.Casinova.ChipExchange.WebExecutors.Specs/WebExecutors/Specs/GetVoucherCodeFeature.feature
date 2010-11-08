Feature: GetVoucherCode
	In order to get voucher code
	As a system
	I want to get voucher code

@record_mock
Background:
Given Server has voucher information for get voucher code :
	|UserName	|VoucherCode	|Amount	 |Active|
	|OhAe		|B67C3			|200	 |True  |
	|Boy		|6690A			|500     |True  |
	|Nit		|C3441			|500	 |True  |

@record_mock
Scenario: ระบบได้รับข้อมูล userName ถูกต้อง ระบบสามารถดึงข้อมูลคูปองได้
	Given The GetVoucherCodeExecutor has been created and initialized             
	When  Call GetVoucherCodeExecutor (UserName 'Boy')
	Then  The result should be Username'Boy' VoucherCode '6690A' Amount '500' Active 'True'

@record_mock
Scenario: ระบบได้รับข้อมูล userName ที่ไม่มีใน server ระบบได้ข้อมูลคูปองเป็น null
	Given The GetVoucherCodeExecutor has been created and initialized            
	When  Call GetVoucherCodeExecutor (UserName 'Noy')
	Then  The result should be null #GetVoucherCode

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถดึงข้อมูลรหัสคูปอง
	Given The GetVoucherCodeExecutor has been created and initialized            
	When  Call GetVoucherCodeExecutor (UserName '')
	Then  The result should be null #GetVoucherCode