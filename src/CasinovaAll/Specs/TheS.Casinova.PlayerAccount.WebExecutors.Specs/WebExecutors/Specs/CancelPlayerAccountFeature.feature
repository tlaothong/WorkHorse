Feature: CancelPlayerAccount
	In order to cancel player account
	As a system
	I want to cancel player account

@record_mock
Scenario:[CancelPlayerAccount]ระบบได้รับข้อมูลการยกเลิกบัญชีถูกต้อง ระบบสามารถ generate trackingID ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And  Sent UserName 'Nit' AccountType 'Primary' for cancel player account
	And  The system generated TrackingID for CancelPlayerAccount :'DEDE6BFD17484312848E13F26345C597'
	When Call CancelPlayerAccountExecutor() 
	Then TrackingID for CancelPlayerAccount should be : 'DEDE6BFD17484312848E13F26345C597'

@record_mock
Scenario:[CancelPlayerAccount]ระบบได้รับ playerAccountID ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป backserver ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And  Sent UserName '' AccountType 'Primary' for cancel player account
	When Call CancelPlayerAccountExecutor() for validate input
	Then  Get null and skip checking trackingID for cancel player account

@record_mock
Scenario:[CancelPlayerAccount]ระบบไม่ได้รับ playerAccountID ระบบไม่สามารถส่งข้อมูลไป backserver ได้
	Given The CancelPlayerAccountExecutor has been created and initialized
	And  Sent UserName 'Nit' AccountType '' for cancel player account
	When Call CancelPlayerAccountExecutor() for validate input
	Then  Get null and skip checking trackingID for cancel player account