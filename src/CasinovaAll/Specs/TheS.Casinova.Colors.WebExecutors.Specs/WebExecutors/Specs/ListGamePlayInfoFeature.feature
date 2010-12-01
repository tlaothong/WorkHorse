Feature: ListGamePlayInfo
	In order to list game play information 
	As a system
	I want to list game play information of player


Background:
	Given Server has game play information as:
		|UserName|RoundID	|TotalBetBlack		|TotalBetWhite	|Winner|WinnerLastUpdate|			TrackingID				   |		OnGoingTrackingID			  | 
		|Lalaka	 |5			|320				|20				| Black|10:00			|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|	
		|Nittaya |6			|40				    |30				| White|12:00			|{046CDB68-8B43-431C-8584-11A6049C0CF4}|{046CDB68-8B43-431C-8584-11A6049C0CF4}| 
		|Lalaka	 |7			|11					|100			| White|15:00			|{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}| 

@record_mock
Scenario:[ListGamePlayInfo]ระบบได้รับข้อมูล username ถูกต้อง และมีข้อมูลการเล่นเกมของผู้เล่น ระบบลิสต์ข้อมูลโต๊ะเกมที่ผู้เล่นเคยเล่นไว้ได้
	Given The ListGamePlayInfoExecutor has been created and initialized
	And   Sent userName'Lalaka' for list game play information
	When  Call ListGamePlayInfoExecutor()
	Then  The game play information should be :
		 |UserName|RoundID	|TotalBetBlack		|TotalBetWhite	|Winner|WinnerLastUpdate|			TrackingID				   |		OnGoingTrackingID			  |
		 |Lalaka  |5		|320				|20				| Black|10:00			|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|{BAF9F79B-BDCC-4FA5-804D-9C8B4ED42887}|
		 |Lalaka  |7		|11					|100			| White|15:00			|{046CDB68-8B43-431C-8584-11A6049C0CF4}|{F0A52B67-DC51-424F-BF2E-CA72D8E07FA8}|

@record_mock
Scenario:[ListGamePlayInfo]ระบบได้รับข้อมูล username ถูกต้อง ระบบลิสต์ข้อมูลโต๊ะเกมแต่ไม่มีข้อมูล เนื่องจากผู้เล่นยังไม่เคยเล่นเกมที่โต๊ะใด ๆ 
	Given The ListGamePlayInfoExecutor has been created and initialized	
	And   Sent userName'BabyBoy' for list game play information
	When  Call ListGamePlayInfoExecutor()
	Then   The game play information should be :
		  |UserName|RoundID	|TotalBetBlack	|TotalBetWhite	|Winner	|WinnerLastUpdate	|			TrackingID				   |		OnGoingTrackingID			  |
@record_mockInfo
Scenario:[ListGamePlayInfo]ระบบไม่ได้รับข้อมูล username ระบบลิสต์ข้อมูลโต๊ะเกมไม่ได้
	Given The ListGamePlayInfoExecutor has been created and initialized
	And   Sent userName'' for list game play information
	When  Call ListGamePlayInfoExecutor() for validate username
	Then  The game play information should be throw exception
