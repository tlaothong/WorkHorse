Feature: Generate TrackingID
	In order to generate TrackingID
	As a WebServer
	I want to request winner for the WebServer ganarate TrackingID

@mytag
Scenario: Generate TrackingID
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And I have entered UserName = 'nayit', TableID = '1' and RoundID = '5'
	And Expected call PayFoeColorWinnerInfoExecutor
	When I press add
	Then the result should be 120 on the screen
