Feature: GetGameResult
	In order to get game result
	As a system
	I want to get game result when game finish

@record_mock
Scenario: ส่งค่า RoundID ที่เพิ่งจบเกมและสามารถตรวจสอบข้อมูลผลเกมได้
	Given The GameRoundInformation has been created and initialized
	And Server has game information 
		|BlackPot	| WhitePot	|HandCount	|
		|23		    |24			|13			|
	When Call GetGameResultExecutor(RoundID'1')
	Then the game result should be 
		|BlackPot| WhitePot	|HandCount	|
		|23	     |24	    |13			|

@record_mock
Scenario: ส่งค่า RoundID อื่น ๆ ที่จบเกมแล้วและมีข้อมูลอยู่ใน Database
	Given The GameRoundInformation has been created and initialized
	And Server has game information
		|BlackPot	| WhitePot	|HandCount	|
		|50		    |100		|20			|
	When Call GetGameResultExecutor(RoundID'2')
	Then the game result should be 
		|BlackPot| WhitePot	|HandCount	|
		|50		 |100		|20	        |

@record_mock
Scenario: ส่งค่า RoundID ที่ไม่ถูกต้อง
	Given The GameRoundInformation has been created and initialized
	And Server has game information
		|BlackPot	| WhitePot	|HandCount	|
		
	When Call GetGameResultExecutor(RoundID'-3')
	Then the game result should be throw exception

@record_mock
Scenario: ไม่ส่งค่า RoundID 
	Given The GameRoundInformation has been created and initialized
	And Server has game information
		|BlackPot	| WhitePot	|HandCount	|
		
	When Call GetGameResultExecutor(RoundID'-3')
	Then the game result should be throw exception		
	