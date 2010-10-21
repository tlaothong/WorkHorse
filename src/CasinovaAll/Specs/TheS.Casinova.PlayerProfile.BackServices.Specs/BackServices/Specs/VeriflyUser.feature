Feature: VeriflyUser
	In order to verifly registered user
	As a back server
	I want to be activate registered user

Background: 
	Given (VeriflyUser) server has user profile information as:
	|UserName	|VeriflyCode|
	|OhAe		|A2SK		|
	|Boy		|3DS1		|
	|Nit		|KD21		|
	|Au			|UY8I		|

@record_mock
Scenario: ผู้เล่นยืนยันการสมัคร, ตรวจสอบรหัสถูกต้อง, ระบบเปิดการใช้งานให้ผู้เล่น
	Given The VeriflyUserExecutor has been created and initialized
	And sent name: 'OhAe' and VeriflyCode: 'A2SK' the verifly code should be correct
	And the user profile(UserName: 'OhAe', VeriflyCode: 'A2SK') should be activate
	When call VeriflyUserExecutor(UserName: 'OhAe', VeriflyCode: 'A2SK')
	Then the result should be update

	@record_mock
Scenario: ผู้เล่นยืนยันการสมัคร, ตรวจสอบรหัสถูกต้อง, ระบบเปิดการใช้งานให้ผู้เล่น2
	Given The VeriflyUserExecutor has been created and initialized
	And sent name: 'Boy' and VeriflyCode: '3DS1' the verifly code should be correct
	And the user profile(UserName: 'Boy', VeriflyCode: '3DS1') should be activate
	When call VeriflyUserExecutor(UserName: 'Boy', VeriflyCode: '3DS1')
	Then the result should be update

	@record_mock
Scenario: ผู้เล่นยืนยันการสมัคร, ตรวจสอบรหัสไม่ถูกต้อง, ระบบแจ้งเตือน
	Given The VeriflyUserExecutor has been created and initialized
	And sent name: 'Au' and VeriflyCode: 'XXXX' the verifly code should be correct
	And the user profile(UserName: 'Au', VeriflyCode: 'XXXX') should be activate
	When call VeriflyUserExecutor(UserName: 'Au', VeriflyCode: 'XXXX')
	Then the server should throw an error

