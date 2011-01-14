Feature: ListBetLog
	In order to ให้ client นำข้อมูลไปแสดงที่ UI เพื่อให้ผู้เล่นทราบถึงผลการเล่นที่กดเล่นได้แต่ละครั้ง
	As a User
	I want to ดึงข้อมูลค่า bet log

@record_mock
Scenario:[ListBetLog]ระบบได้รับข้อมูล UserName และ RoundID ถูกต้อง ระบบสามารถลีสต์ข้อมูล Bet log ได้ 
	Given The ListBetLogExecutor has been created and initialized
	Given server has BetLog information as:
		|UserName	|RoundID	|BetDateTime |BetOrder|BetTrackingID						|
		|Nit		|1			|10:00		 |1		  |03D51BC1-1656-454B-8CB2-4202BA8C21D7	|
		|Boy		|1			|10:05		 |6		  |09630A4D-0B6C-4672-95F0-0AE5E48614FD |
		|Boy		|1			|10:10		 |7		  |2ED52C48-5C9A-471B-9335-DDAE19F44BE6	|
		|Nit		|1			|10:15		 |2 	  |833278AF-A221-4916-90CD-96951051F40F	|
	And   Sent UserName'Nit', RoundID '1' for test function
	When  Call ListBetLogExecutor()
	Then  The result of BetLog should be :
		|UserName	|RoundID	|BetDateTime |BetOrder|BetTrackingID						|
		|Nit		|1			|10:00		 |1		  |03D51BC1-1656-454B-8CB2-4202BA8C21D7	|
		|Nit		|1			|10:15		 |2 	  |833278AF-A221-4916-90CD-96951051F40F	|

@record_mock
Scenario:[ListBetLog]ระบบได้รับ RoundID ที่ยังไม่มีบันทึกการลงเดิมพันของผู้เล่นใน database ได้ข้อมูล Bet log เป็น null 
	Given The ListBetLogExecutor has been created and initialized
	Given server has BetLog information as:
		|UserName	|RoundID	|BetDateTime |BetOrder|BetTrackingID						|
		|Nit		|1			|10:00		 |1		  |03D51BC1-1656-454B-8CB2-4202BA8C21D7	|
		|Boy		|1			|10:05		 |6		  |09630A4D-0B6C-4672-95F0-0AE5E48614FD |
		|Boy		|1			|10:10		 |7		  |2ED52C48-5C9A-471B-9335-DDAE19F44BE6	|
		|Nit		|1			|10:15		 |2 	  |833278AF-A221-4916-90CD-96951051F40F	|
	And   Sent UserName'nit', RoundID '2' for test function
	When  Call ListBetLogExecutor()
	Then  The result of BetLog should be :
		|UserName	|RoundID	|BetDateTime |BetOrder|BetTrackingID						|


@record_mock
Scenario:[ListBetLog]ระบบได้รับ UserName ที่ยังไม่มีบันทึกการลงเดิมพันของผู้เล่นใน database ได้ข้อมูล Bet log เป็น null 
	Given The ListBetLogExecutor has been created and initialized
	Given server has BetLog information as:
		|UserName	|RoundID	|BetDateTime |BetOrder|BetTrackingID						|
		|Nit		|1			|10:00		 |1		  |03D51BC1-1656-454B-8CB2-4202BA8C21D7	|
		|Boy		|1			|10:05		 |6		  |09630A4D-0B6C-4672-95F0-0AE5E48614FD |
		|Boy		|1			|10:10		 |7		  |2ED52C48-5C9A-471B-9335-DDAE19F44BE6	|
		|Nit		|1			|10:15		 |2 	  |833278AF-A221-4916-90CD-96951051F40F	|
	And   Sent UserName'Ae', RoundID '1' for test function
	When  Call ListBetLogExecutor()
	Then  The result of BetLog should be :
		|UserName	|RoundID	|BetDateTime |BetOrder|BetTrackingID						|

@record_mock
Scenario:[ListBetLog]ระบบได้รับ UserName ไม่ถูกต้อง ระบบไม่สามารถลีสต์ข้อมูล Bet log ได้
	Given The ListBetLogExecutor has been created and initialized
	And   Sent UserName'', RoundID '1' for validate
	When  Call ListBetLogExecutor() for validate input information
	Then  The result of BetLog should be throw exception

@record_mock
Scenario:[ListBetLog]ระบบได้รับ RoundID ไม่ถูกต้อง ระบบไม่สามารถลีสต์ข้อมูล Bet log ได้
	Given The ListBetLogExecutor has been created and initialized
	And   Sent UserName'Nit', RoundID '-1' for validate
	When  Call ListBetLogExecutor() for validate input information
	Then  The result of BetLog should be throw exception

@record_mock
Scenario:[ListBetLog]ระบบได้รับ UserName และ RoundID  ไม่ถูกต้อง ระบบไม่สามารถลีสต์ข้อมูล Bet log ได้
	Given The ListBetLogExecutor has been created and initialized
	And   Sent UserName'', RoundID '-1' for validate
	When  Call ListBetLogExecutor() for validate input information
	Then  The result of BetLog should be throw exception
