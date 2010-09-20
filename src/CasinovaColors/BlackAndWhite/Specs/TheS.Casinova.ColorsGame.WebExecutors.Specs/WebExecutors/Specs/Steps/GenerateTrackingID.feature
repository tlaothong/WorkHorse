Feature: Generate TrackingID
	In order to generate TrackingID
	As a WebServer
	I want to request winner for the WebServer ganarate TrackingID

@record_mock
Scenario: Generate TrackingID
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And Expect the TrackingID should be generate by calling PayForColorsWinnerInfoExecutor
	When Call ExecuteCommand(UserName'nit',TableID '1', RoundID '5')
	Then the result should be TrackingID '5AE8C8A6-2FC0-4FCD-B1C4-B4CD3D465541'
