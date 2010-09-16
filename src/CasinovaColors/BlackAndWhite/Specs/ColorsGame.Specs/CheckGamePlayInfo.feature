Feature: Check game play information 
	In order to check data in GamePlayInformation is a correct
	As a silverlight
	I want to check trackingID and OngoingTrackingID when they are same,GamePlayInformation is real

Background:Table GamePlayInformaiton is result from GetGamePlayInformation as
	Given Create and initialize ShowWinnerPageViewModel and Colors game service

@record_mock
Scenario: TrackingID is equal OngoingTrackingID
	Given I entered username = 'TitleUpz'
	When execute GetGamePlayInfo
	Then the result should be 120 on the screen
