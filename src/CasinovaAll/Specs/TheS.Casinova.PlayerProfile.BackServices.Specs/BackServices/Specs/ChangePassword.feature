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
Scenario: ได้รับรหัสผ่านที่ต้องการเปลี่ยน, ระบบเปลี่ยนแปลงรหัสผ่านของผู้เล่นในระบบ
	Given The ChangePassword has been created and initialized
	And the old password should be correct(UserName: 'OhAe', OldPassword: 'ugmK')
	And the user profile should be update(UserName: 'OhAe', OldPassword: 'ugmK', NewPassword: '5321')
	When call ChangePasswordExecutor(UserName: 'OhAe', OldPassword: 'ugmK', NewPassword: '5321')
	Then the password should be update in user profile

@record_mock
Scenario: ได้รับรหัสผ่านที่ต้องการเปลี่ยน, ระบบเปลี่ยนแปลงรหัสผ่านของผู้เล่นในระบบ2
	Given The ChangePassword has been created and initialized
	And the old password should be correct(UserName: 'Boy', OldPassword: 'ugmK')
	And the user profile should be update(UserName: 'Boy', OldPassword: 'ugmK', NewPassword: '5321')
	When call ChangePasswordExecutor(UserName: 'Boy', OldPassword: 'ugmK', NewPassword: '5321')
	Then the password should be update in user profile
