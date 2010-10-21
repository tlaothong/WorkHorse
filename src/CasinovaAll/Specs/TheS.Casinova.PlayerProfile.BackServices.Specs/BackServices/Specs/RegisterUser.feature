Feature: RegisterUser
	In order to register new user
	As a back server
	I want to be create new user

Background: RegisterUser
	Given server has user profile information as:
	|UserName	|
	|OhAe		|
	|Boy		|
	|Nittaya	|
	|Au			|

@record_mock
Scenario: ผู้เล่นสมัครโดยมีผู้แนะนำมาด้วย, ระบบบันทึกข้อมูล และส่งรหัสยืนยันให้ EmailSender ส่ง E-mail รหัสยืนยันให้ผู้เล่น
	Given The RegisterUserExecutor has been created and initialized
	And the upline should be avaliable(UserName: 'Nittaya')
	And the user profile should be create(UserName: 'OhAe', Password: '1234', E-mail: 'abc@abc.com', CellPhone: '0812345678', Upline: 'Nittaya', VeriflyCode: 'A2SK') 
	When call RegisterUserExecutor(UserName: 'OhAe', Password: '1234', E-mail: 'abc@abc.com', CellPhone: '0812345678', Upline: 'Nittaya', VeriflyCode: 'A2SK') 
	Then the result should be create

	@record_mock
Scenario: ผู้เล่นสมัครโดยมีผู้แนะนำมาด้วย, ระบบบันทึกข้อมูล และส่งรหัสยืนยันให้ EmailSender ส่ง E-mail รหัสยืนยันให้ผู้เล่น2
	Given The RegisterUserExecutor has been created and initialized
	And the upline should be avaliable(UserName: 'Boy')
	And the user profile should be create(UserName: 'OhAe', Password: '1234', E-mail: 'abc@abc.com', CellPhone: '0812345678', Upline: 'Boy', VeriflyCode: 'A2SK') 
	When call RegisterUserExecutor(UserName: 'OhAe', Password: '1234', E-mail: 'abc@abc.com', CellPhone: '0812345678', Upline: 'Boy', VeriflyCode: 'A2SK') 
	Then the result should be create
