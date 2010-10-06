Feature: PayForColorsWinnerInformation
	In order to Generate TrackingID 
	As a system
	I want to Generate TrackingID for client and back server

@record_mock
Scenario: ระบบ generate TrackingID และส่ง TrackingID ไปยัง client และ backserver ได้
	Given The PayForcolorsWinnerInfo has been created and initialized
	And TrackingID is '6443B518-5F7F-4BE6-8E94-AD14F931FE08'
	And Expected call PayForWinnerInfo
	When Call PayForWinnerInfo(RoundID '5') by userName 'nit'
	Then TrackingID of PayForWinner should be '6443B518-5F7F-4BE6-8E94-AD14F931FE08'

@record_mock
Scenario: ระบบมีค่า TrackingID ไม่ถูกต้อง ระบบส่งค่า null ไปให้ client และไม่ส่งค่าไปให้ backserver
	Given The PayForcolorsWinnerInfo has been created and initialized
	And TrackingID is '00000000-0000-0000-0000-000000000000'
	And Expected call PayForWinnerInfo
	When Call PayForWinnerInfo(RoundID '5') by userName 'nit'
	Then TrackingID  of PayForWinner should be null

@record_mock
Scenario: ระบบได้รับค่า RoundID เป็นค่าลบ ระบบไม่สามารถ generate TrackingID ได้
	Given The PayForcolorsWinnerInfo has been created and initialized
	And Expected call PayForWinnerInfo
	When Call PayForWinnerInfo(RoundID '-5') by userName 'nit'
	Then TrackingID  of PayForWinner should be null
	
@record_mock
Scenario: ระบบได้รับค่าข้อมูล UserName ที่ไม่มีในระบบ ระบบไม่สามารถ generate TrackingID ได้
	Given The PayForcolorsWinnerInfo has been created and initialized
	And System has userName 'tle','boy','ae','ku','au'
	And Expected call PayForWinnerInfo
	When Call PayForWinnerInfo(RoundID '5') by userName 'nit'
	Then TrackingID  of PayForWinner should be null

@record_mock
Scenario: ระบบไม่ได้รับค่า UserName ระบบไม่สามารถ generate TrackingID ได้
	Given The PayForcolorsWinnerInfo has been created and initialized
	And Expected call PayForWinnerInfo
	When Call PayForWinnerInfo(RoundID '5') by userName ' '
	Then TrackingID  of PayForWinner should be null	