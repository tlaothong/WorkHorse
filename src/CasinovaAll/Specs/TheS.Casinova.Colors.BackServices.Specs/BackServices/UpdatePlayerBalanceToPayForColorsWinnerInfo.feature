Feature: UpdatePlayerBalanceToPayForColorsWinnerInfo
	In order to update player balance
	As a back server
	I want to be update player balance to pay for colors winner information

Background:
	Given server has player information as:
	|UserName	|Balance	|
	|OhAe		|463.61		|
	|Boy		|121.21		|
	|Nit		|36.99		|
	|Au			|234.00		|

	And server has player action informations as:
	|RoundID	|UserName	|ActionType	|DateTime(for example, not use this row)			|
	|12			|OhAe		|GetWinner	|12/3/2553 10:00	|
	|12			|Boy		|GetWinner	|12/3/2553 11:20	|
	|12			|OhAe		|Black		|12/3/2553 11:22	|
	|12			|OhAe		|GetWinner	|12/3/2553 11:28	|
	|13			|Nit		|GetWinner	|13/3/2553 10:00	|
	|13			|Boy		|White		|13/3/2553 11:20	|
	|14			|OhAe		|GetWinner	|15/3/2553 11:22	|
	|14			|OhAe		|Black		|15/3/2553 11:28	|

	And server has round informations as:
	|RoundID	|BlackPot	|WhitePot	|
	|10			|21.31		|235.12		|
	|11			|2841.23	|382.2		|
	|12			|98.98		|632.01		|
	|13			|65.83		|23.55		|
	|14			|2.99		|7.01		|

@record_mock
Scenario: หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นเคยเสียค่าดูข้อมูลแล้ว และส่งข้อมูลผู้ชนะกลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And the player's balance should recieved, name: 'OhAe'
	And the player's action information should recieved, RoundID: '12', UserName: 'OhAe'
	And the round information should recieved, roundID: '12'
	And the expected balance should be: '462.61'
	And the player's action information(RoundID: '12', UserName: 'OhAe', ActionType: 'GetWinner', Amount: '1.0') should be create
	And the game play information(RoundID: '12', UserName: 'OhAe', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '12', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'Black') should be update
	When call PayForColorsWinnerInfo(UserName: 'OhAe', RoundID: '12', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated

@record_mock
Scenario: หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นยังไม่เคยเสียค่าดูข้อมูล และส่งข้อมูลผู้ชนะกลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And the player's balance should recieved, name: 'Boy'
	And the player's action information should recieved, RoundID: '13', UserName: 'Boy'
	And the round information should recieved, roundID: '13'
	And the expected balance should be: '116.21'
	And the player's action information(RoundID: '13', UserName: 'Boy', ActionType: 'GetWinner', Amount: '5.0') should be create
	And the game play information(RoundID: '13', UserName: 'Boy', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '13', UserName: 'Boy', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'White') should be update
	When call PayForColorsWinnerInfo(UserName: 'Boy', RoundID: '13', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated
