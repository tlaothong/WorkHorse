Feature: GetRoundWinner
	In order to get black pot and white pot of round
	As a math idiot
	I want to be told the round winner at that time 

@record_mock
Background: 
Given server has round information as:
	|RoundID	|BlackPot	|WhitePot	|
	|10			|123.24		|231.00		|
	|11			|42.00		|83.00		|
	|12			|10.01		|15.23		|

@record_mock
Scenario: ได้รับข้อมูล RoundID, ระบบดึงข้อมูล black pot, white pot เพื่อคำนวณผู้ชนะและส่งกลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent RoundID: '12' expected result should be BlackPot: '10.01', WhitePot: '15.23'
	When call Get(PayForColorsWinnerInfoCommand), Round: '12'
	Then the result should be same as expected BlackPot and WhitePot

@record_mock
Scenario: ได้รับข้อมูล RoundID, ระบบดึงข้อมูล black pot, white pot เพื่อคำนวณผู้ชนะและส่งกลับ2
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent RoundID: '11' expected result should be BlackPot: '42.00', WhitePot: '83.00'
	When call Get(PayForColorsWinnerInfoCommand), Round: '11'
	Then the result should be same as expected BlackPot and WhitePot