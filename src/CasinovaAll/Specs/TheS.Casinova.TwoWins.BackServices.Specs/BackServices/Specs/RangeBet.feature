Feature: RangeBet
	In order to range betting
	As a back server
	I want to be create range bet information and each bet information

@record_mock
Background: Twowins_RangeBet
	Given (Twowins_RangeBet)server has player information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|15.00			|0				|	
	|Boy		|0.99			|0				|
	|Toommy		|36.95			|37				|
	|Au			|100.00			|326			|
	|Game		|1				|5				|
	|Khag		|0.52			|45				|
	|Ple		|0.99			|452			|

	And (Twowins_RangeBet)server has round information as:
	|RoundID	|FromDateTime	|ThruDateTime	|CriticalTime	|Pot		|
	|1			|-20			|30				|25				|759.00		|
	|2			|-5				|5				|-3				|5266.00	|
	|3			|-10			|90				|85				|165.00		|
	|4			|0				|0				|0				|15648.00	|

@record_mock
Scenario: (Twowins_RangeBet)ผู้เล่นลงพนันช่วงปกติของโต๊ะเกม โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนัน, ประวัติการดำเนินการ และหักเฉพาะชิฟตายของผู้เล่น
	Given (Twowins_RangeBet)The RangeBetExecutor has been created and initialized
	And (Twowins_RangeBet)sent name: 'OhAe' the player's balance should recieved
	And (Twowins_RangeBet)sent roundID: '1' the round information should recieved
	And (Twowins_RangeBet)the round pot information should be update(RoundID: '1', Pot: '774')
	And (Twowins_RangeBet)the player's balance should be update only bonuschips(UserName: 'OhAe', BonusChips: '0', Chips: '0')
	And (Twowins_RangeBet)the action log information should be create(RoundID: '1', UserName: 'OhAe', ActionType: 'RangeBet', Amount: '15', OldAmount: '-1', HandStatus: 'Normal', CanChange: 'true')
	And (Twowins_RangeBet)expected the bet information should be create 
	|RoundID	|UserName	|BetTrackingID							|Status	|BonusChips	|Chips	|CanChange	|
	|1			|OhAe		|B21F8971-DBAB-400F-9D95-151BA24875C1	|Normal	|1			|0		|true		|
	|1			|OhAe		|B21F8971-DBAB-400F-9D95-151BA24875C1	|Normal	|2			|0		|true		|
	|1			|OhAe		|B21F8971-DBAB-400F-9D95-151BA24875C1	|Normal	|3			|0		|true		|
	|1			|OhAe		|B21F8971-DBAB-400F-9D95-151BA24875C1	|Normal	|4			|0		|true		|
	|1			|OhAe		|B21F8971-DBAB-400F-9D95-151BA24875C1	|Normal	|5			|0		|true		|

	When (Twowins_RangeBet)call RangeBetExecutor(RoundID: '1', UserName: 'OhAe', FromAmount: '1', ThruAmoutn: '5', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: (Twowins_RangeBet)ผู้เล่นลงพนันช่วงวิกฤตของโต๊ะเกม โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าจำนวนเงินที่ลงพนัน ระบบบันทึกข้อมูลการลงพนัน, ประวัติการดำเนินการ และหักเฉพาะชิฟตายของผู้เล่นและชิฟเป็น
	Given (Twowins_RangeBet)The RangeBetExecutor has been created and initialized
	And (Twowins_RangeBet)sent name: 'Au' the player's balance should recieved
	And (Twowins_RangeBet)sent roundID: '2' the round information should recieved
	And (Twowins_RangeBet)the round pot information should be update(RoundID: '2', Pot: '5466')
	And (Twowins_RangeBet)the player's balance should be update only bonuschips(UserName: 'Au', BonusChips: '0', Chips: '226')
	And (Twowins_RangeBet)the action log information should be create(RoundID: '2', UserName: 'Au', ActionType: 'RangeBet', Amount: '200', OldAmount: '-1', HandStatus: 'Critical', CanChange: 'true')
	And (Twowins_RangeBet)expected the bet information should be create 
	|RoundID	|UserName	|BetTrackingID							|Status		|BonusChips	|Chips	|CanChange	|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|5			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|6			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|7			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|8			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|9			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|10			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|11			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|12			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|13			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|14			|0		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|5			|10		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|0			|16		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|0			|17		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|0			|18		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|0			|19		|true		|
	|2			|Au			|B21F8971-DBAB-400F-9D95-151BA24875C1	|Critical	|0			|20		|true		|

	When (Twowins_RangeBet)call RangeBetExecutor(RoundID: '2', UserName: 'Au', FromAmount: '5', ThruAmoutn: '20', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create

@record_mock
Scenario: (Twowins_RangeBet)ผู้เล่นลงพนันในโต๊ะเกมที่จบรอบแล้ว ระบบแจ้งเตือนผู้เล่น
	Given (Twowins_RangeBet)The RangeBetExecutor has been created and initialized
	And (Twowins_RangeBet)sent name: 'Au' the player's balance should recieved
	And (Twowins_RangeBet)sent roundID: '4' the round information should recieved
	When (Twowins_RangeBet)Expected exception and call RangeBetExecutor(RoundID: '4', UserName: 'Au', FromAmount: '5', ThruAmoutn: '20', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be throw exception
