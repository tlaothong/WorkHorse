Feature: N2N Create game round 
	1.Administrator initial TableCount, DurationTime, IntervalTime
	2.Display Sample game tables
	3.Admin config and save game configurations and Display game tables

Scenario: Initialize game configuration complete , sampel tables has created
	Given Create and initialize CreateGameRoundPage
	And Config TableCount: 5, DurationTime: 120 minute, IntervalTime: 5 minute
	When I press Save
	Then sample tables has created
		|TableID	|GameDuration	|Interval	|
		|1			|120			|5			|
		|2			|120			|5			|
		|3			|120			|5			|
		|4			|120			|5			|
		|5			|120			|5			|

Scenario: Save game configuration TableCount: 0, skip generate sample tables
	Given Create and initialize CreateGameRoundPage
	And Config TableCount: 0, DurationTime: 120 minute, IntervalTime: 5 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using TableCount is minus value, skip generate sample tables
	Given Create and initialize CreateGameRoundPage
	And Config TableCount: -1, DurationTime: 120 minute, IntervalTime: 5 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using DurationTime is minus value, skip generate sample tables
	Given Create and initialize CreateGameRoundPage
	And Config TableCount: 5, DurationTime: -1 minute, IntervalTime: 5 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using IntervalTime is minus value, skip generate sample tables
	Given Create and initialize CreateGameRoundPage
	And Config TableCount: 5, DurationTime: 120 minute, IntervalTime: -1 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using TableCount,DurationTime,IntervalTime are minus value, skip generate sample tables
	Given Create and initialize CreateGameRoundPage
	And Config TableCount: -1, DurationTime: -1 minute, IntervalTime: -1 minute
	When I press Save
	Then display sample tables has skip