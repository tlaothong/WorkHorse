Feature: SingleBet
	In order to only one betting
	As a back server
	I want to be create bet information

@record_mock
Background: Twowins_SingleBet
	Given (Twowins_SingleBet)server has player information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|463.61			|200			|	
	|Boy		|0.99			|0				|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|
	|Game		|1				|5				|
	|Khag		|0.52			|45				|
	|Ple		|0.99			|452			|

	And (Twowins_SingleBet)server has round information as:
	|RoundID	|FromDateTime	|ThruDateTime	|CriticalTime	|Pot		|
	|1			|-20			|30				|25				|759.00		|
	|2			|-5				|5				|-3				|5266.00	|
	|3			|-10			|90				|85				|165.00		|
	|4			|0				|0				|0				|15648.00	|

@record_mock
Scenario: (Twowins_SingleBet)ผู้เล่นลงพนันมือเดียวในช่วงเวลาปกติ โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนัน, ประวัติการดำเนินการ และหักเฉพาะชิฟตายของผู้เล่น
	Given (Twowins_SingleBet)The SingleBetExecutor has been created and initialized
	And (Twowins_SingleBet)sent name: 'OhAe' the player's balance should recieved
	And (Twowins_SingleBet)sent roundID: '1' the round information should recieved
	And (Twowins_SingleBet)the round pot information should be update(RoundID: '1', Pot: '769')
	And (Twowins_SingleBet)the player's balance should be update(UserName: 'OhAe', BonusChips: '453.61', Chips: '200')
	And (Twowins_SingleBet)the action log information should be create (RoundID: '1', UserName: 'OhAe', ActionType: 'SingleBet', Amount: '10', OldAmount: '-1', HandStatus: 'Normal', Change: 'false'
	And (Twowins_SingleBet)the bet information (RoundID: '1', UserName: 'OhAe', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BonusChips: '10', Chips: '0', HandStatus: 'Normal', CanChange: 'true') should be create
	When (Twowins_SingleBet)call SingleBetExecutor(RoundID: '1', UserName: 'OhAe', Amount: '10', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: (Twowins_SingleBet)ผู้เล่นลงพนันมือเดียวในช่วงเวลาปกติ โดยผู้เล่นมีชิฟไม่พอ ระบบแจ้งเตือนผู้เล่น
	Given (Twowins_SingleBet)The SingleBetExecutor has been created and initialized
	And (Twowins_SingleBet)sent name: 'Game' the player's balance should recieved
	And (Twowins_SingleBet)sent roundID: '1' the round information should recieved
	When (Twowins_SingleBet)Expected exception and call SingleBetExecutor(RoundID: '1', UserName: 'Game', Amount: '10', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be throw exception

@record_mock
Scenario: (Twowins_SingleBet)ผู้เล่นลงพนันมือเดียวหลังจากเกมหมดเวลาแล้ว ระบบแจ้งเตือนผู้เล่น
 
@record_mock
Scenario: (Twowins_SingleBet)ผู้เล่นลงพนันมือเดียวก่อนเกมหมดเวลา ระบบแจ้งเตือนผู้เล่น