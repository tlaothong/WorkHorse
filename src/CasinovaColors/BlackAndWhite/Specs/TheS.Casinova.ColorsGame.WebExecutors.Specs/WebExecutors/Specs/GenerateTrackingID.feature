Feature: Generate TrackingID
	In order to generate TrackingID
	As a WebServer
	I want to request winner for the WebServer ganarate TrackingID

@mytag
Scenario: Generate TrackingID
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And Expect the TrackingID should be generate by calling PayForColorsWinnerInfoExecutor
	When Call ExecuteCommand(UserName'nit',TableID '1', RoundID '5')
	Then the result should be TrackingID '2a3b'
