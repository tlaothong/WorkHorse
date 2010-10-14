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
	|Au			|00.00		|

	And server has game round information as:
	|RoundID	|StartTime			|EndTime	|WinnerPoint	|GamePot	|Active	|
	|1			|2553/3/12 10:00	|			|9				|4329		|True	|
	|2			|2553/3/12 10:00	|			|99				|272		|True	|
	|3			|2553/3/12 10:00	|			|999			|712		|True	|
	|4			|2553/3/12 10:00	|			|9999			|432		|True	|

@record_mock
Scenario: ได้รับข้อมูล RoundID, UserName, ระบบตรวจสอบเงินสำหรับลงพนันพอ, ระบบหักเงินผู้เล่นและบันทึกข้อมูลการลงพนัน
	Given The SingleBetExecutor has been created and initialized
	And sent name: 'OhAe' the player's balance should recieved
	And sent RoundID: '1' the round pot should recieved
	And the expected balance should be: '462.61'
	And the round information(RoundID: '1', GamePot: '4330') should be update
	And the bet information(RoundID: '1', UserName: 'OhAe', BetOrder: '4330', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1') should be create
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
