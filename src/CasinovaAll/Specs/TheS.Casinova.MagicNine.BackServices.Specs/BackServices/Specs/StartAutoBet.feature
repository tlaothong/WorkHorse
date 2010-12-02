Feature: StartAutoBet
	In order to bet
	As a back server
	I want to be automatic betting by server

@record_mock
Background: 
	Given (StartAutoBet)server has player information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|463.61			|200			|	
	|Boy		|0.99			|0				|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|
	|Game		|1				|5				|
	|Khag		|0.52			|45				|
	|Ple		|0.99			|452			|

@record_mock
Scenario: (StartAutoBet)ผู้เล่นลงพนันอัตโนมัติ โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าจำนวนเงินที่ลงพนัน ระบบบันทึกประวัติการลงพนันของผู้เล่นและหักเฉพาะชิฟตาย แล้วส่งข้อมูลให้ระบบ AutoBet Engine ทำงานต่อ
	Given The StartAutoBetExecutor has been created and initialized
	And (StartAutoBet)sent name: 'OhAe' the player's balance should recieved
	And (StartAutoBet)the player's balance should be update only bonuschips, Amount: '200'
	And the autobet information should be update assume dateTime as: '2553/11/24 14:43'(UserName: 'OhAe', RoundID: '1', Amount: '200', Interval: '5', AutoBetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BetTrackingID: 'A21F8971-DBAB-400F-9D95-151BA24875C2')
	And the StartAuto Engine shoule be call as: (UserName: 'OhAe', RoundID: '1', Amount: '200', Interval: '5', AutoBetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BetTrackingID: 'A21F8971-DBAB-400F-9D95-151BA24875C2')
	When call StartAutoBetExecutor(UserName: 'OhAe', RoundID: '1', Amount: '200', Interval: '5', AutoBetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BetTrackingID: 'A21F8971-DBAB-400F-9D95-151BA24875C2')
	Then autobet engine should be execute

@record_mock
Scenario: (StartAutoBet)ผู้เล่นลงพนันอัตโนมัติ โดยผู้เล่นมีชิฟพอและชิฟตายน้อยกว่าค่าดูสีที่ชนะระบบหักชิฟเป็นเพิ่ม ระบบบันทึกประวัติการลงพนันของผู้เล่นและหักเฉพาะชิฟตาย แล้วส่งข้อมูลให้ระบบ AutoBet Engine ทำงานต่อ
	Given The StartAutoBetExecutor has been created and initialized
	And (StartAutoBet)sent name: 'Ple' the player's balance should recieved
	And (StartAutoBet)the player's balance should be update both chips, Amount: '200'
	And the autobet information should be update assume dateTime as: '2553/11/24 14:43'(UserName: 'Ple', RoundID: '1', Amount: '200', Interval: '5', AutoBetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BetTrackingID: 'A21F8971-DBAB-400F-9D95-151BA24875C2')
	And the StartAuto Engine shoule be call as: (UserName: 'Ple', RoundID: '1', Amount: '200', Interval: '5', AutoBetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BetTrackingID: 'A21F8971-DBAB-400F-9D95-151BA24875C2')
	When call StartAutoBetExecutor(UserName: 'Ple', RoundID: '1', Amount: '200', Interval: '5', AutoBetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BetTrackingID: 'A21F8971-DBAB-400F-9D95-151BA24875C2')
	Then autobet engine should be execute

@record_mock
Scenario: (StartAutoBet)ผู้เล่นลงพนันอัตโนมัติ โดยผู้เล่นมีเงินไม่พอ ระบบแจ้งเตือนผู้เล่นว่าเงินไม่พอ
	Given The StartAutoBetExecutor has been created and initialized
	And (StartAutoBet)sent name: 'Ple' the player's balance should recieved
	When Expected exeception and call StartAutoBetExecutor(UserName: 'Ple', RoundID: '1', Amount: '5200', Interval: '5', AutoBetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BetTrackingID: 'A21F8971-DBAB-400F-9D95-151BA24875C2')
	Then the result should be throw exception
