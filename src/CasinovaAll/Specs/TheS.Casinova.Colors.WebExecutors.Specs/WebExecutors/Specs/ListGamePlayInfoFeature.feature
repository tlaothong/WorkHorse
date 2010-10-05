﻿Feature: ListGamePlayInfo
	In order to list game play information 
	As a system
	I want to list game play information of player

@record_mock
Scenario: ลิสต์ข้อมูลโต๊ะเกมที่ผู้เล่นเคยเล่นไว้แบบที่1
	Given The GamePlayInformation has been created and initialized
	And The game play information of 'Lala' is :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|1		|5		|320				  |20					| Black|10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		|2		|6		|40				      |30					| White|12:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{046CDB68-8B43-431C-8584-11A6049C0CF4}|   Lala  |
		|3		|7		|11					  |100					| White|15:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}|   Lala  |
	When Call ListGamePlayInfo('Lala')
	Then The result should be :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|1		|5		|320				  |20					| Black|10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		|2		|6		|40				      |30					| White|12:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{046CDB68-8B43-431C-8584-11A6049C0CF4}|   Lala  |
		|3		|7		|11					  |100					| White|15:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}|   Lala  |


@record_mock
Scenario: ลิสต์ข้อมูลโต๊ะเกมที่ผู้เล่นเคยเล่นไว้แบบที่2
	Given The GamePlayInformation has been created and initialized
	And The game play information of 'Lala' is :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|1		|5		|0					  |20					| Black|10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		|2		|6		|40				      |30					| White|12:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{046CDB68-8B43-431C-8584-11A6049C0CF4}|   Lala  |
		|3		|7		|11					  |0					| White|15:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}|   Lala  |
	When Call ListGamePlayInfo('Lala')
	Then The result should be :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|1		|5		|0					  |20					| Black|10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		|2		|6		|40				      |30					| White|12:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{046CDB68-8B43-431C-8584-11A6049C0CF4}|   Lala  |
		|3		|7		|11					  |0					| White|15:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}|   Lala  |

@record_mock
Scenario: ลิสต์ข้อมูลโต๊ะเกมที่ผู้เล่นเคยเล่นไว้แบบที่3
	Given The GamePlayInformation has been created and initialized
	And The game play information of 'Lala' is :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|1		|5		|0					  |20					| -	   |10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		
	When Call ListGamePlayInfo('Lala')
	Then The result should be :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|1		|5		|0					  |20					| -	   |10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		

@record_mock
Scenario: ลิสต์ข้อมูลโต๊ะเกม แต่ผู้เล่นยังไม่เคยเล่นเกมที่โต๊ะใด ๆ 
	Given The GamePlayInformation has been created and initialized
	And The game play information of 'Lala' is :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|TrackingID|OnGoingTrackingID|UserName|
		
	When Call ListGamePlayInfo('Lala')
	Then The result should be :
		|TableID|RoundID|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|TrackingID|OnGoingTrackingID|UserName|
		