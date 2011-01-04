Feature: ChangeBet
	In order to change bet information
	As a back server
	I want to be increase bet value
	
@record_mock
Background: Twowins_ChangeBet
	Given (Twowins_ChangeBet)server has player information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|20				|200			|	
	|Boy		|1				|5				|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|
	|Game		|1				|5				|
	|Khag		|0.52			|45				|
	|Ple		|0.99			|452			|

	And (Twowins_ChangeBet)server has round information as:
	|RoundID	|FromDateTime	|ThruDateTime	|CriticalTime	|Pot		|
	|1			|-20			|30				|25				|759.00		|
	|2			|-5				|5				|-3				|5266.00	|
	|3			|-10			|90				|85				|165.00		|
	|4			|0				|0				|0				|15648.00	|

	And (Twowins_ChangeBet)server has bet information as:
	|HandID	|RoundID	|UserName	|BonusChips	|Chips	|Amount	|HandStatus	|CanChange	|
	|1562	|1			|OhAe		|123		|0		|123	|Normal		|false		|
	|1542	|1			|OhAe		|12			|5		|17		|Normal		|true		|
	|1549	|1			|OhAe		|0			|7		|7		|Normal		|true		|
	|1604	|1			|OhAe		|0			|20		|20		|Critical	|true		|
	|1611	|1			|OhAe		|0			|25		|25		|Critical	|false		|
	|1662	|2			|Boy		|123		|0		|123	|Normal		|false		|
	|1642	|2			|Boy		|12			|5		|17		|Normal		|true		|
	|1649	|2			|Boy		|0			|7		|7		|Normal		|true		|
	|1704	|2			|Boy		|0			|20		|20		|Critical	|true		|
	|1711	|2			|Boy		|0			|25		|25		|Critical	|false		|


@record_mock
Scenario: (Twowins_ChangeBet)ผู้เล่นเพิ่มเงินพนันในข้อมูลลงพนันเดิมในช่วงเวลาปกติของโต๊ะเกม โดยระบุชิฟที่เพิ่มมากกว่าเดิม ผู้เล่นมีชิฟตายพอ และข้อมูลลงพนันยังสามารถแก้ไขได้, ระบบบันทึกข้อมูลการแก้ไข บันทึกประวัติการดำเนินการ หักชิฟผู้เล่นเพิ่ม และอัพเดทเงินกองกลางของโต๊ะเกมและข้อมูลการลงพนันเดิม
	Given (Twowins_ChangeBet)The ChangeBetExecutor has been created and initialized
	And (Twowins_ChangeBet)sent name: 'OhAe' the player's balance should recieved
	And (Twowins_ChangeBet)sent roundID: '1' the round information should recieved
	And (Twowins_ChangeBet)sent handID: '1542' the round information should recieved
	And (Twowins_ChangeBet)the round pot information should be update(RoundID: '1', Pot: '762')
	And (Twowins_ChangeBet)the action log information should be create (RoundID: '1', UserName: 'OhAe', ActionType: 'ChangeBet', Amount: '20', OldAmount: '17', HandStatus: 'Normal', Change: 'true'
	And (Twowins_ChangeBet)the player's balance should be update(UserName: 'OhAe', BonusChips: '17', Chips: '200')
	And (Twowins_ChangeBet)the bet information should be update(RoundID: '1', UserName: 'OhAe', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BonusChips: '15', Chips: '5', HandStatus: 'Normal', CanChange: 'true')
	When (Twowins_ChangeBet)call ChangeBetExecutor(UserName: 'OhAe', HandID: '1542', Amount: '20', RoundID: '1', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be change

@record_mock
Scenario: (Twowins_ChangeBet)ผู้เล่นเพิ่มเงินพนันในข้อมูลลงพนันเดิมในช่วงเวลาปกติของโต๊ะเกม โดยระบุชิฟที่เพิ่มน้อยกว่าเดิม ระบบแจ้งเตือน
	Given (Twowins_ChangeBet)The ChangeBetExecutor has been created and initialized
	And (Twowins_ChangeBet)sent name: 'OhAe' the player's balance should recieved
	And (Twowins_ChangeBet)sent roundID: '1' the round information should recieved
	And (Twowins_ChangeBet)sent handID: '1542' the round information should recieved
	When (Twowins_ChangeBet)Expected exception and call ChangeBetExecutor(UserName: 'OhAe', HandID: '1542', Amount: '10', RoundID: '1', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be throw exception

@record_mock
Scenario: (Twowins_ChangeBet)ผู้เล่นเพิ่มเงินพนันในข้อมูลลงพนันเดิมในช่วงเวลาปกติของโต๊ะเกม โดยระบุชิฟที่เพิ่มมากกว่าเดิม ผู้เล่นมีชิฟตายพอ และข้อมูลลงพนันไม่อนุญาตให้แก้ไขแล้ว, ระบบแจ้งเตือน
	Given (Twowins_ChangeBet)The ChangeBetExecutor has been created and initialized
	And (Twowins_ChangeBet)sent name: 'OhAe' the player's balance should recieved
	And (Twowins_ChangeBet)sent roundID: '1' the round information should recieved
	And (Twowins_ChangeBet)sent handID: '1611' the round information should recieved
	When (Twowins_ChangeBet)Expected exception and call ChangeBetExecutor(UserName: 'OhAe', HandID: '1611', Amount: '26', RoundID: '1', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be throw exception

@record_mock
Scenario: (Twowins_ChangeBet)ผู้เล่นเพิ่มเงินพนันในข้อมูลลงพนันเดิมในช่วงเวลาวิกฤตของโต๊ะเกม โดยระบุชิฟที่เพิ่มมากกว่าเดิม ระบบแจ้งเตือน ผู้เล่นมีชิฟตายไม่พอหักชิฟเป็นเพิ่ม และข้อมูลลงพนันยังสามารถแก้ไขได้, ระบบบันทึกข้อมูลการแก้ไข บันทึกประวัติการดำเนินการ หักชิฟผู้เล่นเพิ่ม และอัพเดทเงินกองกลางของโต๊ะเกมและข้อมูลการลงพนันเดิม
	Given (Twowins_ChangeBet)The ChangeBetExecutor has been created and initialized
	And (Twowins_ChangeBet)sent name: 'Boy' the player's balance should recieved
	And (Twowins_ChangeBet)sent roundID: '2' the round information should recieved
	And (Twowins_ChangeBet)sent handID: '1642' the round information should recieved
	And (Twowins_ChangeBet)the round pot information should be update(RoundID: '2', Pot: '5269')
	And (Twowins_ChangeBet)the action log information should be create (RoundID: '2', UserName: 'Boy', ActionType: 'ChangeBet', Amount: '20', OldAmount: '17', HandStatus: 'Critical', Change: 'true'
	And (Twowins_ChangeBet)the player's balance should be update(UserName: 'Boy', BonusChips: '0', Chips: '3')
	And (Twowins_ChangeBet)the bet information should be update(RoundID: '2', UserName: 'Boy', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1', BonusChips: '13', Chips: '7', HandStatus: 'Critical', CanChange: 'false')
	When (Twowins_ChangeBet)call ChangeBetExecutor(UserName: 'Boy', HandID: '1642', Amount: '20', RoundID: '2', BetTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be change
