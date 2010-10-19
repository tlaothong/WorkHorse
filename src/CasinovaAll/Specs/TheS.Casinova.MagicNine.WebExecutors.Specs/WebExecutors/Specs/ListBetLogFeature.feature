Feature: ListBetLog
	In order to list bet log
	As a system
	I want to list bet log of player

@record_mock
Background: ListBetLog
	Given server has player information as:
	|UserName	|RoundID	|BetDateTime |BetOrder|TrackingID							|
	|Nit		|1			|10:00		 |5		  |03D51BC1-1656-454B-8CB2-4202BA8C21D7	|
	|Nit		|1			|10:05		 |9		  |09630A4D-0B6C-4672-95F0-0AE5E48614FD |
	|Nit		|1			|10:10		 |17	  |2ED52C48-5C9A-471B-9335-DDAE19F44BE6	|
	|Nit		|1			|10:15		 |26	  |833278AF-A221-4916-90CD-96951051F40F	|

@record_mock
Scenario:ระบบได้รับ userName และ roundId ถูกต้อง
	Given The BetInformation has been created and initialized
	And Expect execute ListBetLogCommand
	When Call ListBetLogExecutor(userName'Nit', roundId '1')
	Then The result of BetLog should be :
	|UserName	|RoundID	|BetDateTime |BetOrder|TrackingID							|
	|Nit		|1			|10:00		 |5		  |03D51BC1-1656-454B-8CB2-4202BA8C21D7	|
	|Nit		|1			|10:05		 |9		  |09630A4D-0B6C-4672-95F0-0AE5E48614FD |
	|Nit		|1			|10:10		 |17	  |2ED52C48-5C9A-471B-9335-DDAE19F44BE6	|
	|Nit		|1			|10:15		 |26	  |833278AF-A221-4916-90CD-96951051F40F	|

@record_mock
Scenario:ระบบได้รับ userName ไม่ถูกต้อง #ListBetLog
	Given The BetInformation has been created and initialized
	When Call ListBetLogExecutor(userName'', roundId '1')
	Then The result of BetLog should be null

@record_mock
Scenario:ระบบได้รับ roundId  ไม่ถูกต้อง #ListBetLog
	Given The BetInformation has been created and initialized
	When Call ListBetLogExecutor(userName'Nit', roundId '-1')
	Then The result of BetLog should be null

@record_mock
Scenario:ระบบได้รับ userName และ roundId  ไม่ถูกต้อง #ListBetLog
	Given The BetInformation has been created and initialized
	When Call ListBetLogExecutor(userName'', roundId '-1')
	Then The result of BetLog should be null

@record_mock
Scenario:ระบบได้รับ userName และ roundId แต่ใน database ยังไม่มีบันทึกการลงเดิมพันของผู้เล่น #ListBetLog
	Given The BetInformation has been created and initialized
	When Call ListBetLogExecutor(userName'Ae', roundId '2')
	Then The result of BetLog should be null