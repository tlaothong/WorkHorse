Feature: Request game information
	In order to receive game play information
	As a silverlight
	I want to request GamePlayInfo

	
Background:Table GamePlayInformaiton from GetGamePlayInformation as
	Given Create and initialize ShowWinnerPageViewModel and Colors game service
	And Game Play Information on BackServer is:
			|TableID	|RoundID	|UserName	|TrackingID									|OnGoingTrackingID						|LastUpdate|Winner	|
			|1			|1			|TitleUpz	|625604D9-082A-4C58-A7FC-3023A4EC1430		|625604D9-082A-4C58-A7FC-3023A4EC1430	|15-08-2010|White	|
			|2			|2			|TitleUpz	|B36ECC48-89D8-44AA-B80F-15708E12B1D3		|B36ECC48-89D8-44AA-B80F-15708E12B1D3	|15-08-2010|Black	|
			|3			|3			|TitleUpz	|779417EE-DD7E-4B74-8372-E51985938AF5		|926FFFD8-6109-4ADF-ABFF-38CD348516D1	|15-08-2010|Black	|
			|4			|4			|TitleUpz	|F7718534-39C3-487F-A9C8-E0F746D77AEF		|F7718534-39C3-487F-A9C8-E0F746D77AEF	|15-08-2010|White	|

@record_mock
Scenario: OngoingTrackingID is available 
	Given I have call PayForWinnerInformation(tableID='1',roundID='1')
	When recieve TrackingID from called
	Then execute GetGamePlayInformation

@record_mock
Scenario: OngoingTrackingID is unavailable
	Given I have call PayForWinnerInformation(tableID='2',roundID='2')
	When recieve TrackingID from called
	Then recall PayForWinnerInformation again
