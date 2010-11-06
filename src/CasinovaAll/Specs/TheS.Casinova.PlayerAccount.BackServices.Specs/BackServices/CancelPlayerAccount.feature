Feature: CancelPlayerAccount
	In order to cancel player account
	As a back server
	I want to be deactivate player account

@record_mock
Background: 
	Given (CancelPlayerAccount)server has player account information as:
	|PlayerAccountID	|UserName	|AccountType	|AccountNo		|Active		|
	|1					|OhAe		|VISA			|1234567890123	|true		|
	|2					|OhAe		|MasterCard		|3425162424231	|true		|
	|3					|OhAe		|VISA			|5341734163281	|true		|
	|4					|OhAe		|MasterCard		|3641315341710	|true		|
	|1					|Boy		|VISA			|3511527382613	|true		|
	|2					|Boy		|VISA			|3532634272917	|true		|
	|3					|Boy		|MasterCard		|3513152614332	|true		|

@record_mock
Scenario: ผู้เล่นยกเลิกบัญชีของผู้เล่นเอง ที่มีอยู่ในระบบ, ระบบยกเลิกบัญชีของผู้เล่น
	Given The CancelPlayerAccountExecutor has been created and initialized
	And sent UserName: 'OhAe', PlayerAccountID: '1' the player account number : '1234567890123' should be deactivate
	When call CancelPlayerAccountExecutor(UserName: 'OhAe', PlayerAccountID: '1')
	Then the player account information should be deactivate

@record_mock
Scenario: ผู้เล่นยกเลิกบัญชีของผู้เล่นเอง ที่มีอยู่ในระบบ, ระบบยกเลิกบัญชีของผู้เล่น2
	Given The CancelPlayerAccountExecutor has been created and initialized
	And sent UserName: 'Boy', PlayerAccountID: '3' the player account number : '3513152614332' should be deactivate
	When call CancelPlayerAccountExecutor(UserName: 'Boy', PlayerAccountID: '3')
	Then the player account information should be deactivate
