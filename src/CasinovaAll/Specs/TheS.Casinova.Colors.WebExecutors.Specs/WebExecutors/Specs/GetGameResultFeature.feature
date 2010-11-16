Feature: GetGameResult
	In order to get game result
	As a system
	I want to get game result when game finish

Background:
	Given Server has game result information 
		|RoundId|StartTime|EndTime|BlackPot	| WhitePot	|HandCount	|
		|1		|09:00	  |09:30  |23		|24			|13			|
		|2		|09:30	  |10:00  |500		|499		|52			|
		|3		|10:00	  |10:30  |1500		|1459		|82			|
		|4		|10:30	  |11:00  |2001		|2009		|87		    |
		|5		|11:00	  |11:30  |1655		|1700		|107		|

@record_mock
Scenario: ระบบได้รับข้อมูล RoundID ที่เพิ่งจบเกม ระบบสามารถดึงข้อมูล GameResult ได้
	Given The GetGameResultExecutor has been created and initialized		
	When  Call GetGameResultExecutor(RoundID'5')
	Then  the game result should be : RoundID '5' StartTime '11:00' EndTime '11:30' BlackPot '1655' WhitePot '1700' HandCount '107'

@record_mock
Scenario: ระบบได้รับข้อมูล RoundID อื่น ๆ ที่จบเกมแล้วและมีข้อมูลอยู่ใน Database ระบบสามารถดึงข้อมูล GameResult ได้
	Given The GetGameResultExecutor has been created and initialized
	When  Call GetGameResultExecutor(RoundID'2')
	Then  the game result should be : RoundID '2' StartTime '10:00' EndTime '10:30' BlackPot '500' WhitePot '499' HandCount '52'

@record_mock
Scenario:  ระบบได้รับข้อมูล RoundID ที่ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล GameResult ได้
	Given The GetGameResultExecutor has been created and initialized	
	When  Call GetGameResultExecutor(RoundID'-3')
	Then  the game result should be throw exception

