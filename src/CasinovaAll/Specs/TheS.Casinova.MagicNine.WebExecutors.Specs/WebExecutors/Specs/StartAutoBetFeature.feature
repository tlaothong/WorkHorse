Feature: StartAutoBet
	In order to start autobet
	As a sysytem
	I want to sent autobet information to back server

@record_mock
Scenario: ระบบได้รับข้อมูลการลงเดิมพันแบบอัตโนมัติจาก client และทำการส่งข้อมูลไปยัง back server
	Given The StartAutoBetExecutor has been created and initialized
	And Web service has TrackingID : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'
	When Call StartAutoBetExecutor(userName'Nit', roundId '1',amount '100', Interval '5')
	Then TrackingID for client and back server should be : 'DA1FE75E-9042-4FC5-B3CF-1E973D2152F7'
