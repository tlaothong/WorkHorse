Feature: CheckActiveRoundToCreate
	In order to check active round to create
	As a system
	I want to check active round for sent command to back server 


@record_mock
Scenario: ระบบไม่ได้รับข้อมูล Name ระบบไม่สามารถตรวจสอบจำนวน active round ได้ 
	Given The CheckActiveRoundExecutor has been created and initialized
	And   Sent name '' to server 
	When  Call CheckActiveRoundExecutor()
	Then  The system don't add ActiveRound

@record_mock
Scenario: ระบบได้รับข้อมูล Name ไม่ถูกต้อง ข้อมูล name มีจำนวนอักษรน้อยกว่า 5 ระบบไม่สามารถตรวจสอบจำนวน active round ได้ 
	Given The CheckActiveRoundExecutor has been created and initialized
	And   Sent name 'Game' to server 
	When  Call CheckActiveRoundExecutor()
	Then  The system don't add ActiveRound

