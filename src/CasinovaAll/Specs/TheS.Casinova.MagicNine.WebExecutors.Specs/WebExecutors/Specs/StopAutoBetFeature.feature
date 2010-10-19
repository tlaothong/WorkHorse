Feature: StopAutoBet
	In order to stop auto bet
	As a sysytem
	I want to sent StopAutoBet information to back server

@record_mock
Scenario Outline: ระบบได้รับข้อมูลให้หยุดการลงเดิมพันแบบอัตโนมัติจาก client และทำการส่งข้อมูลไปยัง back server
	Given The StopAutoBetExecutor has been created and initialized
	And Sent StopAutoBetInformation userName'<UserName>'
	And Web service has TrackingID for stop auto bet: 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'
	When Call StopAutoBetExecutor(userName'<UserName>')
	Then TrackingID of  stop auto bet for client and back server should be : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'
	Then The system can't sent StopAutoBetInformation to back server

Examples:
	|UserName	|
	|Nit		|
	|			|