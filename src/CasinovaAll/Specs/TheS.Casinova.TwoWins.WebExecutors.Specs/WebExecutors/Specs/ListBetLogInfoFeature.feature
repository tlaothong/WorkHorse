Feature: ListbetLogInfo
	In order to list bet log information
	As a system
	I want to list bet log information

@record_mock
Background:
Given Server has bet log information as :
		|RoundID	|UserName	|HandID	| Amount	|HandStatus	|BetDateTime		|
		|1			|Nayit		|1		| 700		|Normal		|10:54 12/13/2010	|
		|2			|Nayit		|1		| 28		|Normal		|10:58 12/13/2010	|
		|1			|Nayit		|2		| 1500		|Normal		|11:02 12/13/2010	|
		|1			|Kob		|3		| 44		|Normal		|11:14 12/13/2010	|
		|2			|Eye		|2		| 550		|Normal		|11:20 12/13/2010	|
		|1			|Krai		|4		| 133		|Normal		|11:21 12/13/2010	|
		|2			|Jae		|3		| 1000		|Critical	|11:29 12/13/2010	|
		|1			|Sak		|5		| 323		|Critical	|11:30 12/13/2010	|
		

@record_mock
Scenario:[ListBetLogInfo] ระบบได้รับข้อมูล UserName, RoundID ถูกต้อง ระบบสามารถดึงข้อมูล BetLogInformation ได้
	Given The ListBetLogInfoExecutor has been created and initialized
	And   Sent UserName'Nayit' RoundID'1' to list bet log information
	When  Call ListBetLogInfoExecutor()
	Then  BetLog information should be as :
		|RoundID	|UserName	|HandID	| Amount	|HandStatus	|BetDateTime		|
		|1			|Nayit		|1		| 700		|Normal		|10:54 12/13/2010	|
		|1			|Nayit		|2		| 1500		|Normal		|11:02 12/13/2010	|

@record_mock
Scenario:[ListBetLogInfo] ระบบได้รับข้อมูล RoundID ที่ยังไม่มีข้อมูลใน database ได้ข้อมูล BetLogInformation เป็น null 
	Given The ListBetLogInfoExecutor has been created and initialized
	And   Sent UserName'Nayit' RoundID'3' to list bet log information
	When  Call ListBetLogInfoExecutor()
	Then  BetLog information should be as :
		|RoundID	|UserName	|HandID	| Amount	|HandStatus	|BetDateTime		|
		
@record_mock
Scenario:[ListBetLogInfo] ระบบได้รับข้อมูล UserName ที่ยังไม่มีข้อมูลใน database ได้ข้อมูล BetLogInformation เป็น null 
	Given The ListBetLogInfoExecutor has been created and initialized
	And   Sent UserName'Pla' RoundID'1' to list bet log information
	When  Call ListBetLogInfoExecutor()
	Then  BetLog information should be as :
		|RoundID	|UserName	|HandID	| Amount	|HandStatus	|BetDateTime		|

@record_mock
Scenario:[ListBetLogInfo] ระบบได้รับข้อมูล UserName ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetLogInformation ได้
	Given The ListBetLogInfoExecutor has been created and initialized
	And   Sent UserName'' RoundID'1' for list bet log information validation
	When  Call ListBetLogInfoExecutor() for validate input
	Then  BetLog information should be throw exception

@record_mock
Scenario:[ListBetLogInfo] ระบบได้รับข้อมูล RoundID ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล BetLogInformation ได้
	Given The ListBetLogInfoExecutor has been created and initialized
	And   Sent UserName'Nayit' RoundID'-1' for list bet log information validation
	When  Call ListBetLogInfoExecutor() for validate input
	Then  BetLog information should be throw exception