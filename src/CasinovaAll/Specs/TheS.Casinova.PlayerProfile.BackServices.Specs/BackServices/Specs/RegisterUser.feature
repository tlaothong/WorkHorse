Feature: RegisterUser
	In order to register new user
	As a back server
	I want to be create new user

@record_mock
Scenario: ผู้เล่นสมัครโดยมีผู้แนะนำมาด้วย, ระบบบันทึกข้อมูล และส่งรหัสยืนยันให้ EmailSender ส่ง E-mail รหัสยืนยันให้ผู้เล่น
	Given The RegisterUserExecutor has been created and initialized
	And the user profile should be create(UserName: 'OhAe', Password: '1234', E-mail: 'abc@abc.com', CellPhone: '0812345678', Upline: 'Nittaya') 
	When call RegisterUserExecutor(UserName: 'OhAe', Password: '1234', E-mail: 'abc@abc.com', CellPhone: '0812345678', Upline: 'Nittaya') 
	Then the result should be create
