Feature: N2N Status Tracker
	Steps:
		These steps create and initialize the StatusTracker
		1. Create an instance of LotRetrieverFactory.
		2. Create a StatusTracker instance.
		3. Assign LotRetrieverFactory object to the property of the same name
			of StatusTracker.
		4. Call StatusTracker.Initialize() passing in the pollingUrl.

		These steps using the status tracker to watch for updates.
		5. Create an instance of ITrackingObserver implementation
			(may be an instance of TrackingObserverBase derivatives).
		6. Call ITrackingObserver.Initialize() passing the StatusTracker
			as a parameter.
				6.1 This method should call StatusTracker.Watch().
		7. When the tracking ID has received, call ITrackingObserver.SetTrackingID().
		8. Observes the incoming updates.
		9. When done call StatusTracker.ReleaseWatch() passing in the ITrackingObserver
			as a parameter.

Scenario: Create and initialize the StatusTracker
	Given an instance of LotRetrieverFactory
	And an instance of StatusTracker
	When assign LotRetriverFactory to the property of the StatusTracker
	And call StatusTracker.Initialize('http://localhost/getCurrentLotNo')
	Then StatusTracker.LotRetriverFactory should be set correctly
	And LotRetriverFactory.PollingUrl should has the same value as the StatusTracker.PollingUrl


Background:
	Given tracking information of lot# 2003 has data as shown in the table
		|TrackingID								|Status	|
		|{51EB626B-D5B4-4AE4-9FD5-3D0208E4E42A}	|OK		|
		|{0B4E7851-5EC1-4821-A4D2-F58B1F69F60F}	|		|
	And tracking information of lot# 2004 has data as shown in the table
		|TrackingID								|Status	|
		|{8B6000E4-7522-4660-B840-DAA31E136C55}	|OK		|
		|{24AB763D-0694-4304-ADBE-40067930B782}	|OK		|
		|{181A88E1-30DA-4F64-8EC8-B9A325F18CEE}	|OK		|
		|{4B103861-C7C8-4761-96F6-FB1EAC58CD69}	|Timeout|

Scenario: Using the StatusTracker to watch for updates
	Given a StatusTracker has been created and initialized
	And an instance of TrackingObserverBase derived class has been created
	And the server current lot# is 2003
	When call TrackingObserverBase.Initialize(statusTracker)
	And call TrackingObserverBase.SetTrackingID({24AB763D-0694-4304-ADBE-40067930B782})
	And the server current lot# is 2004
	Then OnUpdateTrackingInformation should be called with the tracking information #{24AB763D-0694-4304-ADBE-40067930B782}
