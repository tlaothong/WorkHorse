Feature: SingleBet
	In order to bet game by player
	As a back server
	I want to be create bet information to server

@record_mock
Background: SingleBet
	Given (SingleBet)server has player information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|463.61			|200			|	
	|Boy		|0.99			|0				|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|
	|Game		|1				|5				|
	|Khag		|0.52			|45				|
	|Ple		|0.99			|452			|

@record_mock
Scenario: (SingleBet)ผู้เล่นลงพนันเอง โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าจำนวนเงินที่ลงพนัน ระบบบันทึกประวัติการลงพนันของผู้เล่นและหักเฉพาะชิฟตาย
	Given The SingleBetExecutor has been created and initialized
	And sent name: 'OhAe' the player's balance should recieved
	And (SingleBet)the player's balance should be update only bonuschips, Amount: '1'
	And the bet information assume dateTime as: '2553/3/12 10:23'(RoundID: '1', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', DateTime: '2553/3/12 10:23') should be create
	When call SingleBet(RoundID: '1', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: (SingleBet)ผู้เล่นลงพนันเอง โดยผู้เล่นมีชิฟพอและชิฟตายน้อยกว่าค่าดูสีที่ชนะระบบหักชิฟเป็นเพิ่ม ระบบบันทึกประวัติการดำเนินการ(ดูสีที่ชนะ)ของผู้เล่นและหักชิฟเป็นและชิฟตาย
	Given The SingleBetExecutor has been created and initialized
	And sent name: 'OhAe' the player's balance should recieved
	And (SingleBet)the player's balance should be update only bonuschips, Amount: '1'
	And the bet information assume dateTime as: '2553/3/12 10:23'(RoundID: '1', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', DateTime: '2553/3/12 10:23') should be create
	When call SingleBet(RoundID: '1', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: ได้รับข้อมูล RoundID, UserName, ระบบตรวจสอบเงินสำหรับลงพนันพอ, ระบบหักเงินผู้เล่นและบันทึกข้อมูลการลงพนัน2
	Given The SingleBetExecutor has been created and initialized
	And sent name: 'Nit' the player's balance should recieved
	And sent RoundID: '3' the round pot should recieved
	And the expected balance should be: '35.99'
	And the round information(RoundID: '3', GamePot: '713') should be update
	And the bet information(RoundID: '3', UserName: 'Nit', BetOrder: '713', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be create
	When call SingleBet(RoundID: '3', UserName: 'Nit', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: ได้รับข้อมูล RoundID, UserName, ระบบตรวจสอบเงินสำหรับลงพนันไม่พอ, ระบบแจ้งเตือนว่าเงินผู้เล่นไม่พอ
	Given The SingleBetExecutor has been created and initialized
	And sent name: 'Au' the player's balance should recieved
	And sent RoundID: '2' the round pot should recieved
	And the expected balance less than bet cost
	When call SingleBet(RoundID: '2', UserName: 'Au', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then server should throw an error
