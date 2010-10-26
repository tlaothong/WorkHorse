Feature: ListActionLog
	In order to list action log
	As a system
	I want to list action log of player

@record_mock
Background:
Given Server has action log information as:
|UserName	|DateTime			|Action		|GameName	 | Amount |
|OhAe		|2553/3/12 10:00	|Bet		|White-Colors|70	  |
|Boy		|2553/3/12 11:20	|AutoBet	|MagicNine	 |100	  |
|OhAe		|2553/3/12 11:22	|Bet		|MagicNine	 |1		  |
|Nit		|2553/3/12 11:28	|AutoBet	|Magicnine	 |50	  |
|Nit		|2553/3/12 10:00	|Bet		|White-Colors|20	  |

@record_mock
Scenario: ระบบได้รับข้อมูล username ถูกต้อง ระบบสามารถดึงข้อมูล action log ของผู้เล่นได้
	Given The ListActionLogExecutor has been created and initialized
	And   Sent UserName: 'OhAe'
	When  Call ListActionLogExecutor
	Then Action log information should be :
	|UserName	|DateTime			|Action		|GameName	 | Amount |
	|OhAe		|2553/3/12 10:00	|Bet		|White-Colors|70	  |
	|OhAe		|2553/3/12 11:22	|Bet		|MagicNine	 |1		  |

@record_mock
Scenario: ระบบได้รับข้อมูล username ถูกต้อง แต่ใน server ยังไม่มีข้อมูล action log 
	Given The ListActionLogExecutor has been created and initialized
	And   Sent UserName: 'Ku'
	When  Call ListActionLogExecutor
	Then Action log information should be null

@record_mock
Scenario: ระบบได้รับข้อมูล username ไม่ถูกต้อง # ListActionLog
	Given The ListActionLogExecutor has been created and initialized
	And   Sent UserName: ''
	When  Call ListActionLogExecutor
	Then Action log information should be null