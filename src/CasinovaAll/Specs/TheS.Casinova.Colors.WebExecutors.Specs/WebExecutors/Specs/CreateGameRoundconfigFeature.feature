Feature: CreateGameRoundConfiguration
	In order to sent game round configurations
	As a system
	I want to sent game round configurations to create

@record_mock
Scenario: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบสามารถส่งข้อมูลไป BackServer ได้
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And   System can sent game round configuration informations are : Name'ColorsGame',TableAmount'5', GameDuration'30', Interval'10', BufferRoundCount'3'
 When  System can call CreateGameRoundConfigExecutor()
 Then  The system can sent GameRoundConfigurations to back server

@record_mock
Scenario: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูล ข้อมูล Name ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And   Game round configuration informations are : Name'no',TableAmount'5', GameDuration'30', Interval'10', BufferRoundCount'3'
 When  Call CreateGameRoundConfigExecutor()
 Then  The system can't sent GameRoundConfigurations to back server

 @record_mock
Scenario: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูล ไม่มีข้อมูล Name ระบบไม่สามารถส่งข้อมูลไป BackServer ได้
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And   Game round configuration informations are : Name'',TableAmount'5', GameDuration'30', Interval'10', BufferRoundCount'3'
 When  Call CreateGameRoundConfigExecutor()
 Then  The system can't sent GameRoundConfigurations to back server

@record_mock
Scenario: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูล ข้อมูล TableAmount ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And   Game round configuration informations are : Name'ColorsGame1',TableAmount'-2', GameDuration'30', Interval'10', BufferRoundCount'3'
 When  Call CreateGameRoundConfigExecutor()
 Then  The system can't sent GameRoundConfigurations to back server
 
 @record_mock
Scenario: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูล ข้อมูล GameDuration ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And   Game round configuration informations are : Name'ColorsGame1',TableAmount'5', GameDuration'1550', Interval'10', BufferRoundCount'3'
 When  Call CreateGameRoundConfigExecutor()
 Then  The system can't sent GameRoundConfigurations to back server

 @record_mock
Scenario: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูล ข้อมูล Interval ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And   Game round configuration informations are : Name'ColorsGame1',TableAmount'5', GameDuration'30', Interval'-30', BufferRoundCount'3'
 When  Call CreateGameRoundConfigExecutor()
 Then  The system can't sent GameRoundConfigurations to back server

 @record_mock
Scenario: ระบบได้รับข้อมูล GameRoundConfigurations ระบบทำการตรวจสอบข้อมูล ข้อมูล BufferRoundCount ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลไป BackServer ได้
 Given The CreateGameRoundConfigExecutor has been created and initialized
 And   Game round configuration informations are : Name'ColorsGame1',TableAmount'5', GameDuration'30', Interval'10', BufferRoundCount'-3'
 When  Call CreateGameRoundConfigExecutor()
 Then  The system can't sent GameRoundConfigurations to back server

