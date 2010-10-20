Feature: VeriflyUser
	In order to verifly registered user
	As a back server
	I want to be activate registered user

Background: SingleBet
	Given server has player information as:
	|UserName	|VeriflyCode|
	|OhAe		|A2SK		|
	|Boy		|3DS1		|
	|Nit		|KD21		|
	|Au			|UY8I		|

@record_mock
Scenario: ผู้เล่นยืนยันการสมัคร, ตรวจสอบรหัสถูกต้อง, ระบบเปิดการใช้งานให้ผู้เล่น
	Given The VeriflyUserExecutor has been created and initialized
	And sent name: 'OhAe' and VeriflyCode: 'A2SK' the verifly code should be correct
	And the user profile(UserName: 'OhAe') should be activate
	When call VeriflyUserExecutor(UserName: 'OhAe')
	Then the result should be update

