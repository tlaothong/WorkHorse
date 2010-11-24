Feature: ListActiveGameRoundInfo
	In order to list active game round information
	As a system
	I want to list active game round

@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 4 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|WinnerPoint	|Active	|
	|1			|9				|True	|
	|2			|99				|True	|
	|3			|999			|True	|
	|4			|9999			|True	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be as:
	|RoundID	|WinnerPoint	|Active	|
	|1			|9				|True	|
	|2			|99				|True	|
	|3			|999			|True	|
	|4			|9999			|True	|


@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 2 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|WinnerPoint	|Active	|
	|1			|9				|False	|
	|2			|99				|True	|
	|3			|999			|True	|
	|4			|9999			|False	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be as:
	|RoundID	|WinnerPoint	|Active	|
	|2			|99				|True	|
	|3			|999			|True	|
	
@record_mock
Scenario: ระบบไม่มีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|WinnerPoint	|Active	|
	|1			|9				|False	|
	|2			|99				|False	|
	|3			|999			|False	|
	|4			|9999			|False	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be null
	