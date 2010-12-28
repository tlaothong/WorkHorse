Feature: GetVoucherCode
	In order to get voucher code
	As a system
	I want to get voucher code

@record_mock
Background:
Given Server has voucher information for get voucher code :
	|UserName	|VoucherCode		|Amount	 |CanUse|
	|OhAe		|630041228BAD10C2	|500	 |True  |
	|Boy		|128031228BF210E4	|300     |True  |
	|Nit		|448021228C7A10D3	|200	 |True  |

@record_mock
Scenario:[GetVoucherCode]ระบบได้รับข้อมูล userName ถูกต้อง ระบบสามารถดึงข้อมูลคูปองได้
	Given The GetVoucherCodeExecutor has been created and initialized 
	And   Sent UserName 'Boy' for get voucher code            
	When  Call GetVoucherCodeExecutor() 
	Then  The result should be Username'Boy' VoucherCode '128031228BF210E4' Amount '300'

@record_mock
Scenario:[GetVoucherCode]ระบบได้รับข้อมูล userName ที่ไม่มีใน server ระบบได้ข้อมูลคูปองเป็น null
	Given The GetVoucherCodeExecutor has been created and initialized  
	And   Sent UserName 'Noy' for get voucher code             
	When  Call GetVoucherCodeExecutor()
	Then  VoucherCode should be null 

@record_mock
Scenario:[GetVoucherCode]ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถดึงข้อมูลรหัสคูปองได้
	Given The GetVoucherCodeExecutor has been created and initialized 
	And   Sent UserName '' for validation             
	When  Call GetVoucherCodeExecutor() for validate input
	Then  VoucherCode should be throw exception