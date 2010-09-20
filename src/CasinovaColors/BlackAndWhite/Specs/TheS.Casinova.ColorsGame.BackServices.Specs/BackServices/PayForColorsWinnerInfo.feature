Feature: PayForColorsWinnerInfo
	In order to pay money for winner information
	As a back server
	I want to be decrease player money

@record_mock
Scenario: ผู้ใช้มีเงินพอ, ระบบหักเงินจากผู้ใช้
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent UserName: 'OhAe' and expected Balance: '95'
	When call PayForColorsWinnerInfo(UserName: 'OhAe', Balance: '100')
	Then the player information should be saved by calling IColorsGameDataAccess.ApplyAction(PlayerInformation, cmd)

@record_mock
Scenario: ผู้ใช้มีเงินพอดีหัก, ระบบหักเงินจากผู้ใช้2
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent UserName: 'OhAe' and expected Balance: '0'
	When call PayForColorsWinnerInfo(UserName: 'OhAe', Balance: '5')
	Then the player information should be saved by calling IColorsGameDataAccess.ApplyAction(PlayerInformation, cmd)

@record_mock
Scenario: ผู้ใช้มีเงินไม่พอ, ระบบแจ้งเตือน
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	When call PayForColorsWinnerInfo(UserName: 'OhAe', Balance: '0')
	Then ระบบแจ้งเตือนว่าเงินไม่พอ

@record_mock
Scenario: ผู้ใช้มีเงินไม่พอ, ระบบแจ้งเตือน2
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	When call PayForColorsWinnerInfo(UserName: 'OhAe', Balance: '-10')
	Then ระบบแจ้งเตือนว่าเงินไม่พอ
