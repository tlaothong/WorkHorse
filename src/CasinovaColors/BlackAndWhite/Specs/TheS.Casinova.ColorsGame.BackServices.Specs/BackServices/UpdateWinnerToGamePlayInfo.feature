Feature: UpdateWinnerToGamePlayInfo
	In order to update game play information
	As a back server
	I want to be update winner to game play information

@record_mock
Scenario: ระบบรับข้อมูล GameInformation, ระบบบันทึกข้อมูลลงในฐานข้อมูล
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And Expect game information should be add: 
	|UserName	|TableID	|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBlack	|TotalWhite	|Winner	|LastUpdate	|
	|OhAe		|1			|23			|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|1231		|2731		|Black	|DateTime.Today|

	When call UpdateWinnerToGamePlayInfo(GamePlayInfo)
	|UserName	|TableID	|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBlack	|TotalWhite	|Winner	|LastUpdate	|
	|OhAe		|1			|23			|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|1231		|2731		|Black	|DateTime.Today|

	Then the game play information should be saved by calling IColorsGameDataAccess.ApplyAction(GamePlayInformation, cmd)
