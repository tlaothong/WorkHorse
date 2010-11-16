Feature: ListGamePlayInfo
	In order to list game play information 
	As a system
	I want to list game play information of player


Background:
	Given Server has game play information as:
		|UserName|RoundID	|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|Lala	 |5			|320				  |20					| Black|10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		|Lala	 |6			|40				      |30					| White|12:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{046CDB68-8B43-431C-8584-11A6049C0CF4}|   Lala  |
		|Lala	 |7			|11					  |100					| White|15:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}|   Lala  |

@record_mock
Scenario: ระบบลิสต์ข้อมูลโต๊ะเกมที่ผู้เล่นเคยเล่นไว้ได้
	Given The ListGamePlayInfoExecutor has been created and initialized
	When Call ListGamePlayInfoExecutor('Lala')
	Then The game play information should be :
		|UserName|RoundID	|TotalBetAmountOfBlack|TotalBetAmountOfWhite|Winner|LastUpdate|			TrackingID				     |		OnGoingTrackingID				| UserName|
		|Lala	 |5			|320				  |20					| Black|10:00	  |{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	Lala  |
		|Lala	 |6			|40				      |30					| White|12:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{046CDB68-8B43-431C-8584-11A6049C0CF4}|   Lala  |
		|Lala	 |7			|11					  |100					| White|15:00	  |{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}|   Lala  |

@record_mock
Scenario: ระบบลิสต์ข้อมูลโต๊ะเกมแต่ไม่มีข้อมูล เนื่องจากผู้เล่นยังไม่เคยเล่นเกมที่โต๊ะใด ๆ 
	Given The ListGamePlayInfoExecutor has been created and initialized	
	When Call ListGamePlayInfoExecutor('Nit')
	Then The game play information should be null

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล username ระบบลิสต์ข้อมูลโต๊ะเกมไม่ได้
	Given The ListGamePlayInfoExecutor has been created and initialized
	When Call ListGamePlayInfoExecutor('')
	Then The game play information should be throw exception

@record_mock
Scenario: ใส่ข้อมูล username ที่ไม่มีในระบบ ระบบทำการลิสต์ข้อมูล ไม่มีข้อมูลโต๊ะเกม
	Given The ListGamePlayInfoExecutor has been created and initialized
	When Call ListGamePlayInfoExecutor('Boy')
	Then The game play information should be null