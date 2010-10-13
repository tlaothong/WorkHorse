Feature: UpdateOnGoingTrackingID
	In order to update game play information
	As a back server
	I want to be update OnGoingTrackingID into game play information  

@record_mock
Background:
	Given Define GamePlayInformation input as:
	|RoundID	|UserName	|OnGoingTrackingID						|
	|123		|OhAe		|B21F8971-DBAB-400F-9D95-151BA24875C1	|

@record_mock
Scenario: ได้รับข้อมูล GamePlayInformation, ระบบ update OnGoingTrackingID 
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And Expect GamePlayInformation(RoundID: '123', UserName: 'OhAe', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') input should be add
	When call UpdateOnGoingTrackingID(GamePlayInformation(RoundID: '123', UserName: 'OhAe', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1'))
	Then the game play information should be saved by calling IColorsGameDataAccess.ApplyAction(GamePlayInformation, PayForWinnerColorsInfoCommand)
