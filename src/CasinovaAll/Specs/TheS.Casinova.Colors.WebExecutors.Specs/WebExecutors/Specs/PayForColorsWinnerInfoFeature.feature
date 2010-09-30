Feature: PayForColorsWinnerInformation
	In order to Generate TrackingID 
	As a system
	I want to Generate TrackingID for client and back server

@record_mock
Scenario: ส่ง TrackingID ไปยัง client และ backserver ได้
	Given The PayForcolorsWinnerInfo has been created and initialized
	And TrackingID is '6443B518-5F7F-4BE6-8E94-AD14F931FE08'
	And Expected call PayForWinnerInfo
	When Call PayForWinnerInfo(RoundID '5') by userName 'nit'
	Then The result should be called PayForWinnerInfo Succeeded
	And TrackingID should be '6443B518-5F7F-4BE6-8E94-AD14F931FE08'

@record_mock
Scenario: ส่ง TrackingID ไปยัง client และ backserver ได้แต่ค่าไม่ถูกต้อง
	Given The PayForcolorsWinnerInfo has been created and initialized
	And TrackingID is '00000000-0000-0000-0000-000000000000'
	And Expected call PayForWinnerInfo
	When Call PayForWinnerInfo(RoundID '5') by userName 'nit'
	Then The result should be called PayForWinnerInfo Succeeded
	And TrackingID should be '00000000-0000-0000-0000-000000000000'

