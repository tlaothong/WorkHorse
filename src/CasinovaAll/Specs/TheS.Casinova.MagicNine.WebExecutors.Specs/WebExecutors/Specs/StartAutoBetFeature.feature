Feature: StartAutoBet
	In order to start auto bet
	As a sysytem
	I want to sent StartAutoBet information to back server

@record_mock
Scenario Outline: ระบบได้รับข้อมูลการลงเดิมพันแบบอัตโนมัติจาก client และทำการส่งข้อมูลไปยัง back server
	Given The StartAutoBetExecutor has been created and initialized
	And Sent StartAutoBetInformation userName'<UserName>', roundId '<RoundID>',amount '<Amount>', Interval '<Interval>'
	And Web service has TrackingID for start auto bet: 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'
	When Call StartAutoBetExecutor(userName'<UserName>', roundId '<RoundID>',amount '<Amount>', Interval '<Interval>')
	Then TrackingID of  start auto bet for client and back server should be : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'
	Then The system can't sent StartAutoBetInformation to back server

Examples:
	|UserName	|RoundID	|Amount	|Interval	|
	|Nit		|1			|100	|10			|
	|			|1			|100	|10			|
	|Nit		|0			|100	|10			|
	|Nit		|1			|0		|10			|
	|Nit		|1			|100	|0			|
	