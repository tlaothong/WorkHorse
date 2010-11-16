Feature: CreateGameRoundConfiguration
	In order to sent game round configurations
	As a system
	I want to sent game round configurations to create

@record_mock
Scenario Outline: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูลและทำการส่งข้อมูลไปยัง BackServer ต่อไป
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And  Game round configuration informations are : Name'<Name>',TableAmount'<TableAmount>', GameDuration'<GameDuration>', Interval'<Interval>', BufferRoundCount'<BufferRoundCount>'
 When Call CreateGameRoundConfigExecutor()
 Then The system can sent GameRoundConfigurations to back server
 Then The system can't sent GameRoundConfigurations to back server

 