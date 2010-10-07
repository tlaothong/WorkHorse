Feature: Bet
	In order to generate TrackingID
	As a math idiot
	I want to Generate TrackingID for client and back server

@record_mock
Scenario: ผู้เล่นมีเงินในบัญชีมากกว่าจำนวนเงินที่ลงเดิมพัน ระบบ generate TrackingID และส่ง TrackingID ไปยัง client และ backserver ได้
	Given The BetInformation has been created and initialized
	And Balance is '100'
	And TrackingID of PlayerBet is '6443B518-5F7F-4BE6-8E94-AD14F931FE08'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '5', Amount '50', Color 'Black') by userName 'nit'
	Then TrackingID of PlayerBet should be '6443B518-5F7F-4BE6-8E94-AD14F931FE08'

@record_mock
Scenario: ผู้เล่นมีเงินในบัญชีเท่ากับจำนวนเงินที่ลงเดิมพัน ระบบ generate TrackingID และส่ง TrackingID ไปยัง client และ backserver ได้
	Given The BetInformation has been created and initialized
	And Balance is '50'
	And TrackingID of PlayerBet is '6443B518-5F7F-4BE6-8E94-AD14F931FE08'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '5', Amount '50', Color 'Black') by userName 'nit'
	Then TrackingID of PlayerBet should be '6443B518-5F7F-4BE6-8E94-AD14F931FE08'

@record_mock
Scenario: ผู้เล่นมีเงินในบัญชีน้อยกว่าเงินที่ลงเดิมพัน ระบบ generate TrackingID ไม่ได้ และส่งค่า balance กลับไปให้ client 
	Given The BetInformation has been created and initialized
	And Balance is '50'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '5', Amount '100', Color 'Black') by userName 'nit'
	Then TrackingID of PlayerBet should be null
	And Balance should be '50'

@record_mock
Scenario: ผู้เล่นไม่มีเงินในบัญชี ระบบ generate TrackingID ไม่ได้ และส่งค่า balance กลับไปให้ client 
	Given The BetInformation has been created and initialized
	And Balance is '0'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '5', Amount '100', Color 'Black') by userName 'nit'
	Then TrackingID of PlayerBet should be null
	And Balance should be '0'

@record_mock
Scenario: ระบบได้รับค่า UserName ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้ 
	Given The BetInformation has been created and initialized
	And Balance is '200'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '5', Amount '100', Color 'Black') by userName ' '
	Then TrackingID of PlayerBet should be null

@record_mock
Scenario: ระบบได้รับค่า RoundID ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้ 
	Given The BetInformation has been created and initialized
	And Balance is '200'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '-5', Amount '100', Color 'Black') by userName 'nit'
	Then TrackingID of PlayerBet should be null

@record_mock
Scenario: ระบบได้รับค่า Color ไม่ถูกต้อง ระบบ generate TrackingID ไม่ได้ 
	Given The BetInformation has been created and initialized
	And Balance is '200'
	And Expected call PlayerBet
	When Call PlayerBet(RoundID '5', Amount '100', Color 'Blue') by userName 'nit'
	Then TrackingID of PlayerBet should be null