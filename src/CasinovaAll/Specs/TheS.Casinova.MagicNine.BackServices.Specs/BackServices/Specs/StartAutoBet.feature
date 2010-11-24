Feature: StartAutoBet
	In order to bet
	As a back server
	I want to be automatic betting by server

@record_mock
Background: 
	Given (AutoBet)server has player information as:
	|UserName	|Balance	|
	|OhAe		|463.61		|
	|Boy		|121.99		|
	|Toommy		|36.95		|
	|Au			|234.00		|

@record_mock
Scenario: ได้รับข้อมูลการลงเงิน, ผู้เล่นมีเงินพอ ระบบหักเงินผู้เล่นตามเงินที่ลงพนัน และส่งข้อมูลให้ระบบ AutoBet Engine ทำงานต่อ
	Given The StartAutoBetExecutor has been created and initialized
	And sent name: 'OhAe' the player's balance should recieved, for autobet
	And the player's balance should be update correct, Amount: '200'
	And the StartAutoBet shoule be call as: (UserName: 'OhAe', RoundID: '1', Amount: '200', Interval: '5', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	When call StartAutoBetExecutor(UserName: 'OhAe', RoundID: '1', Amount: '200', Interval: '5', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the player information should be update and call StartAutoBet

@record_mock
Scenario: ได้รับข้อมูลการลงเงิน, ผู้เล่นมีเงินพอ ระบบหักเงินผู้เล่นตามเงินที่ลงพนัน และส่งข้อมูลให้ระบบ AutoBet Engine ทำงานต่อ2
	Given The StartAutoBetExecutor has been created and initialized
	And sent name: 'Au' the player's balance should recieved, for autobet
	And the player's balance should be update correct, Amount: '100'
	And the StartAutoBet shoule be call as: (UserName: 'Au', RoundID: '1', Amount: '100', Interval: '5', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	When call StartAutoBetExecutor(UserName: 'Au', RoundID: '1', Amount: '100', Interval: '5', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the player information should be update and call StartAutoBet
