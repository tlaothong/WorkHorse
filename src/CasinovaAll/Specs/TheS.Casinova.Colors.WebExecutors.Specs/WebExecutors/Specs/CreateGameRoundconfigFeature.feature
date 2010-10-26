Feature: CreateGameRoundConfiguration
	In order to sent game round configurations
	As a math system
	I want to sent game round configurations to create

@record_mock
Scenario Outline: ระบบได้รับข้อมูล GameRoundConfigurations และทำการส่งข้อมูลปยัง BackServer
 Given The GameRoundConfigurations has been created and initialized
 When Call Create(Name'<Name>',TableAmount'<TableAmount>', GameDuration'<GameDuration>', Interval'<Interval>')
 Then The system can sent GameRoundConfigurations to back server
 Then The system can't sent GameRoundConfigurations to back server

Examples:
	|Name	|TableAmount	|GameDuration	|Interval	|
	|Config1|5				|30				|10			|
	|		|5				|30				|10			|
	|config2|-2				|30				|10			|
	|config3|5				|0				|10			|
	|config4|5				|30				|-10		|
	|		|0				|0				|0			|