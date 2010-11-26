Feature: VeriflyUser
	In order to verifly registered user
	As a back server
	I want to be activate registered user

Background: 
	Given (VerifyUser) server has user profile information as:
	|UserName	|VerifyCode|
	|OhAe		|A2SK		|
	|Boy		|3DS1		|
	|Nit		|KD21		|
	|Au			|UY8I		|

@record_mock
Scenario: (VerifyUser)ผู้เล่นยืนยันการสมัคร, รหัสยืนยันถูกต้อง, ระบบเปิดการใช้งานให้ผู้เล่น
	Given The VeriflyUserExecutor has been created and initialized
	And sent name: 'OhAe' the player profile should recieved
	And the user profile(UserName: 'OhAe') should be activate
	When call VeriflyUserExecutor(UserName: 'OhAe', VeriflyCode: 'A2SK')
	Then the result should be update

@record_mock
Scenario: (VerifyUser)ผู้เล่นยืนยันการสมัคร, รหัสยืนยันไม่ถูกต้อง, ระบบแจ้งเตือนผู้เล่น
	Given The VeriflyUserExecutor has been created and initialized
	And sent name: 'Au' the player profile should recieved
	When Expected exception and call VeriflyUserExecutor(UserName: 'Au', VeriflyCode: 'XXXX')
	Then the server should throw an error

@record_mock
Scenario: (VerifyUser)ผู้เล่นยืนยันการสมัคร, ไม่มีผู้เล่นนี้ในระบบ, ระบบแจ้งเตือนผู้เล่น
	Given The VeriflyUserExecutor has been created and initialized
	And sent name: 'Game' the player profile should recieved
	When Expected exception and call VeriflyUserExecutor(UserName: 'Game', VeriflyCode: 'XXXX')
	Then the server should throw an error