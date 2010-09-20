Feature: N2N Create game round 
	1.Administrator initial TableCount, DurationTime, IntervalTime
	2.Display Sample game tables
	3.Admin config and save game configurations and Display game tables

Background:
	Given Create and initialize CreateGameRoundPage
	And the table configuration set 'config1' has the following data
		|TableID	|GameDuration	|Interval	|
		|1			|20				|5			|
		|2			|20				|10			|
		|3			|20				|7			|

Scenario: Initialize game configuration complete , sampel tables has created
	Given Config TableCount: 5, DurationTime: 120 minute, IntervalTime: 5 minute
	When I press Save
	Then sample tables has created
		|TableID	|GameDuration	|Interval	|
		|1			|120			|5			|
		|2			|120			|5			|
		|3			|120			|5			|
		|4			|120			|5			|
		|5			|120			|5			|

Scenario: Save game configuration TableCount: 0, skip generate sample tables
	Given Config TableCount: 0, DurationTime: 120 minute, IntervalTime: 5 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using TableCount is minus value, skip generate sample tables
	Given Config TableCount: -1, DurationTime: 120 minute, IntervalTime: 5 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using DurationTime is minus value, skip generate sample tables
	Given Config TableCount: 5, DurationTime: -1 minute, IntervalTime: 5 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using IntervalTime is minus value, skip generate sample tables
	Given Config TableCount: 5, DurationTime: 120 minute, IntervalTime: -1 minute
	When I press Save
	Then display sample tables has skip

Scenario: Save game configuration using TableCount,DurationTime,IntervalTime are minus value, skip generate sample tables
	Given Config TableCount: -1, DurationTime: -1 minute, IntervalTime: -1 minute
	When I press Save
	Then display sample tables has skip

Scenario: Generate table from configuration name: 'config1' accept
	When Generate from configuration name 'config1'
	Then The active game table are
		|TableID	|RoundID	|StartTime	|EndTime	|
		|1			|1			| 10:00		| 10:20		|
		|2			|2			| 10:05		| 10:25		|
		|3			|3			| 10:15		| 10:35		|