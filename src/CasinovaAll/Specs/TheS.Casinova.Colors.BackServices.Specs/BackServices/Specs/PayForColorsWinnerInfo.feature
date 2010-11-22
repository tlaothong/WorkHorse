Feature: PayForColorsWinnerInformation
	In order to pay for colors winner information
	As a back server
	I want to be told the round winner at this time

@record_mock
Background: PayForColorsWinner
	Given (PayForcolorsWinnerInformation)server has player profile information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|463.61			|200			|	
	|Boy		|0.99			|0				|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|
	|Game		|1				|5				|
	|Khag		|0.52			|45				|
	|Ple		|0.99			|452			|

	And (PayForcolorsWinnerInformation)server has player action informations as:
	|RoundID	|UserName	|ActionType	|DateTime(for example, not use this row)|
	|12			|OhAe		|GetWinner	|2553/3/12 10:00	|
	|12			|Boy		|GetWinner	|2553/3/12 11:20	|
	|12			|OhAe		|Black		|2553/3/12 11:22	|
	|12			|OhAe		|GetWinner	|2553/3/12 11:28	|
	|13			|Nit		|GetWinner	|2553/3/12 10:00	|
	|13			|Boy		|White		|2553/3/12 11:20	|
	|14			|OhAe		|GetWinner	|2553/3/12 11:22	|
	|14			|OhAe		|Black		|2553/3/12 11:28	|
	|15			|Khag		|Black		|2553/3/12 12:28	|
	|15			|Khag		|GetWinner	|2553/3/12 12:30	|

	And server has round informations as:
	|RoundID	|BlackPot	|WhitePot	|
	|10			|21.31		|235.12		|
	|11			|2841.23	|382.2		|
	|12			|98.98		|632.01		|
	|13			|65.83		|23.55		|
	|14			|2.99		|7.01		|
	|15			|2.15		|74			|

@record_mock
Scenario: ผู้เล่นต้องการดูข้อมูลสีที่ชนะในโต๊ะเกมที่เคยดูแล้ว โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าค่าดูสีที่ชนะ ระบบบันทึกประวัติการดำเนินการ(ดูสีที่ชนะ)ของผู้เล่นและหักเฉพาะชิฟตาย
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent name: 'OhAe' the player's balance should recieved
	And sent roundID: '12', userName: 'OhAe' the player's action information should recieved
	And sent roundID: '12' the round information should recieved
	And (GetWinner)the player's balance should be update only bonuschips, Amount: '1'
	And the player's action information(RoundID: '12', UserName: 'OhAe', ActionType: 'GetWinner', Amount: '1.0') should be create
	And the game play information(RoundID: '12', UserName: 'OhAe', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '12', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'Black') should be update
	When call PayForColorsWinnerInfo(UserName: 'OhAe', RoundID: '12', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated

@record_mock
Scenario: ผู้เล่นต้องการดูข้อมูลสีที่ชนะในโต๊ะเกมที่เคยดูแล้ว โดยผู้เล่นมีชิฟพอและชิฟตายน้อยกว่าค่าดูสีที่ชนะระบบหักชิฟเป็นเพิ่ม ระบบบันทึกประวัติการดำเนินการ(ดูสีที่ชนะ)ของผู้เล่นและหักชิฟเป็นและชิฟตาย
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent name: 'Khag' the player's balance should recieved
	And sent roundID: '15', userName: 'Khag' the player's action information should recieved
	And sent roundID: '15' the round information should recieved
	And (GetWinner)the player's balance should be update both chips, Amount: '1'
	And the player's action information(RoundID: '15', UserName: 'Khag', ActionType: 'GetWinner', Amount: '1.0') should be create
	And the game play information(RoundID: '15', UserName: 'Khag', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '15', UserName: 'Khag', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'Black') should be update
	When call PayForColorsWinnerInfo(UserName: 'Khag', RoundID: '15', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated

@record_mock
Scenario: ผู้เล่นต้องการดูข้อมูลสีที่ชนะในโต๊ะเกมที่ไม่เคยดูข้อมูล โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าค่าดูสีที่ชนะ ระบบบันทึกประวัติการดำเนินการ(ดูสีที่ชนะ)ของผู้เล่นและหักเฉพาะชิฟตาย
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent name: 'Ple' the player's balance should recieved
	And sent roundID: '12', userName: 'Ple' the player's action information should recieved
	And sent roundID: '12' the round information should recieved
	And (GetWinner)the player's balance should be update both chips, Amount: '5'
	And the player's action information(RoundID: '12', UserName: 'Ple', ActionType: 'GetWinner', Amount: '5.0') should be create
	And the game play information(RoundID: '12', UserName: 'Ple', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '12', UserName: 'Ple', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'Black') should be update
	When call PayForColorsWinnerInfo(UserName: 'Ple', RoundID: '12', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated

@record_mock
Scenario: ผู้เล่นต้องการดูข้อมูลสีที่ชนะในโต๊ะเกมที่ไม่เคยดูข้อมูล โดยผู้เล่นมีชิฟพอและชิฟตายน้อยกว่าค่าดูสีที่ชนะระบบหักชิฟเป็นเพิ่ม ระบบบันทึกประวัติการดำเนินการ(ดูสีที่ชนะ)ของผู้เล่นและหักชิฟเป็นและชิฟตาย
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent name: 'Game' the player's balance should recieved
	And sent roundID: '12', userName: 'Game' the player's action information should recieved
	And sent roundID: '12' the round information should recieved
	And (GetWinner)the player's balance should be update both chips, Amount: '5'
	And the player's action information(RoundID: '12', UserName: 'Game', ActionType: 'GetWinner', Amount: '5.0') should be create
	And the game play information(RoundID: '12', UserName: 'Game', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be update
	And the game play information(RoundID: '12', UserName: 'Game', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', Winner: 'Black') should be update
	When call PayForColorsWinnerInfo(UserName: 'Game', RoundID: '12', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the update player's balance part should be updated

@record_mock
Scenario: ผู้เล่นต้องการดูข้อมูลสีที่ชนะ โดยผู้เล่นมีชิฟไม่พอค่าดำเนินการ ระบบแจ้งเตือนผู้เล่น
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent name: 'Boy' the player's balance should recieved
	And sent roundID: '13', userName: 'Boy' the player's action information should recieved
	When Expected validation exception and call PayForColorsWinnerInfo(UserName: 'Boy', RoundID: '13', OnGoingTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be throw exception