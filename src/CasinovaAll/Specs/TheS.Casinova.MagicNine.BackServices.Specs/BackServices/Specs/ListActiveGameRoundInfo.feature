Feature: ListActiveGameRoundInfo
	In order to list active game round information
	As a back server
	I want to be show playable game round

@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 4 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveRoundExecutor has been created and initialized
	And server has 4 game round information as:
	|RoundID	|StartTime			|EndTime		|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|				|9				|4328		|True	|
	|2			|2553/3/12 10:00	|				|99				|272		|True	|
	|3			|2553/3/12 10:00	|				|999			|712		|True	|
	|4			|2553/3/12 10:00	|				|9999			|432		|True	|

	And expected recieved 4 active GameRoundInformation(s)
	When call ListActiveGameRoundExecutor()
	Then the result should be as:
	|RoundID	|StartTime			|EndTime		|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|				|9				|4328		|True	|
	|2			|2553/3/12 10:00	|				|99				|272		|True	|
	|3			|2553/3/12 10:00	|				|999			|712		|True	|
	|4			|2553/3/12 10:00	|				|9999			|432		|True	|

	@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 2 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveRoundExecutor has been created and initialized
	And server has 2 game round information and expect recieved 2 active GameRoundInformation(s)
	|RoundID	|StartTime			|EndTime		|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|				|9				|4328		|False	|
	|2			|2553/3/12 10:00	|				|99				|272		|True	|
	|3			|2553/3/12 10:00	|				|999			|712		|True	|
	|4			|2553/3/12 10:00	|				|9999			|432		|False	|

	When call ListActiveGameRoundExecutor()
	Then the result should be as:
	|RoundID	|StartTime			|EndTime		|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|				|9				|4328		|False	|
	|4			|2553/3/12 10:00	|				|9999			|432		|False	|
