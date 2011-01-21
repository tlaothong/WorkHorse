Feature: ListRangeActionLog
	In order to ให้ผู้เล่นสามารถตรวจสอบได้ว่าในช่วงวันที่ผู้เล่นเลือกมีผู้เล่นที่ชนะจริง ๆ 
	As a User
	I want ดึงข้อมูลรายละเอียดการชนะของผู้เล่นทั้งหมดในแต่ละวันที่ผู้เล่นทำการเลือก


@record_mock
Background:
	Given Server has range action log information 
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
		|2			|May		| 20		|46			|11:29 12/14/2010	|
		|1			|Au			| 1			|1			|11:30 12/14/2010	|
		|1			|Kay		| 2			|3			|11:31 12/14/2010	|
		|1			|Amz		| 2			|5			|11:32 12/14/2010	|
		|1			|Sak		| 1			|6			|11:33 12/15/2010	|
		|1			|Sak		| 2			|8			|11:34 12/15/2010	|
		|1			|Pry		| 2			|2			|11:35 12/16/2010	|

	And  Range action log get winnerpoint from game round information 
		|RoundID	|WinnerPoint	|
		|1			|6				|
		|2			|66				|
		|3			|666			|
		|4			|6666			|

@record_mock
Scenario:[ListRangeActionLog] ระบบได้รับข้อมูลการขอดูสถิติผู้ชนะ ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบสามารถดึงข้อมูลสถิติการชนะของผู้เล่นทั้งหมดในช่วงวันที่ที่เลือกดูได้
	Given The ListRangeActionLogInfoExecutor has been created and initialized
	And   Sent RoundID'1' FromDateTime'12/13/2010' ThruDateTime'12/15/2010' the Range action log should recieved
	And   Sent RoundID'1' FromDateTime'12/13/2010' ThruDateTime'12/15/2010'
	When  Call ListRangeActionLogInfoExecutor()
	Then  Range action log result should be as:
		|RoundID	|UserName	| Amount	|BetOrder	|BetDateTime		|
		|1			|Sak		| 1			|7			|11:31 12/13/2010	|
		|1			|nit		| 2			|7			|11:35 12/13/2010	|
		|1			|Sak		| 2			|8			|11:34 12/15/2010	|

