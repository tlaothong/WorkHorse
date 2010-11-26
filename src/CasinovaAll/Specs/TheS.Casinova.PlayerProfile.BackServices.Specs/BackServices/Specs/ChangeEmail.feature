Feature: ChangeEmail
	In order to change e-mail
	As a back server
	I want to be update new e-mail

Background: 
	Given (ChangeEmail)server has user profile information as:
	|UserName	|Password	|E-mail			|
	|OhAe		|aaaa		|aaa@aaa.com	|
	|Boy		|bbbb		|bbb@bbb.com	|
	|Nittaya	|cccc		|ccc@ccc.com	|
	|Au			|dddd		|ddd@ddd.com	|

@record_mock
Scenario: (ChangeEmail)ผู้เล่นต้องการเปลี่ยนอีเมลล์ โดยระบุรหัสผ่านถูกต้อง อีเมลล์เดิมถูกต้อง และอีเมลล์ใหม่ยังไม่เคยถูกใช้, ระบบบันทึกข้อมูลอีเมลล์ใหม่
	Given The ChangeEmail has been created and initialized	
	And the player profile should be recieved(UserName: 'OhAe')
	And the new email should be unique(NewE-mail: 'a@a.com')
	And the user profile should be update(UserName: 'OhAe', NewE-mail: 'a@a.com')
	When call ChangeEmailExecutor(UserName: 'OhAe', Password: 'aaaa', OldE-mail: 'aaa@aaa.com', NewE-mail: 'a@a.com')
	Then the e-mail should be update 

@record_mock
Scenario: (ChangeEmail)ผู้เล่นต้องการเปลี่ยนอีเมลล์ โดยระบุรหัสผ่านไม่ถูกต้อง ระบบแจ้งเตือน
	Given The ChangeEmail has been created and initialized	
	And the player profile should be recieved(UserName: 'OhAe')
	When Expected exception and call ChangeEmailExecutor(UserName: 'OhAe', Password: 'xxxx', OldE-mail: 'aaa@aaa.com', NewE-mail: 'a@a.com')
	Then the result should be throw exception

@record_mock
Scenario: (ChangeEmail)ผู้เล่นต้องการเปลี่ยนอีเมลล์ โดยระบุเดิมไม่ถูกต้อง ระบบแจ้งเตือน	
	Given The ChangeEmail has been created and initialized	
	And the player profile should be recieved(UserName: 'OhAe')
	When Expected exception and call ChangeEmailExecutor(UserName: 'OhAe', Password: 'aaaa', OldE-mail: 'xxx@xxx.com', NewE-mail: 'a@a.com')
	Then the result should be throw exception

@record_mock
Scenario: (ChangeEmail)ผู้เล่นต้องการเปลี่ยนอีเมลล์ โดยระบุอีเมลล์ใหม่ที่ถูกใช้แล้ว ระบบแจ้งเตือน	
	Given The ChangeEmail has been created and initialized	
	And the player profile should be recieved(UserName: 'OhAe')
	And the new email should be unique(NewE-mail: 'aaa@aaa.com')
	When Expected exception and call ChangeEmailExecutor(UserName: 'OhAe', Password: 'aaaa', OldE-mail: 'aaa@aaa.com', NewE-mail: 'aaa@aaa.com')
	Then the result should be throw exception
