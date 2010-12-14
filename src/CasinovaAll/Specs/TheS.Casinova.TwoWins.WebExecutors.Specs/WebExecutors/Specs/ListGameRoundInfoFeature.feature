Feature: ListGameRoundInfo
	In order to list game round information
	As a system
	I want to list active game rounds at now

@record_mock
Scenario:[ListGameRoundInfo]ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active ณ เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม
	Given The ListGameRoundInfoExecutor has been created and initialized
	And The active game rounds are :
		|RoundID|FromDateTime|ThruDateTime|CriticalDateTime|
		|3		|10:30		 |15:30		  |15:29		   |
		|4		|13:00		 |16:00		  |15:59		   |
		|5		|13:30		 |18:30		  |18:29		   |
		|6		|14:00		 |19:00       |18:59		   |
	When Call ListGameRoundInfoExecutor()
	Then The result should be:
		|RoundID|FromDateTime|ThruDateTime|CriticalDateTime|
		|3		|10:30		 |15:30		  |15:29		   |
		|4		|13:00		 |16:00		  |15:59		   |
		|5		|13:30		 |18:30		  |18:29		   |
		|6		|14:00		 |19:00       |18:59		   |
@record_mock
Scenario:[ListGameRoundInfo]ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active แต่ใน database ยังไม่มีข้อมูล
	Given The ListGameRoundInfoExecutor has been created and initialized
	And  The active game rounds are :
		 |RoundId|FromTime|ThruTime|
		
	When Call ListGameRoundInfoExecutor()
	Then The active game rounds should be null:
