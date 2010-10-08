Feature: BetColor
	In order to bet game round
	As a back server
	I want to be update player information and saving bet information

@record_mock
Background: 
	Given (BetColor)server has player information as:
	|UserName	|Balance	|
	|OhAe		|463.61		|
	|Boy		|121.99		|
	|Toommy		|36.95		|
	|Au			|234.00		|

@record_mock
Scenario Outline: ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่น
	Given The BetColorExecutor has been created and initialized
	And sent name: <UserName> the player's balance should recieved, for bet color
	And the player's balance should be update correct, Amount: <Amount>
	And the player action information should be update as: (UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	When call BetColorExecutor(UserName: <UserName>, RoundID: <RoundID>, Amount: <Amount>, Color: <Color>, TrackingID: <TrackingID>)
	Then the player action information should be created
Examples:
	|RoundID	|UserName	|Amount		|Color	|TrackingID	|
	|12			|OhAe		|5			|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Toomy		|7			|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|13			|Boy		|7.99		|Black	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|Au			|221.21		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|OhAe		|9.99		|White	|B21F8971-DBAB-400F-9D95-151BA24875C1|