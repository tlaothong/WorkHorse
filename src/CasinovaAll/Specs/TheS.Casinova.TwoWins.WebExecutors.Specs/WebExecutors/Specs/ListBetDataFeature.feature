Feature: ListBetData
	In order to list bet data 
	As a system
	I want to list bet data of all players

@record_mock
Background:
	Given Server has bet data of finished game
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|
		|1			|Nayit		|B324	| 700		|0			|700	|		 |0			|Normal		|False		|10:54 12/13/2010	|
		|2			|Nayit		|DF23	| 28		|0			|28		|Low	 |78		|Normal		|False		|10:58 12/13/2010	|
		|1			|Nayit		|B324	| 1500		|700		|1500	|Hight	 |1901		|Normal		|True		|11:02 12/13/2010	|
		|1			|Kob		|54DE	| 44		|0			|1544	|Low	 |99		|Normal		|False		|11:14 12/13/2010	|
		|2			|Eye		|123W	| 550		|0			|578	|		 |0			|Normal		|False		|11:20 12/13/2010	|
		|1			|Krai		|43EE	| 133		|0			|1677	|		 |0			|Normal		|False		|11:21 12/13/2010	|
		|2			|Jae		|1267	| 1000		|0			|1578	|Hight	 |1500		|Critical	|False		|11:29 12/13/2010	|
		|1			|Sak		|VD66	| 323		|0			|2000	|		 |0			|Critical	|False		|11:30 12/13/2010	|
		
@record_mock
Scenario:[ListBetData]ระบบได้รับข้อมูล FromRoundID, ThruRoundID ถูกต้อง ระบบสามารถดึงข้อมูล BetData ได้
	Given The ListBetDataExecutor has been created and initialized
	And   Sent FromRoundID'1' ThruRoundID'2' to list bet data
	When  Call ListBetDataExecutor()
	Then  BetData information should be as :
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|
		|1			|Nayit		|B324	| 700		|0			|700	|		 |0 		|Normal		|False		|10:54 12/13/2010	|	
		|1			|Nayit		|B324	| 1500		|700		|1500	|Hight	 |1901		|Normal		|True		|11:02 12/13/2010	|
		|1			|Kob		|54DE	| 44		|0			|1544	|Low	 |99		|Normal		|False		|11:14 12/13/2010	|		
		|1			|Krai		|43EE	| 133		|0			|1677	|		 |0			|Normal		|False		|11:21 12/13/2010	|		
		|1			|Sak		|VD66	| 323		|0			|2000	|		 |0			|Critical	|False		|11:30 12/13/2010	|
		|2			|Nayit		|DF23	| 28		|0			|28		|Low	 |78		|Normal		|False		|10:58 12/13/2010	|
		|2			|Eye		|123W	| 550		|0			|578	|		 |0			|Normal		|False		|11:20 12/13/2010	|
		|2			|Jae		|1267	| 1000		|0			|1578	|Hight	 |1500		|Critical	|False		|11:29 12/13/2010	|

@record_mock
Scenario:[ListBetData]ระบบได้รับข้อมูล ThruRoundID ที่ยังไม่จบเกม ระบบดึงข้อมูล BetData ถึงโต๊ะเกมสุดท้ายที่จบเกม
	Given The ListBetDataExecutor has been created and initialized
	And   Sent FromRoundID'1' ThruRoundID'4' to list bet data
	When  Call ListBetDataExecutor()
	Then  BetData information should be as :
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|
		|1			|Nayit		|B324	| 700		|0			|700	|		 |0 		|Normal		|False		|10:54 12/13/2010	|	
		|1			|Nayit		|B324	| 1500		|700		|1500	|Hight	 |1901		|Normal		|True		|11:02 12/13/2010	|
		|1			|Kob		|54DE	| 44		|0			|1544	|Low	 |99		|Normal		|False		|11:14 12/13/2010	|		
		|1			|Krai		|43EE	| 133		|0			|1677	|		 |0			|Normal		|False		|11:21 12/13/2010	|		
		|1			|Sak		|VD66	| 323		|0			|2000	|		 |0			|Critical	|False		|11:30 12/13/2010	|
		|2			|Nayit		|DF23	| 28		|0			|28		|Low	 |78		|Normal		|False		|10:58 12/13/2010	|
		|2			|Eye		|123W	| 550		|0			|578	|		 |0			|Normal		|False		|11:20 12/13/2010	|
		|2			|Jae		|1267	| 1000		|0			|1578	|Hight	 |1500		|Critical	|False		|11:29 12/13/2010	|

@record_mock
Scenario:[ListBetData]ระบบได้รับข้อมูล FromRoundID, ThruRoundID ที่ยังไม่จบเกม ระบบได้ข้อมูล BetData เป็น null
	Given The ListBetDataExecutor has been created and initialized
	And   Sent FromRoundID'3' ThruRoundID'4' to list bet data
	When  Call ListBetDataExecutor()
	Then  BetData information should be as :
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|Reward|GetBack	|HandStatus	|Change		|DateTime			|
		

@record_mock
Scenario:[ListBetData]ระบบได้รับข้อมูล FromRoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetData ได้
	Given The ListBetDataExecutor has been created and initialized
	And   Sent FromRoundID'-1' ThruRoundID'4' for list bet data validation
	When  Call ListBetDataExecutor() for validate input
	Then  BetData information should be throw exception

@record_mock
Scenario:[ListBetData]ระบบได้รับข้อมูล ThruRoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetData ได้
	Given The ListBetDataExecutor has been created and initialized
	And   Sent FromRoundID'1' ThruRoundID'-4' for list bet data validation
	When  Call ListBetDataExecutor() for validate input
	Then  BetData information should be throw exception
		
		