Feature: GetRoundWinnerQuery
	In order to get current round winner
	As a back server
	I want to be told the current round winner
	
@record_mock
Background: 
Given server has game information:
|TableID	|RoundID	|Winner	|
|1			|23			|Black	|
|2			|24			|White	|
|3			|25			|White	|
|4			|26			|Black	|
|5			|27			|White	|

@record_mock
Scenario: ระบบรับข้อมูล TableID และ RoundID, ระบบดึงข้อมูล Winner กลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent TableID: '2', RoundID: '24' and expected winner: 'White'
	When call GetRoundWinnerQuery(TableID: '2', RoundID: '24')
	Then the round winner should be same as expected winner

@record_mock
Scenario: ระบบรับข้อมูล TableID และ RoundID, ระบบดึงข้อมูล Winner กลับ2
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent TableID: '4', RoundID: '26' and expected winner: 'Black'
	When call GetRoundWinnerQuery(TableID: '4', RoundID: '26')
	Then the round winner should be same as expected winner

@record_mock
Scenario: ระบบรับข้อมูล TableID และ RoundID ที่ไม่มีในระบบ, ระบบดึงข้อมูล Winner กลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent TableID: '1', RoundID: '99' and expected winner: null
	When call GetRoundWinnerQuery(TableID: '1', RoundID: '99')
	Then the game result should be null
