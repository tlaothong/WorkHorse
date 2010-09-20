Feature: Generate TrackingID For Client and BackService
	In order to generate TrackingID
	As a WebServer
	I want to request winner for the WebServer ganarate TrackingID

@record_mock
Scenario: Generate TrackingID for Client and BackService
	Given The ColorsGameService  has been created and initialized
	And Expect execute PayForColorsWinnerInfoCommand
	When Call PayForWinnerInformation(TableID '1', RoundID '5') by UserName 'nit'
	Then the result should be TrackingID '5AE8C8A6-2FC0-4FCD-B1C4-B4CD3D465541'
