Feature: Generate TrackingID For Client and BackService
	In order to generate TrackingID
	As a WebServer
	I want to request winner for the WebServer ganarate TrackingID

@record_mock
Scenario Outline: ระบบส่งค่าข้อมูล tableID และ roundID 
	Given The PayForWinnerInfoExecutor  has been created and initialized
	And Request winner from TableID '<TableId>', RoundID '<RoundId>' UserName 'nit'
	And Expect call IColorGameBackService.PayForWinnerInfo() 
	When Execute PayForColorsWinnerInfoCommand(TableID '<TableId>', RoundID '<RoundId>') by UserName 'nit'
	Then The result should be executeCommand by calling IColorGameBackService.PayForWinnerInfo()
	And The WebServer can generated TrackingID

	Examples:
		|TableId|RoundId|
		|1		|5		|
		|2		|6		|
		|3		|7		|