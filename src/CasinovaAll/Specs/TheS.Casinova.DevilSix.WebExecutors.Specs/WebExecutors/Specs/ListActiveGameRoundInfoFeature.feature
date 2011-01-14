Feature: ListActiveGameRoundInfo
	In order to ให้ client นำข้อมูลไปแสดงที่ UI เพื่อให้ผู้เล่นสามารถเลือกโต๊ะเกมได้
	As a Web server
	I want to ดึงข้อมูลโต๊ะเกมที่ active

@record_mock
Scenario:[ListActiveGameRound]ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 4 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|WinnerPoint	|Active	|
	|1			|6				|True	|
	|2			|66				|True	|
	|3			|666			|True	|
	|4			|6666			|True	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be as:
	|RoundID	|WinnerPoint	|Active	|
	|1			|6				|True	|
	|2			|66				|True	|
	|3			|666			|True	|
	|4			|6666			|True	|

@record_mock
Scenario:[ListActiveGameRound]ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 2 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|WinnerPoint	|Active	|
	|1			|6				|False	|
	|2			|66				|True	|
	|3			|666			|True	|
	|4			|6666			|False	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be as:
	|RoundID	|WinnerPoint	|Active	|
	|2			|66				|True	|
	|3			|666			|True	|
	
@record_mock
Scenario:[ListActiveGameRound]ระบบไม่มีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|WinnerPoint	|Active	|
	|1			|6				|False	|
	|2			|66				|False	|
	|3			|666			|False	|
	|4			|6666			|False	|

	When call ListActiveGameRoundInfoExecutor()
	Then Active game round should be null
	