Feature: ChangeEmail
	In order to change e-mail
	As a back server
	I want to be update new e-mail

@record_mock
Scenario: ได้รับรหัส E-mail ที่ต้องการเปลี่ยน, ระบบเปลี่ยนแปลงรหัส E-mail ของผู้เล่นในระบบ
	Given The ChangeEmail has been created and initialized
	And the user profile should be update(UserName: 'OhAe', E-mail: 'def@def.com')
	When call ChangeEmailExecutor(UserName: 'OhAe', E-mail: 'def@def.com')
	Then the result should be update
