﻿Feature: BetColor
	In order to bet game round
	As a back server
	I want to be update player information and saving bet information

@record_mock
Background: 
	Given (BetColor)server has player profile information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|463.61			|200			|	
	|Boy		|121.99			|321			|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|

@record_mock
Scenario Outline: ผู้เล่นเลือกลงเงินพนันสีขาวหรือดำ โดยผู้เล่นมีชิฟพอและชิฟตายมากกว่าเงินลงพนัน ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่นและหักเฉพาะชิฟตาย
	Given The BetColorExecutor has been created and initialized
	And sent name: <UserName> the player's balance should recieved, for bet color
	And the player's balance should be update only bonuschips, Amount: <Amount>
	And the player action information should be update as: (UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	When call BetColorExecutor(UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	Then the player action information should be created
Examples:
	|RoundID	|UserName	|Amount		|Color	|TrackingID	|
	|12			|OhAe		|5			|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Toommy		|7			|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|13			|Boy		|7.99		|Black	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Au			|221.21		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|OhAe		|9.99		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|

@record_mock
Scenario Outline: ผู้เล่นเลือกลงเงินพนันสีขาวหรือดำ โดยผู้เล่นมีชิฟพอและชิฟตายน้อยกว่าเงินลงพนันระบบหักชิฟเป็นเพิ่ม ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่นและหักชิฟเป็นและชิฟตาย
	Given The BetColorExecutor has been created and initialized
	And sent name: <UserName> the player's balance should recieved, for bet color
	And the player's balance should be update both chips, Amount: <Amount>
	And the player action information should be update as: (UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	When call BetColorExecutor(UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	Then the player action information should be created
Examples:
	|RoundID	|UserName	|Amount		|Color	|TrackingID	|
	|12			|OhAe		|500		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Toommy		|57			|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|13			|Boy		|150		|Black	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Au			|250.99		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|OhAe		|480.99		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|

@record_mock
Scenario Outline: ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินไม่พอ ระบบแจ้งเตือนผู้เล่่นว่าเงินไม่พอ
	Given The BetColorExecutor has been created and initialized
	And sent name: <UserName> the player's balance should recieved, for bet color
	When Expected exception and call BetColorExecutor(UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	Then the result should be throw exception
Examples:
	|RoundID	|UserName	|Amount		|Color	|TrackingID	|
	|12			|OhAe		|5451		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Toommy		|120		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|13			|Boy		|4215.99	|Black	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Au			|2201.21	|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|OhAe		|687.99		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|

	@record_mock
Scenario Outline: ผู้เล่นเลือกลงเงินพนันไม่ใช่สีขาวหรือดำ ระบบแจ้งเตือนผู้เล่่นว่าการลงพนันไม่ถูกต้อง
	Given The BetColorExecutor has been created and initialized
	And sent name: <UserName> the player's balance should recieved, for bet color
	When Expected exception and call BetColorExecutor(UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	Then the result should be throw exception
Examples:
	|RoundID	|UserName	|Amount		|Color	|TrackingID	|
	|12			|OhAe		|5			|Red	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Toommy		|7			|Blue	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|13			|Boy		|7.99		|Green	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Au			|221.21		|Wite	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|OhAe		|9.99		|Whte	|B21F8971-DBAB-400F-9D95-151BA24875C1|
