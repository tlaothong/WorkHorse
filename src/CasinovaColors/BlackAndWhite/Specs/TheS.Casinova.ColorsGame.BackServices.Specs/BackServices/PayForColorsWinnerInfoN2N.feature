Feature: PayForColorsWinnerInfoN2N
	In order to checking all loop
	As a back server
	I want to be check PayForColorsWinnerInfo all loop

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
Scenario: the PayForColorsWinnerInfo should call complete all loop
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent UserName: 'OhAe' and expected Balance: '95'
	And sent TableID: '1', RoundID: '23' and expected winner: 'Black'
	And Expect game information should be add: 
	|UserName	|TableID	|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBlack	|TotalWhite	|Winner	|LastUpdate	|
	|OhAe		|1			|23			|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|1231		|2731		|Black	|DateTime.Today|

	When define PayForColorsWinnerInfo(UserName: 'OhAe', Balance: '100')
	And define GetRoundWinnerQuery(TableID: '1', RoundID: '23', Winner: 'Black')
	And define UpdateWinnerToGamePlayInfo(GamePlayInfo):
	|UserName	|TableID	|RoundID	|TrackingID								|OnGoingTrackingID						|TotalBlack	|TotalWhite	|Winner	|LastUpdate	|
	|OhAe		|1			|23			|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|1231		|2731		|Black	|DateTime.Today|
	And call PayForColorsWinnerInfoExecutor.Execute(PayForColorsWinnerInfoCommand);

	Then the PayForColorsWinnerInfo should call complete all loop

