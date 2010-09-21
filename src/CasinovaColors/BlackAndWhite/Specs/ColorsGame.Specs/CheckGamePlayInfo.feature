Feature: Check game play information 
	In order to check data in GamePlayInformation is a correct
	As a silverlight
	I want to check trackingID and OngoingTrackingID when they are same,GamePlayInformation is real

Background:Table GamePlayInformaiton is result from GetGamePlayInformation as
	Given Create and initialize ShowWinnerPageViewModel and Colors game service
	And Game Play Information on BackServer as:
			|TableID	|RoundID	|UserName	|TrackingID									|OnGoingTrackingID						|LastUpdate|Winner	|
			|1			|1			|TitleUpz	|625604D9-082A-4C58-A7FC-3023A4EC1430		|625604D9-082A-4C58-A7FC-3023A4EC1430	|15-08-2010|White	|
			|2			|2			|TitleUpz	|B36ECC48-89D8-44AA-B80F-15708E12B1D3		|B36ECC48-89D8-44AA-B80F-15708E12B1D3	|15-08-2010|Black	|
			|3			|3			|TitleUpz	|779417EE-DD7E-4B74-8372-E51985938AF5		|926FFFD8-6109-4ADF-ABFF-38CD348516D1	|15-08-2010|Black	|
			|4			|4			|TitleUpz	|F7718534-39C3-487F-A9C8-E0F746D77AEF		|F7718534-39C3-487F-A9C8-E0F746D77AEF	|15-08-2010|White	|


@record_mock
Scenario: TrackingID is equal OngoingTrackingID
	Given TrackingID = '625604D9-082A-4C58-A7FC-3023A4EC1430' from Table = '1' RoundID = '1'
	When I receive GamePlayInformation[]
	Then the result will be accept by OnGoingTrackingID: '625604D9-082A-4C58-A7FC-3023A4EC1430'

@record_mock
Scenario: TrackingID2 is equal OngoingTrackingID
	Given TrackingID = 'B36ECC48-89D8-44AA-B80F-15708E12B1D3' from Table = '2' RoundID = '2'
	When I receive GamePlayInformation[]
	Then the result will be accept by OnGoingTrackingID: 'B36ECC48-89D8-44AA-B80F-15708E12B1D3'

@record_mock
Scenario: TrackingID2 is not equal OngoingTrackingID
	Given TrackingID = '779417EE-DD7E-4B74-8372-E51985938AF5' from Table = '3' RoundID = '3'
	When I receive GamePlayInformation[]
	Then request GamePlayInformation again

