Feature: StopAutoBet
	In order to stop bet
	As a back server
	I want to be stop automatic betting

@record_mock
Background: 
	Given (StopAutoBet)server has autobet information as:
	|UserName	|RoundID	|ThruDateTime		|
	|OhAe		|1			|2553/11/24 19:43	|
	|Boy		|2			|null				|
	|Toommy		|3			|2553/11/24 14:43	|
	|Au			|1			|2553/11/24 14:43	|
	|Game		|1			|2553/11/27 18:43	|
	|Khag		|3			|null				|
	|Ple		|4			|2553/11/24 14:43	|

@record_mock
Scenario: (StopAutoBet)ผู้เล่นหยุดการลงพนันอัตโนมัติ การลงพนันอัตโนมัติต้องการหยุดยังทำงานอยู่ ระบบส่งข้อมูลการยกเลิกลงพนันให้ระบบ AutoBet Engine ทำงานต่อ
	Given The StopAutoBetExecutor has been created and initialized
	And (StopAutoBet)sent name: 'Boy' roundID: '2' the autobet information should recieved
	And (StopAutoBet)the autobet information should be update as(UserName: 'Boy', RoundID: '2', StopTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	And the StopAutoBet shoule be call as: (UserName: 'Boy', RoundID: '2', StopTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	When call StopAutoBetExecutor(UserName: 'Boy', RoundID: '2', StopTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then server should call StopAutoBet

@record_mock
Scenario: (StopAutoBet)ผู้เล่นหยุดการลงพนันอัตโนมัติ การลงพนันอัตโนมัติต้องการหยุดได้ถูกหยุดไปแล้ว ระบบแจ้งเตือนผู้เล่นว่าเงินไม่พอ
	Given The StopAutoBetExecutor has been created and initialized
	And (StopAutoBet)sent name: 'OhAe' roundID: '1' the autobet information should recieved
	When Expected exeception and call StopAutoBetExecutor(UserName: 'OhAe', RoundID: '1', StopTrackingID: 'B21F8971-DBAB-400F-9D95-151BA24875C1')
	Then the result should be throw exception