Feature: ListBetLog
	In order to list all bet information that player has beted at round
	As a back server
	I want to be told the bet log information

@record_mock
Background:
Given server has bet information as:
|RoundID	|UserName	|DateTime			|BetOrder	|TrackingID							 |
|12			|OhAe		|2553/3/12 10:00	|12			|B21F8971-DBAB-400F-9D95-151BA24875C1|
|12			|Boy		|2553/3/12 11:20	|23			|B21F8971-DBAB-400F-9D95-151BA24875C1|
|12			|OhAe		|2553/3/12 11:22	|42			|B21F8971-DBAB-400F-9D95-151BA24875C1|
|12			|OhAe		|2553/3/12 11:28	|99			|B21F8971-DBAB-400F-9D95-151BA24875C1|
|13			|Nit		|2553/3/12 10:00	|24			|B21F8971-DBAB-400F-9D95-151BA24875C1|
|13			|Boy		|2553/3/12 11:20	|76			|B21F8971-DBAB-400F-9D95-151BA24875C1|
|14			|OhAe		|2553/3/12 11:22	|92			|B21F8971-DBAB-400F-9D95-151BA24875C1|
|14			|OhAe		|2553/3/12 11:28	|32			|B21F8971-DBAB-400F-9D95-151BA24875C1|

@record_mock
Scenario: ได้รับข้อมูล RoundID, UserName, มีข้อมูลที่ต้องการในระบบ, ระบบดึงประวัติการลงพนันของผู้เล่นทั้งหมดในโต๊ะเกมแล้วส่งกลับ
	Given The ListBetLogExecutor has been created and initialized
	And sent RoundID: '12', UserName: 'OhAe' and expected BetInformation(s) recieved
	When call ListBetLogCommand(RoundID: '12', UserName: 'OhAe')
	Then the result should be list bet information(s) as:
	|RoundID	|UserName	|DateTime			|BetOrder	|TrackingID							 |
	|12			|OhAe		|2553/3/12 10:00	|12			|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|OhAe		|2553/3/12 11:22	|42			|B21F8971-DBAB-400F-9D95-151BA24875C1|
	|12			|OhAe		|2553/3/12 11:28	|99			|B21F8971-DBAB-400F-9D95-151BA24875C1|

@record_mock
Scenario: ได้รับข้อมูลโต๊ะเกมและชื่อผู้เล่น, ไม่มีข้อมูลที่ต้องการในระบบ, ระบบดึงประวัติการลงพนันของผู้เล่นทั้งหมดในโต๊ะเกมแล้วส่งกลับ
	Given The ListBetLogExecutor has been created and initialized
	And sent RoundID: '13', UserName: 'OhAe' and expected BetInformation(s) is emtpy
	When call ListBetLogCommand(RoundID: '13', UserName: 'OhAe')
	Then the result should be null

