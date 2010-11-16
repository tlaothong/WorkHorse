Feature: PayForColorsWinnerInformation
	In order to pay for colors winner information
	As a back server
	I want to be told the round winner at this time

@record_mock
Background: PayForColorsWinner
	Given (BetColor)server has player profile information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|463.61			|200			|	
	|Boy		|121.99			|321			|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|

	And server has player action informations as:
	|RoundID	|UserName	|ActionType	|DateTime(for example, not use this row)			|
	|12			|OhAe		|GetWinner	|2553/3/12 10:00	|
	|12			|Boy		|GetWinner	|2553/3/12 11:20	|
	|12			|OhAe		|Black		|2553/3/12 11:22	|
	|12			|OhAe		|GetWinner	|2553/3/12 11:28	|
	|13			|Nit		|GetWinner	|2553/3/12 10:00	|
	|13			|Boy		|White		|2553/3/12 11:20	|
	|14			|OhAe		|GetWinner	|2553/3/12 11:22	|
	|14			|OhAe		|Black		|2553/3/12 11:28	|

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
	And sent name: 'OhAe' the player's balance should recieved
	And sent roundID: '12', userName: 'OhAe' the player's action information should recieved
	And sent roundID: '12' the round information should recieved
	And the expected balance should be: '462.61'
	And the player's action information(RoundID: '12', UserName: 'OhAe', ActionType: 'GetWinner', Amount: '1.0') should be create
	And the game play information(RoundID: '12', UserName: 'OhAe', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '12', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'Black') should be update
	When call PayForColorsWinnerInfo(UserName: 'OhAe', RoundID: '12', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated

@record_mock
Scenario: หักเงินผู้เล่นจากข้อมูลที่ได้รับมา โดยผู้เล่นยังไม่เคยเสียค่าดูข้อมูล และส่งข้อมูลผู้ชนะกลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent name: 'Boy' the player's balance should recieved
	And sent roundID: '13', userName: 'Boy' the player's action information should recieved
	And sent roundID: '13' the round information should recieved
	And the expected balance should be: '116.21'
	And the player's action information(RoundID: '13', UserName: 'Boy', ActionType: 'GetWinner', Amount: '5.0') should be create
	And the game play information(RoundID: '13', UserName: 'Boy', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '13', UserName: 'Boy', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'White') should be update
	When call PayForColorsWinnerInfo(UserName: 'Boy', RoundID: '13', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated
