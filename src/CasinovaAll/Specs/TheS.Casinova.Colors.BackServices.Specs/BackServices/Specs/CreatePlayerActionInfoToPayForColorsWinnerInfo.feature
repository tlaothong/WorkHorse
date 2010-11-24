Feature: CreatePlayerActionInfoToPayForColorsWinnerInfo
	In order to create player action information
	As a back server
	I want to be create player action information after decrease player balance

@record_mock
Scenario: ได้รับข้อมูล PlayerActionInfo, ระบบบันทึกข้อมูลของผู้เล่น
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And Expect result should be add PlayerActionInfo(RoundID: '13', UserName: 'OhAe', ActionType: 'GetWinner', Amount: '5')
	When call CreatePlayerActionInfo(PlayerActionInfo(RoundID: '13', UserName: 'OhAe', ActionType: 'GetWinner', Amount: '5'))
    Then the PlayerActionInfo should be saved to the ICreatePlayerActionInfo.Create(PlayerActionInfo, PayForColorsWinnerInfoCommand) with expected data
