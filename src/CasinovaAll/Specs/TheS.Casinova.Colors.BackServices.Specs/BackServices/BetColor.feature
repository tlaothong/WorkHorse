Feature: BetColor
	In order to bet game round
	As a back server
	I want to be update player information and saving bet information

@record_mock
Background: 
	Given (BetColor)server has player information as:
	|UserName	|Balance	|
	|OhAe		|463.61		|
	|Boy		|121.21		|
	|Nit		|36.99		|
	|Au			|234.00		|

@record_mock
Scenario: ผู้เล่นลงเงินพนัน โดยผู้เล่นมีเงินพอ ระบบบันทึกประวัติการดำเนินการ(พนัน)ของผู้เล่น
	Given The BetColorExecutor has been created and initialized
	And sent name: 'OhAe' the player's balance should recieved, for bet color
	And the player's balance should be update as: '451.11'
	And the player action information should be update as: (UserName: 'OhAe', RoundID: '12', Amount: '12.50', Color: 'White', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	When call BetColorExecutor(UserName: 'OhAe', RoundID: '12', Amount: '12.50', Color: 'White', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the player action information should be created

