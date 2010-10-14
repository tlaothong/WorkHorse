Feature: CreateGameRoundConfigurations
	In order to create game round configurations
	As a back server
	I want to be create game round configuraions

@record_mock
Scenario: ได้รับข้อมูล GameRoundConfigurations, ระบบบันทึกข้อมูลการตั้งค่า
	Given The CreateGameRoundConfigurationsExecutor has been created and initialized
	And Expect result should be add GameRoundConfiguration(Name: 'config1', TableAmount: '4', GameDuration: '30', Interval: '5')
	When call CreateGameRoundConfiguration(GameRoundConfiguration(Name: 'config1', TableAmount: '4', GameDuration: '30', Interval: '5'))
    Then the GameRoundConfiguration should be saved to the ICreateGameRoundConfigurations.Create(GameRoundConfiguration, CreateGameRoundConfigurationsCommand) with expected data
