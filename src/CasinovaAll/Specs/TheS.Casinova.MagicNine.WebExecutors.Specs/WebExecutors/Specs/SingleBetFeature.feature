Feature: SingleBet
	In order to single bet
	As a player
	I want to bet 

@record_mock
Scenario: ระบบได้รับ userName และ roundId ถูกต้อง #SingleBet
	Given The BetInformation has been created and initialized
	And Web service has TrackingID : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'
	And Expect execute SingleBetCommand
	When Call SingleBetExecutor(userName'Nit', roundId '1')
	Then TrackingID for client and back server should be : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'

@record_mock
Scenario: ระบบได้รับ userName ไม่ถูกต้อง #SingleBet
	Given The BetInformation has been created and initialized
	When Call SingleBetExecutor(userName'', roundId '1')
	Then TrackingID for client and back server should be null

@record_mock
Scenario: ระบบได้รับ roundId ไม่ถูกต้อง #SingleBet
	Given The BetInformation has been created and initialized
	When Call SingleBetExecutor(userName'Nit', roundId '-1')
	Then TrackingID for client and back server should be null

@record_mock
Scenario: ระบบได้รับ userName และ roundId  ไม่ถูกต้อง #SingleBet
	Given The BetInformation has been created and initialized
	When Call SingleBetExecutor(userName' ', roundId '-1')
	Then TrackingID for client and back server should be null