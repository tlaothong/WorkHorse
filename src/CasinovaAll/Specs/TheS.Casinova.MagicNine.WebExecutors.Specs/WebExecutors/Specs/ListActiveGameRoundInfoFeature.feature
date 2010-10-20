Feature: ListActiveGameRoundInfo
	In order to list active game round information
	As a back server
	I want to be show playable game round

@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 4 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|StartTime			|EndTime		 |WinnerPoint	|GamePot	|Active	|
	|1			|10/14/2010 10:00	|10/14/2010 11:00|9				|4328		|True	|
	|2			|10/14/2010 10:00	|10/14/2010 11:00|99			|272		|True	|
	|3			|10/14/2010 10:00	|10/14/2010 11:00|999			|712		|True	|
	|4			|10/14/2010 10:00	|10/14/2010 11:00|9999			|432		|True	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be as:
	|RoundID	|StartTime			|EndTime		 |WinnerPoint	|GamePot	|Active	|
	|1			|10/14/2010 10:00	|10/14/2010 11:00|9				|4328		|True	|
	|2			|10/14/2010 10:00	|10/14/2010 11:00|99			|272		|True	|
	|3			|10/14/2010 10:00	|10/14/2010 11:00|999			|712		|True	|
	|4			|10/14/2010 10:00	|10/14/2010 11:00|9999			|432		|True	|

@record_mock
Scenario: ระบบมีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่ 2 โต๊ะ, ระบบดึงข้อมูลโต๊ะเกมทั้งหมดที่เปิดใช้งาน
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|StartTime			|EndTime			|WinnerPoint	|GamePot	|Active	|
	|1			|10/14/2010 10:00	|10/14/2010 10:30	|9				|4328		|False	|
	|2			|10/14/2010 10:00	|10/14/2010 11:00	|99				|272		|True	|
	|3			|10/14/2010 10:00	|10/14/2010 11:00	|999			|712		|True	|
	|4			|10/14/2010 10:00	|10/14/2010 10:30	|9999			|432		|False	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be as:
	|RoundID	|StartTime			|EndTime		 |WinnerPoint	|GamePot	|Active	|
	|2			|10/14/2010 10:00	|10/14/2010 11:00|99			|272		|True	|
	|3			|10/14/2010 10:00	|10/14/2010 11:00|999			|712		|True	|
	
@record_mock
Scenario: ระบบไม่มีข้อมูลโต๊ะเกมที่เปิดใช้งานอยู่
	Given The ListActiveGameRoundInfoExecutor has been created and initialized
	And server has 4 game round information  in data
	|RoundID	|StartTime			|EndTime			|WinnerPoint	|GamePot	|Active	|
	|1			|10/14/2010 10:00	|10/14/2010 10:00	|9				|4328		|False	|
	|2			|10/14/2010 10:00	|10/14/2010 10:00	|99				|272		|False	|
	|3			|10/14/2010 10:00	|10/14/2010 10:00	|999			|712		|False	|
	|4			|10/14/2010 10:00	|10/14/2010 10:00	|9999			|432		|False	|

	When call ListActiveGameRoundInfoExecutor()
	Then the result should be null
	