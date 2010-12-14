Feature: ListGamePlayInfo
	In order to list game play information
	As a system
	I want to list game play information

@record_mock
Background:
Given Server has game play totalbet information as :
		|RoundID	|UserName	|TotalBet	|
		|1			|Sak		|1			|
		|1			|Nayit		|55			|
		|1			|Ae			|700		|
		|2			|Nayit		|99			|
		|2			|Ae			|78			|
		|3			|Meaw		|34			|
		|3			|Sak		|56			|
		|3			|Au			|1			|
		|4			|Nat		|100		|
		|5			|Nayit		|7			|
		|5			|Krai		|560		|
		

@record_mock
Scenario:[ListGamePlayInfo] ระบบได้รับข้อมูล UserName ถูกต้อง ระบบสามารถดึงข้อมูล GamePlayInformation ได้
	Given The ListGamePlayInfoExecutor has been created and initialized
	And   Sent UserName'Nayit' to list game play information
	When  Call ListGamePlayInfoExecutor()
	Then  GamePlay information should be as :
		|RoundID	|UserName	|TotalBet	|
		|1			|Nayit		|55			|
		|2			|Nayit		|99			|
		|5			|Nayit		|7			|

@record_mock
Scenario:[ListGamePlayInfo] ระบบได้รับข้อมูล UserName ถูกต้อง แต่ใน database ยังไม่มีข้อมูล GamePlayInformation จะได้ข้อมูลเป็น null
	Given The ListGamePlayInfoExecutor has been created and initialized
	And   Sent UserName'Art' to list game play information
	When  Call ListGamePlayInfoExecutor()
	Then  GamePlay information should be as :
		|RoundID	|UserName	|TotalBet	|

@record_mock
Scenario:[ListGamePlayInfo] ระบบไม่ได้รับข้อมูล UserName ระบบไม่สามารถดึงข้อมูล GamePlayInformation ได้
	Given The ListGamePlayInfoExecutor has been created and initialized
	And   Sent UserName'' for list game play information validtion
	When  Call ListGamePlayInfoExecutor() for validate input
	Then  GamePlay information should be throw exception
		

		