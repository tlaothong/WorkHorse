﻿Feature: ListActiveGameRounds
	In order to list active game rounds 
	As a system
	I want to list active game rounds now

@record_mock
Scenario: ลิสต์ข้อมูลโต๊ะเกมที่กำลัง active ณ เวลาปัจจุบันที่ผู้เล่นเข้าห้องเกม
	Given The ColorsGame has been created and initialized
	And The active game rounds are :
		|TableId|RoundId|StartTime|EndTime|
		|1		|2		|09:00	  |13:00  |
		|2		|3		|10:30	  |15:30  |
		|3		|4		|13:00	  |16:00  |
		|4		|5		|13:30	  |18:30  |
		|5		|6		|14:00	  |19:00  |
	
	When Call ListActiveGameRoundsExecutor
	Then The result should be:
		|TableId|RoundId|StartTime|EndTime|
		|1		|2		|09:00	  |13:00  |
		|2		|3		|10:30	  |15:30  |
		|3		|4		|13:00	  |16:00  |
		|4		|5		|13:30	  |18:30  |
		|5		|6		|14:00	  |19:00  |
	
