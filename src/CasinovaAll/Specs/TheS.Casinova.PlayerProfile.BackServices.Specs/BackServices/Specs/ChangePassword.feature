Feature: ChangePassword
	In order to change password
	As a back server
	I want to be update new password

@record_mock
Scenario: ได้รับรหัสผ่านที่ต้องการเปลี่ยน, ระบบเปลี่ยนแปลงรหัสผ่านของผู้เล่นในระบบ
	Given The ChangePassword has been created and initialized
	And the user profile should be update(UserName: 'OhAe', Password: '5321')
	When call ChangePasswordExecutor(UserName: 'OhAe', Password: '5321')
	Then the result should be update
