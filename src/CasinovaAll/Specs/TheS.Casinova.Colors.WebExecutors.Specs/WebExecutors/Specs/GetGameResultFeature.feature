Feature: GetGameResult
	In order to get game result
	As a system
	I want to get game result when game finish

Background:
	Given Server has game result information 
		|RoundID|StartTime|EndTime|BlackPot	| WhitePot	|HandCount	|
		|1		|09:00	  |09:30  |23		|24			|13			|
		|2		|09:30	  |10:00  |500		|499		|52			|
		|3		|10:00	  |10:30  |1500		|1459		|82			|
		|4		|10:30	  |11:00  |2001		|2009		|87		    |
		|5		|11:00	  |11:30  |0		|0			|0			|

@record_mock
Scenario:[GetGameResult]ระบบได้รับข้อมูล RoundID ที่เพิ่งจบเกม ระบบสามารถดึงข้อมูล GameResult ได้
	Given The GetGameResultExecutor has been created and initialized
	And   Sent roundID'4' for get game result	
	When  Call GetGameResultExecutor()
	Then  the game result should be : RoundID '4' StartTime '10:30' EndTime '11:00' BlackPot '2001' WhitePot '2009' HandCount '87'

@record_mock
Scenario:[GetGameResult]ระบบได้รับข้อมูล RoundID อื่น ๆ ที่จบเกมแล้วและมีข้อมูลอยู่ใน Database ระบบสามารถดึงข้อมูล GameResult ได้
	Given The GetGameResultExecutor has been created and initialized
	And   Sent roundID'2' for get game result
	When  Call GetGameResultExecutor()
	Then  the game result should be : RoundID '2' StartTime '09:30' EndTime '10:00' BlackPot '500' WhitePot '499' HandCount '52'

@record_mock
Scenario:[GetGameResult]ระบบได้รับข้อมูล RoundID อื่น ๆ ที่ยังไม่มีข้อมูลอยู่ใน Database ได้ข้อมูล GameResult เป็น null
	Given The GetGameResultExecutor has been created and initialized
	And   Sent roundID'10' for get game result
	When  Call GetGameResultExecutor()
	Then  the game result should be null

@record_mock
Scenario:[GetGameResult]ระบบได้รับข้อมูล RoundID ที่ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล GameResult ได้
	Given The GetGameResultExecutor has been created and initialized
	And   Sent roundID'-5' for get game result	
	When  Call GetGameResultExecutor() for validate roundID
	Then  the game result should be throw exception

