Feature: ListSingleActionLog
	In order to ให้ผู้เล่นสามารถตรวจสอบได้ว่ามีผู้เล่นที่ชนะจริง ๆ ในแต่ละวัน
	As a User
	I want ดึงข้อมูลรายละเอียดการชนะของผู้เล่นทั้งหมดในแต่ละวัน

@record_mock
Background:
	Given Server has single action log information 
		|RoundID	|UserName	| Amount	|BetOrder	|BetDateTime		|
		|1			|Nayit		| 1			|1			|10:54 12/13/2010	|
		|2			|Nayit		| 5			|5			|10:58 12/13/2010	|
		|1			|Nayit		| 2			|3			|11:02 12/13/2010	|
		|1			|Kob		| 1			|4			|11:14 12/13/2010	|
		|2			|Eye		| 1			|6			|11:20 12/13/2010	|
		|1			|Krai		| 1			|5			|11:21 12/13/2010	|
		|2			|Jae		| 20		|26			|11:29 12/13/2010	|
		|1			|Sak		| 1			|6			|11:30 12/13/2010	|
		|1			|Sak		| 1			|7			|11:31 12/13/2010	|
		|1			|nayit		| 1			|1			|11:32 12/13/2010	|
		|1			|Sak		| 2			|3			|11:33 12/13/2010	|
		|1			|Sak		| 2			|5			|11:34 12/13/2010	|
		|1			|nit		| 2			|7			|11:35 12/13/2010	|

	And  Server has game round information
		|RoundID	|WinnerPoint	|
		|1			|6				|
		|2			|66				|
		|3			|666			|
		|4			|6666			|

@record_mock
Scenario:[ListSingleActionLog] ระบบได้รับข้อมูลการขอดูสถิติผู้ชนะ ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบสามารถดึงข้อมูลสถิติการชนะของผู้เล่นทั้งหมดในวันที่ที่เลือกดูได้
	Given The ListSingleActionLogInfoExecutor has been created and initialized
	And   Sent RoundID'1' DateTime'12/13/2010' the single action log should recieved
	And   Sent RoundID'1' DateTime'12/13/2010' 
	When  Call ListSingleActionLogInfoExecutor()
	Then  Single action log result should be as:
		|RoundID	|UserName	| Amount	|BetOrder	|BetDateTime		|
		|1			|Sak		| 1			|7			|11:31 12/13/2010	|
		|1			|nit		| 2			|7			|11:35 12/13/2010	|

@record_mock
Scenario:[ListSingleActionLog] ระบบได้รับข้อมูลการขอดูสถิติผู้ชนะ ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง แต่ใน server ไม่มีข้อมูลการชนะ ได้ข้อมูลสถิติเป็น null
	Given The ListSingleActionLogInfoExecutor has been created and initialized
	And   Sent RoundID'2' DateTime'12/13/2010' the single action log should recieved
	And   Sent RoundID'2' DateTime'12/13/2010' 
	When  Call ListSingleActionLogInfoExecutor()
	Then  Single action log result should be as:
		|RoundID	|UserName	| Amount	|BetOrder	|BetDateTime		|
		

@record_mock
Scenario:[ListSingleActionLog] ระบบได้รับข้อมูลการขอดูสถิติผู้ชนะ ระบบทำการตรวจสอบข้อมูล ข้อมูล RoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูลสถิติการชนะของผู้เล่นได้
	Given The ListSingleActionLogInfoExecutor has been created and initialized
	And   Sent invalid information RoundID'0' DateTime'12/13/2010' 
	When  Call ListSingleActionLogInfoExecutor() for validation
	Then  Single action log result should be throw exception

@record_mock
Scenario:[ListSingleActionLog] ระบบได้รับข้อมูลการขอดูสถิติผู้ชนะ ระบบทำการตรวจสอบข้อมูล ข้อมูล DateTime ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูลสถิติการชนะของผู้เล่นได้
	Given The ListSingleActionLogInfoExecutor has been created and initialized
	And   Sent RoundID'1' DateTime is today
	When  Call ListSingleActionLogInfoExecutor() for validation
	Then  Single action log result should be throw exception
		