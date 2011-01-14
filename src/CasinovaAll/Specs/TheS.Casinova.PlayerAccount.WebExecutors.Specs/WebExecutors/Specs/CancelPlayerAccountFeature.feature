Feature: CancelPlayerAccount
	In order to cancel player account
	As a system
	I want to cancel player account

@record_mock
Scenario:[CancelPlayerAccount]ระบบได้รับข้อมูลการยกเลิกบัญชีถูกต้อง ระบบสามารถส่งข้อมูลการยกเลิกบัญชีผู้ใช้ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And  Sent UserName 'Nit' AccountType 'Primary' for cancel player account
	When Call CancelPlayerAccountExecutor() 
	Then System can sent cancel player account information to back server

@record_mock
Scenario:[CancelPlayerAccount]ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถส่งข้อมูลการยกเลิกบัญชีผู้ใช้ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And  Sent UserName '' AccountType 'Primary' for cancel player account
	When Call CancelPlayerAccountExecutor() for validate input
	Then System can't sent cancel player account information to back server

@record_mock
Scenario:[CancelPlayerAccount]ระบบไม่ได้รับข้อมูล AccountType ระบบไม่สามารถส่งข้อมูลการยกเลิกบัญชีผู้ใช้ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And  Sent UserName 'Nit' AccountType '' for cancel player account
	When Call CancelPlayerAccountExecutor() for validate input
	Then System can't sent cancel player account information to back server