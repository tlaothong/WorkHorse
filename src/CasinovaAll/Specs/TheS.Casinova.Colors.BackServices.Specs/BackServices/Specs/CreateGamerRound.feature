﻿Feature: Create Game Rounds
	In order to create round from table configuration
	As a back server
	I want to get the configuration and active game round to create the new game round.

Background:
Given server has GameRoundConfiguration information as:
	|Name	|TableAmount	|GameDuration	|Interval	|BufferRoundsCount	|
	|config1|4				|30				|5			|1					|
	|config2|5				|20				|8			|1					|
	|config3|3				|30				|5			|1					|
	|config4|5				|10				|3			|1					|
	|config5|7				|15				|10			|1					|

@record_mock
Scenario: (CreateGameRounds)ได้รับข้อมูล config มีโต๊ะเกมที่เริ่มเล่นอยู่ในระบบไม่ตรงกับค่าที่ตั้งไว้, ระบบสร้างโต๊ะเกมที่เหลือ
	Given The CreateGameRoundsExecutor has been created and initialized
	And sent Name: 'config1', the GameRoundConfiguration should recieved
	And server should recieved the active game round data as:
	|RoundID	|StartTime			|EndTime			|
	|3			|2553/3/12 10:00	|2553/3/12 10:30	|
	|4			|2553/3/12 10:05	|2553/3/12 10:35	|
	|5			|2553/3/12 10:10	|2553/3/12 10:40	|

	And Expect result should be create as:
	|RoundID	|StartTime			|EndTime			|
	|6			|2553/3/12 10:15	|2553/3/12 10:45	|
	|7			|2553/3/12 10:20	|2553/3/12 10:50	|

	When call CreateGameRound(ConfigName: 'config1')
	Then the result should be create data as:
	|RoundID	|StartTime			|EndTime			|
	|3			|2553/3/12 10:00	|2553/3/12 10:30	|
	|4			|2553/3/12 10:05	|2553/3/12 10:35	|
	|5			|2553/3/12 10:10	|2553/3/12 10:40	|
	|6			|2553/3/12 10:15	|2553/3/12 10:45	|
	|7			|2553/3/12 10:20	|2553/3/12 10:50	|

@record_mock
Scenario: (CreateGameRounds)ได้รับข้อมูล config มีโต๊ะเกมที่เริ่มเล่นอยู่ในระบบตรงกับค่าที่ตั้งไว้, ระบบเสมือนทำงานสำเร็จ
	Given The CreateGameRoundsExecutor has been created and initialized
	And sent Name: 'config1', the GameRoundConfiguration should recieved
	And server should recieved the active game round data as:
	|RoundID	|StartTime			|EndTime			|
	|1			|2553/3/12 10:00	|2553/3/12 10:30	|
	|2			|2553/3/12 10:05	|2553/3/12 10:35	|
	|3			|2553/3/12 10:10	|2553/3/12 10:40	|
	|4			|2553/3/12 10:15	|2553/3/12 10:45	|
	|5			|2553/3/12 10:20	|2553/3/12 10:50	|

	When call CreateGameRound(ConfigName: 'config1')
	Then the result should be same as old

@record_mock
Scenario: (CreateGameRounds)ได้รับข้อมูล config ไม่มีโต๊ะเกมที่เริ่มเล่นอยู่ในระบบ, ระบบสร้างโต๊ะเกมใหม่ทั้งหมด
	Given The CreateGameRoundsExecutor has been created and initialized
	And sent Name: 'config3', the GameRoundConfiguration should recieved
	And server should recieved the active game round data as:
	|RoundID	|StartTime			|EndTime			|

	And Expect result should be create at datetime (2553/3/12 10:00):
	|RoundID	|StartTime			|EndTime			|
	|1			|2553/3/12 10:00	|2553/3/12 10:30	|
	|2			|2553/3/12 10:05	|2553/3/12 10:35	|
	|3			|2553/3/12 10:10	|2553/3/12 10:40	|
	|4			|2553/3/12 10:15	|2553/3/12 10:45	|

	When call CreateGameRound(ConfigName: 'config1')
	Then the result should be create data as:
	|RoundID	|StartTime			|EndTime			|
	|1			|2553/3/12 10:00	|12/3/2553 10:30	|
	|2			|2553/3/12 10:05	|12/3/2553 10:35	|
	|3			|2553/3/12 10:10	|12/3/2553 10:40	|
	|4			|2553/3/12 10:15	|12/3/2553 10:45	|
	|5			|2553/3/12 10:20	|12/3/2553 10:50	|

