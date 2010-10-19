Feature: StopAutoBet
	In order to stop bet
	As a back server
	I want to be stop automatic betting

@record_mock
Scenario: ได้รับข้อมูลผู้เล่นที่จะยกเลิกลงพนัน, ระบบส่งข้อมูลให้ AutoBet Engine ทำงานต่อไป
	Given The StopAutoBetExecutor has been created and initialized
	And the StopAutoBet shoule be call as: (UserName: 'OhAe', RoundID: '1', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	When call StopAutoBetExecutor(UserName: 'OhAe', RoundID: '1', TrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then server should call StopAutoBet
