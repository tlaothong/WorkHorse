Feature: ListSingleActionLog
	In order to list single action log
	As a system
	I want to list single action log

@record_mock
Background:
	Given Server has action log information 
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|
		|1			|Nayit		|B324	| 700		|0			|700	|		 | 0		|Normal		|False		|10:54 12/13/2010	|
		|2			|Nayit		|DF23	| 28		|0			|28		|Low	 |78		|Normal		|False		|10:58 12/13/2010	|
		|1			|Nayit		|B324	| 1500		|700		|1500	|Hight	 |1901		|Normal		|True		|11:02 12/13/2010	|
		|1			|Kob		|54DE	| 44		|0			|1544	|Low	 |99		|Normal		|False		|11:14 12/13/2010	|
		|2			|Eye		|123W	| 550		|0			|578	|		 | 0		|Normal		|False		|11:20 12/13/2010	|
		|1			|Krai		|43EE	| 133		|0			|1677	|		 | 0		|Normal		|False		|11:21 12/13/2010	|
		|2			|Jae		|1267	| 1000		|0			|1578	|Hight	 |1500		|Critical	|False		|11:29 12/13/2010	|
		|1			|Sak		|VD66	| 323		|0			|2000	|		 | 0		|Critical	|False		|11:30 12/13/2010	|
		
@record_mock
Scenario:[ListSingleActionLog]ระบบได้รับข้อมูล RoundID ถูกต้อง ระบบสามารถดึงข้อมูล SingleActionLog ได้
	Given The ListSingleActionLogExecutor has been created and initialized
	And   I sent RoundID '1' to list single action log
	When  Call ListSingleActionLogExecutor()
	Then  SingleActionLog information should be as :
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|
		|1			|Nayit		|B324	| 700		|0			|700	|		 |0			|Normal		|False		|10:54 12/13/2010	|	
		|1			|Nayit		|B324	| 1500		|700		|1500	|Hight	 |1901		|Normal		|True		|11:02 12/13/2010	|
		|1			|Kob		|54DE	| 44		|0			|1544	|Low	 |99		|Normal		|False		|11:14 12/13/2010	|		
		|1			|Krai		|43EE	| 133		|0			|1677	|		 |0			|Normal		|False		|11:21 12/13/2010	|		
		|1			|Sak		|VD66	| 323		|0			|2000	|		 |0			|Critical	|False		|11:30 12/13/2010	|

@record_mock
Scenario:[ListSingleActionLog]ระบบได้รับข้อมูล RoundID ที่ไม่มีใน database ได้ข้อมูล SingleActionLog เป็น null
	Given The ListSingleActionLogExecutor has been created and initialized
	And   I sent RoundID '4' to list single action log
	When  Call ListSingleActionLogExecutor()
	Then  SingleActionLog information should be as :
		|RoundID	|UserName	|HandID	| Amount	|OldAmount	|Pot	|WinState|Reward	|HandStatus	|Change		|DateTime			|

@record_mock
Scenario:[ListSingleActionLog]ระบบได้รับข้อมูล RoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล SingleActionLog ได้
	Given The ListSingleActionLogExecutor has been created and initialized
	And   I sent RoundID '-4' for list single action log validation
	When  Call ListSingleActionLogExecutor() for validate input
	Then  SingleActionLog information should be throw exception
	
	