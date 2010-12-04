Feature: ListActiveGameRounds
	In order to list active game rounds 
	As a system
	I want to list active game rounds at now

@record_mock
Scenario:[ListActiveGameRound]ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active ณ เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม
	Given The ListActiveGameRoundsExecutor has been created and initialized
	And The active game rounds are :
		|RoundID|StartTime|EndTime|
		|3		|10:30	  |15:30  |
		|4		|13:00	  |16:00  |
		|5		|13:30	  |18:30  |
		|6		|14:00	  |19:00  |
	When Call ListActiveGameRoundsExecutor()
	Then The result should be:
		|RoundID|StartTime|EndTime|
		|3		|10:30	  |15:30  |
		|4		|13:00	  |16:00  |
		|5		|13:30	  |18:30  |
		|6		|14:00	  |19:00  |
	
@record_mock
Scenario:[ListActiveGameRound]ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active แต่ใน database ยังไม่มีข้อมูล
	Given The ListActiveGameRoundsExecutor has been created and initialized
	And  The active game rounds are :
		 |RoundId|StartTime|EndTime|
		
	When Call ListActiveGameRoundsExecutor()
	Then The active game rounds should be null:
		