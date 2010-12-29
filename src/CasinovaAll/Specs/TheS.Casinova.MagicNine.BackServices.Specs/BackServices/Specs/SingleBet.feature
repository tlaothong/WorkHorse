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
	|Khag		|0.50			|45				|
	|Ple		|0.99			|452			|

	Given (SingleBet)server has bet information as:
	|RoundID	|UserName	|BetDateTime		|
	|1			|OhAe		|2553/3/12 10:23	|
	|1			|OhAe		|2553/3/12 10:25	|
	|1			|Boy		|2553/3/12 10:26	|
	|1			|OhAe		|2553/3/12 10:28	|
	|1			|Au			|2553/3/12 10:29	|
	|1			|OhAe		|2553/3/12 10:23	|
	|1			|OhAe		|2553/3/12 10:25	|
	|1			|Boy		|2553/3/12 10:26	|
	|2			|OhAe		|2553/3/12 10:28	|
	|2			|Au			|2553/3/12 10:29	|
	|2			|OhAe		|2553/3/12 10:23	|
	|2			|OhAe		|2553/3/12 10:25	|
	|2			|Boy		|2553/3/12 10:26	|
	|2			|OhAe		|2553/3/12 10:28	|
	|2			|Au			|2553/3/12 10:29	|

	Given (SingleBet)server has game round information as:
	|RoundID	|WinnerPoint	|
	|1			|9				|
	|2			|99				|
	|3			|999			|
	|4			|9999			|
		
@record_mock
Scenario: (MagicNine_SingleBet)ผู้เล่นลงพนันเอง โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนันของผู้เล่นและหักเฉพาะชิฟตาย
	Given The SingleBetExecutor has been created and initialized
	And (MagicNine_SingleBet)sent name: 'OhAe' the player's balance should recieved
	And (MagicNine_SingleBet)sent roundID: '2' the game pot should be calculate
	And (MagicNine_SingleBet)sent roundID: '2' the game round information should recieved
	And (MagicNine_SingleBet)the player's balance should be update(UserName: 'OhAe', BonusChips: '462.61', Chips: '200')
	And the bet information assume dateTime as: '2553/3/12 10:23'(RoundID: '2', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', DateTime: '2553/3/12 10:23') should be create
	When call SingleBetExecutor(RoundID: '2', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: (MagicNine_SingleBet)ผู้เล่นลงพนันเอง โดยผู้เล่นมีชิฟพอและชิฟตายน้อยกว่าค่าดูสีที่ชนะระบบหักชิฟเป็นเพิ่ม ระบบบันทึกข้อมูลการลงพนันของผู้เล่นและหักชิฟเป็นและชิฟตาย
	Given The SingleBetExecutor has been created and initialized
	And (MagicNine_SingleBet)sent name: 'Khag' the player's balance should recieved
	And (MagicNine_SingleBet)sent roundID: '2' the game pot should be calculate
	And (MagicNine_SingleBet)sent roundID: '2' the game round information should recieved
	And (MagicNine_SingleBet)the player's balance should be update(UserName: 'Khag', BonusChips: '0', Chips: '44.5')
	And the bet information assume dateTime as: '2553/3/12 10:23'(RoundID: '2', UserName: 'Khag', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', DateTime: '2553/3/12 10:23') should be create
	When call SingleBetExecutor(RoundID: '2', UserName: 'Khag', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: (MagicNine_SingleBet)ผู้เล่นลงพนันเอง โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าจำนวนเงินที่ลงพนัน แล้วชนะเกม ระบบบันทึกข้อมูลการลงพนันของผู้เล่นและหักเฉพาะชิฟตาย และคืนเงินรางวัลให้ผู้เล่น
	Given The SingleBetExecutor has been created and initialized
	And (MagicNine_SingleBet)sent name: 'OhAe' the player's balance should recieved
	And (MagicNine_SingleBet)sent roundID: '1' the game pot should be calculate
	And (MagicNine_SingleBet)sent roundID: '1' the game round information should recieved
	And (MagicNine_SingleBet)the player's balance should be update(UserName: 'OhAe', BonusChips: '462.61', Chips: '200')
	And the bet information assume dateTime as: '2553/3/12 10:23'(RoundID: '1', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', DateTime: '2553/3/12 10:23') should be create
	And Expected ReturnRewardExecutor should be call(UserName: 'OhAe', NonRefundable: '463.61', Refundable: '208')
	When call SingleBetExecutor(RoundID: '1', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: (MagicNine_SingleBet)ผู้เล่นลงพนันเอง โดยผู้เล่นมีชิฟไม่พอ ระบบแจ้งเตือนว่าผู้เล่นมีชิฟไม่พอลงพนัน
	Given The SingleBetExecutor has been created and initialized
	And (MagicNine_SingleBet)sent name: 'Boy' the player's balance should recieved
	When Expected exception and call SingleBetExecutor(RoundID: '2', UserName: 'Boy', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be throw exception
