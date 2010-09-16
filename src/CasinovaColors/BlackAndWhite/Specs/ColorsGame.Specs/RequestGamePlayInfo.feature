Feature: Request game information
	In order to receive game play information
	As a silverlight
	I want to request GamePlayInfo

@record_mock
Scenario: OngoingTrackingID is available 
	Given Create and initialize ShowWinnerPageViewModel and Colors game service
	And I have enter username 'TitleUpz'
	When execute GetGamePlayInformation
	Then Send request to server

@record_mock
Scenario: OngoingTrackingID is unavailable
	Given Create and initialize ShowWinnerPageViewModel and Colors game service
	When execute GetGamePlayInformation
	Then Resend request GetWinner to server
