Feature: ChangePassword
	In order to change password
	As a back server
	I want to be update new password

Background: 
	Given (ChangePassword)server has user profile information as:
	|UserName	|Password	|
	|OhAe		|ugmK		|
	|Boy		|23sG		|
	|Nittaya	|2sS1		|
	|Au			|2ka3		|

@record_mock
Scenario: (ChangePassword)ผู้เล่นต้องการเปลี่ยนรหัสผ่านใหม่ โดยระบุรหัสผ่านเดิมถูกต้อง, ระบบเปลี่ยนแปลงรหัสผ่านของผู้เล่นในระบบ
	Given The ChangePassword has been created and initialized
	And (ChangePassword)the player profile should be recieved(UserName: 'OhAe')
	And the user profile should be update(UserName: 'OhAe', NewPassword: '5321')
	When call ChangePasswordExecutor(UserName: 'OhAe', OldPassword: 'ugmK', NewPassword: '5321')
	Then the password should be update

@record_mock
Scenario: (ChangePassword)ผู้เล่นต้องการเปลี่ยนรหัสผ่านใหม่ โดยระบุรหัสผ่านเดิมไม่ถูกต้อง, ระบบเปลี่ยนแปลงรหัสผ่านของผู้เล่นในระบบ
	Given The ChangePassword has been created and initialized
	And (ChangePassword)the player profile should be recieved(UserName: 'OhAe')
	When Expected exception and call ChangePasswordExecutor(UserName: 'OhAe', OldPassword: 'YgmK', NewPassword: '5321')
	Then the result should be throw exception
