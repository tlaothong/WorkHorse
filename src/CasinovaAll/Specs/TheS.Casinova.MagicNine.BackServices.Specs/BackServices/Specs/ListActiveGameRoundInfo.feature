Feature: ListActiveGameRoundInfo
	In order to list active game round information
	As a back server
	I want to be show playable game round

@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 4 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveRoundExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|StartTime			|EndTime		|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|				|9				|4328.00	|True	|
	|2			|2553/3/12 10:00	|				|99				|272.00		|True	|
	|3			|2553/3/12 10:00	|				|999			|712.00		|True	|
	|4			|2553/3/12 10:00	|				|9999			|432.00		|True	|

	When call ListActiveGameRoundExecutor()
	Then the result should be as:
	|RoundID	|StartTime			|EndTime		|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|				|9				|4328.00	|True	|
	|2			|2553/3/12 10:00	|				|99				|272.00		|True	|
	|3			|2553/3/12 10:00	|				|999			|712.00		|True	|
	|4			|2553/3/12 10:00	|				|9999			|432.00		|True	|

	@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 2 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveRoundExecutor has been created and initialized
	And server has 6 active game round information  in data
	|RoundID	|StartTime			|EndTime			|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|2553/3/12 10:30	|9				|4328.00	|False	|
	|2			|2553/3/12 10:00	|					|99				|272.00		|True	|
	|3			|2553/3/12 10:00	|					|999			|712.00		|True	|
	|4			|2553/3/12 10:00	|2553/3/12 10:40	|9999			|432.00		|False	|
	|5			|2553/3/12 10:31	|					|0.9			|272.32		|True	|
	|6			|2553/3/12 10:41	|					|0.99			|712.45		|True	|


	When call ListActiveGameRoundExecutor()
	Then the result should be as:
	|RoundID	|StartTime			|EndTime		|WinnerPoint	|GamePot	|Active	|
	|2			|2553/3/12 10:00	|				|99				|272.00		|True	|
	|3			|2553/3/12 10:00	|				|999			|712.00		|True	|
	|5			|2553/3/12 10:31	|				|0.9			|272.32		|True	|
	|6			|2553/3/12 10:41	|				|0.99			|712.45		|True	|
