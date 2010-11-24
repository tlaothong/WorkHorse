Feature: CancelPlayerAccount
	In order to cancel player account
	As a system
	I want to cancel player account

@record_mock
Scenario: ระบบได้รับข้อมูล playerAccountID ถูกต้อง แล้วส่งไปยัง backserver
	Given The CancelPlayerAccountExecutor has been created and initialized
	And Sent PlayerAccountID '123' 
	When Call CancelPlayerAccountExecutor
	Then System can sent PlayerAccountID to backserver

@record_mock
Scenario: ระบบได้รับ playerAccountID ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป backserver ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And Sent PlayerAccountID '-13' 
	When Call CancelPlayerAccountExecutor
	Then System can't sent PlayerAccountID to backserver

@record_mock
Scenario: ระบบไม่ได้รับ playerAccountID ระบบไม่สามารถส่งข้อมูลไป backserver ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And Sent PlayerAccountID '' 
	When Call CancelPlayerAccountExecutor
	Then System can't sent PlayerAccountID to backserver