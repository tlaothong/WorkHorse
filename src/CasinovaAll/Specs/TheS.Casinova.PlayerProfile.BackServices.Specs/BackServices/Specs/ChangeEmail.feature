Feature: ChangeEmail
	In order to change e-mail
	As a back server
	I want to be update new e-mail

Background: 
	Given (ChangeEmail)server has user profile information as:
	|UserName	|E-mail			|
	|OhAe		|aaa@aaa.com	|
	|Boy		|bbb@bbb.com	|
	|Nittaya	|ccc@ccc.com	|
	|Au			|ddd@ddd.com	|

@record_mock
Scenario: ได้รับข้อมูล E-mail ที่ต้องการเปลี่ยน, E-mail เก่าถูกต้องและ E-mail ใหม่ไม่ซ้ำกับ E-mail ที่มีอยู่่ในระบบ, ระบบเปลี่ยนแปลงรหัส E-mail ของผู้เล่นในระบบ
	Given The ChangeEmail has been created and initialized	
	And the old email should be correct(UserName: 'OhAe', OldE-mail: 'aaa@aaa.com')
	And the new email should be unique(NewE-mail: 'a@a.com')
	And the user profile should be update(UserName: 'OhAe', OldE-mail: 'aaa@aaa.com', NewE-mail: 'a@a.com')
	When call ChangeEmailExecutor(UserName: 'OhAe', OldE-mail: 'aaa@aaa.com', NewE-mail: 'a@a.com')
	Then the e-mail should be update in user profile
