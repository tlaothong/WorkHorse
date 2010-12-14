Feature: ListRangeActionLog
	In order list range action log
	As a system
	I want to list range action log information

@record_mock
Background:
	Given Server has bet data of finished game #ListRangeActionLog 
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|
		|1			|Nayit		|B324	| 700		|0			|700	|		 |0			|Normal		|False		|10:54 12/13/2010	|
		|2			|Nayit		|DF23	| 28		|0			|28		|Low	 |78		|Normal		|False		|10:58 12/13/2010	|
		|1			|Nayit		|B324	| 1500		|700		|1500	|Hight	 |1901		|Normal		|True		|11:02 12/13/2010	|
		|1			|Kob		|54DE	| 44		|0			|1544	|Low	 |99		|Normal		|False		|11:14 12/13/2010	|
		|2			|Eye		|123W	| 550		|0			|578	|		 |0			|Normal		|False		|11:20 12/13/2010	|
		|1			|Krai		|43EE	| 133		|0			|1677	|		 |0			|Normal		|False		|11:21 12/13/2010	|
		|2			|Jae		|1267	| 1000		|0			|1578	|Hight	 |1500		|Critical	|False		|11:29 12/13/2010	|
		|1			|Sak		|VD66	| 323		|0			|2000	|		 |0			|Critical	|False		|11:30 12/13/2010	|
		
	And Server has Pot and HandCount information as:
		|RoundID	|Pot	|HandsCount	| 
		|1			|2000	|5			| 
		|2			|1578	|3			| 
		
@record_mock
Scenario:[ListRangeActionLog]ระบบได้รับข้อมูล FromRoundID, ThruRoundID ถูกต้อง ระบบสามารถดึงข้อมูล RangeActionLog ได้
	Given The ListRangeActionLogExecutor has been created and initialized
	And   Sent FromRoundID'1' ThruRoundID'2' to list range action log
	When  Call ListRangeActionLogExecutor()
	Then  RangeActionLog information should be as :
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|	
		|1			|Nayit		|B324	| 1500		|700		|1500	|Hight	 |1901		|Normal		|True		|11:02 12/13/2010	|
		|1			|Kob		|54DE	| 44		|0			|1544	|Low	 |99		|Normal		|False		|11:14 12/13/2010	|		
		|2			|Nayit		|DF23	| 28		|0			|28		|Low	 |78		|Normal		|False		|10:58 12/13/2010	|
		|2			|Jae		|1267	| 1000		|0			|1578	|Hight	 |1500		|Critical	|False		|11:29 12/13/2010	|

	And Game result Pot'3578' HandCount'8'