Feature: Bet
	In order to bet colors game
	As a system
	I want to sent bet information to back server


@record_mock
Scenario: generate TrackingID และส่ง TrackingID ไปยัง client และ backserver ได้
	Given The BetInformation has been created and initialized
	And TrackingID of PlayerBet is '6443B518-5F7F-4BE6-8E94-AD14F931FE08'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '5', Amount '100', Color 'Black') by userName 'sak'
	Then TrackingID of PlayerBet should be '6443B518-5F7F-4BE6-8E94-AD14F931FE08'

@record_mock
Scenario: ระบบได้รับค่า UserName ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้ 
	Given The BetInformation has been created and initialized
	When Call PlayerBet(RoundID '5', Amount '100', Color 'Black') by userName ' '
	Then TrackingID of PlayerBet should be null

@record_mock
Scenario: ระบบได้รับค่า RoundID ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้ 
	Given The BetInformation has been created and initialized
	When Call PlayerBet(RoundID '-5', Amount '100', Color 'Black') by userName 'nit'
	Then TrackingID of PlayerBet should be null

@record_mock
Scenario: ระบบได้รับค่า Color ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้ 
	Given The BetInformation has been created and initialized
	When Call PlayerBet(RoundID '5', Amount '100', Color 'Blue') by userName 'nit'
	Then TrackingID of PlayerBet should be null

@record_mock
Scenario: ระบบได้รับค่า Amount ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้ 
	Given The BetInformation has been created and initialized
	When Call PlayerBet(RoundID '5', Amount '-20', Color 'White') by userName 'nit'
	Then TrackingID of PlayerBet should be null