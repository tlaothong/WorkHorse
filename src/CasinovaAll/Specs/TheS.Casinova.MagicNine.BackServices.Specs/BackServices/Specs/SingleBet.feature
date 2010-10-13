Feature: SingleBet
	In order to bet game by player
	As a back server
	I want to be create bet information to server

@record_mock
Background: SingleBet
	Given server has player information as:
	|UserName	|Balance	|
	|OhAe		|463.61		|
	|Boy		|121.21		|
	|Nit		|36.99		|
	|Au			|234.00		|

@record_mock
Scenario: ได้รับข้อมูล RoundID, UserName, ระบบตรวจสอบเงินสำหรับลงพนันพอ, ระบบหักเงินผู้เล่นและบันทึกข้อมูลการลงพนัน
	Given The SingleBetExecutor has been created and initialized
	And sent name: 'OhAe' the player's balance should recieved
	And the expected balance should be: '462.61'
	When call SingleBet(RoundID: '12', UserName: 'OhAe', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be create
