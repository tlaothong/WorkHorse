Feature: ListActionLog
	In order to list action log
	As a system
	I want to list action log of player

@record_mock
Background:
Given Server has action log information as:
|UserName	|DateTime			|Action		|GameName	 | Amount |
|OhAe		|11/25/2010 10:00	|Bet		|White-Colors|70	  |
|Boy		|11/25/2010 11:20	|AutoBet	|MagicNine	 |100	  |
|OhAe		|11/25/2010 11:22	|Bet		|MagicNine	 |1		  |
|Nit		|11/25/2010 11:28	|AutoBet	|Magicnine	 |50	  |
|Nit		|11/25/2010 10:00	|Bet		|White-Colors|20	  |

@record_mock
Scenario: [ListActionLog]ระบบได้รับข้อมูล username ถูกต้อง ระบบสามารถดึงข้อมูล action log ของผู้เล่นได้
	Given The ListActionLogExecutor has been created and initialized
	And   Sent UserName: 'OhAe' for list action log
	When  Call ListActionLogExecutor()
	Then  Action log information should be :
	|UserName	|DateTime			|Action		|GameName	 | Amount |
	|OhAe		|11/25/2010 10:00	|Bet		|White-Colors|70	  |
	|OhAe		|11/25/2010 11:22	|Bet		|MagicNine	 |1		  |

@record_mock
Scenario: [ListActionLog]ระบบได้รับข้อมูล username ถูกต้อง แต่ใน server ยังไม่มีข้อมูล action log 
	Given The ListActionLogExecutor has been created and initialized
	And   Sent UserName: 'Ku' for list action log
	When  Call ListActionLogExecutor()
	Then  Action log information should be :
	|UserName	|DateTime			|Action		|GameName	 | Amount |

@record_mock
Scenario: [ListActionLog]ระบบไม่ได้รับข้อมูล username ระบบไม่สามารถดึงข้อมูล action log ได้
	Given The ListActionLogExecutor has been created and initialized
	And   Sent UserName: '' for validation
	When  Call ListActionLogExecutor() for validate input
	Then  Action log information should be throw exception