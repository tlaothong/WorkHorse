Feature: Generate TrackingID For Client and BackService
	In order to generate TrackingID
	As a WebServer
	I want to request winner for the WebServer ganarate TrackingID

@record_mock
Scenario: ระบบส่งค่าข้อมูล tableID และ roundID ถูกต้อง
	Given The PayForWinnerInfoExecutor  has been created and initialized
	And Request winner from TableId '1', RoundId '5' UserName 'nit'
	And Expect call IColorGameBackService.PayForWinnerInfo() 
	When Execute PayForColorsWinnerInfoCommand(TableID '1', RoundID '5') by UserName 'nit'
	Then The result should be executeCommand by calling IColorGameBackService.PayForWinnerInfo()
	And The WebServer can generate TrackingID

