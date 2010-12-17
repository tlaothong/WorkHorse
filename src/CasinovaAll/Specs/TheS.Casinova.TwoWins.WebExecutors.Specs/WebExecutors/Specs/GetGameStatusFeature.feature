Feature: GetGameStatus
	In order to get game status
	As a system
	I want to get game status 

@record_mock
Background:
	Given Server has game status information 
		|RoundID	|WinnerHightNameNormal	|WinnerLowNameNormal	|WinnerHightRange	| WinnerLowRange	|Pot	|HandRange	|
		|1			|Nayit					|Nayit					|0-1000				|0-50				|3900   |0-100		|
		|2			|OhAe					|Toommy					|0-100				|0-100				|1300	|0-100		|
		|3			|Ice					|Sak					|0-1000				|0-100				|5640	|0-200		|
		|4			|Idea					|Jigsaw					|0-2000				|0-1000				|6790	|0-500		|
		|5			|Boy					|Nat					|0-100				|0-50				|1277	|0-100		|

@record_mock
Scenario:[GetGameStatus]ระบบได้รับข้อมูล RoundID ถูกต้อง ระบบสามารถดึงข้อมูลสถานะของเกมได้
	Given The GetGameStatusExecutor has been created and initialized
	And   I sent RoundID '1' to get game status
	When  Call GetGameStatusExecutor()
	Then  GameStatus information should be as : RoundID'1' WinnerHightNameNormal'Nayit' WinnerLowNameNormal'Nayit' WinnerHightRange'0-1000' WinnerLowRange'0-50' Pot'3900' HandRange'0-100'

@record_mock
Scenario:[GetGameStatus]ระบบได้รับข้อมูล RoundID ที่ไม่มีใน datatbase ได้ข้อมูลเป็น null
	Given The GetGameStatusExecutor has been created and initialized
	And   I sent RoundID '9' to get game status
	When  Call GetGameStatusExecutor()
	Then  GameStatus information should be null

@record_mock
Scenario:[GetGameStatus]ระบบได้รับข้อมูล RoundID ไม่ถูกต้อง 
	Given The GetGameStatusExecutor has been created and initialized
	And   I sent RoundID '-1' for get game status validation
	When  Call GetGameStatusExecutor() for validate input
	Then  GameStatus information should be throw exception