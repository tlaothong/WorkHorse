Feature: CancelPlayerAccount
	In order to cancel player account
	As a back server
	I want to be deactivate player account

@record_mock
Background: 
	Given (CancelPlayerAccount)server has player account information as:
	|UserName	|AccountType	|CardType	|Active			|
	|OhAe		|Primary		|VISA		|true			|
	|OhAe		|Secondary		|MasterCard	|true			|
	|Boy		|Primary		|VISA		|true			|
	|Boy		|Secondary		|MasterCard	|false			|

	Given (CancelPlayerAccount)server has user profile information as:
	|UserName	|Password	|
	|OhAe		|aaaa		|
	|Boy		|bbbb		|
	|Nittaya	|cccc		|
	|Au			|dddd		|


@record_mock
Scenario: (CancelPlayerAccount)ผู้เล่นยกเลิกบัญชีหลัก ที่เปิดใช้งานไว้ รหัสผ่านยืนยันถูกต้อง, ระบบยกเลิกบัญชีของผู้เล่น
	Given The CancelPlayerAccountExecutor has been created and initialized
	And sent UserName: 'OhAe', AccountType: 'Primary' the player account informaiton should recieved
	And (CancelPlayerAccount)sent UserName: 'OhAe' player profile should recieved
	And the player account information should be create(UserName: 'OhAe', AccountType: 'Primary') 
	When call CancelPlayerAccountExecutor(UserName: 'OhAe', AccountType: 'Primary', Password: 'aaaa') 
	Then the result should be create

@record_mock
Scenario: (CancelPlayerAccount)ผู้เล่นยกเลิกบัญชีรอง ที่เปิดใช้งานไว้ รหัสผ่านยืนยันถูกต้อง, ระบบยกเลิกบัญชีของผู้เล่น
	Given The CancelPlayerAccountExecutor has been created and initialized
	And sent UserName: 'OhAe', AccountType: 'Secondary' the player account informaiton should recieved
	And (CancelPlayerAccount)sent UserName: 'OhAe' player profile should recieved
	And the player account information should be create(UserName: 'OhAe', AccountType: 'Secondary') 
	When call CancelPlayerAccountExecutor(UserName: 'OhAe', AccountType: 'Secondary', Password: 'aaaa') 
	Then the result should be create

@record_mock
Scenario: (CancelPlayerAccount)ผู้เล่นยกเลิกบัญชีหลัก ที่เปิดใช้งานไว้ รหัสผ่านยืนยันไม่ถูกต้อง, ระบบแจ้งเตือน
	Given The CancelPlayerAccountExecutor has been created and initialized
	And sent UserName: 'OhAe', AccountType: 'Primary' the player account informaiton should recieved
	And (CancelPlayerAccount)sent UserName: 'OhAe' player profile should recieved
	When Expected exception and call CancelPlayerAccountExecutor(UserName: 'OhAe', AccountType: 'Primary', Password: 'xxxx') 
	Then the result should be throw exception


@record_mock
Scenario: (CancelPlayerAccount)ผู้เล่นยกเลิกบัญชีรอง ที่ไม่เปิดใช้งานไว้ รหัสผ่านยืนยันถูกต้อง, ระบบแจ้งเตือน
	Given The CancelPlayerAccountExecutor has been created and initialized
	And sent UserName: 'Boy', AccountType: 'Secondary' the player account informaiton should recieved
	And (CancelPlayerAccount)sent UserName: 'OhAe' player profile should recieved
	When Expected exception and call CancelPlayerAccountExecutor(UserName: 'OhAe', AccountType: 'Primary', Password: 'xxxx') 
	Then the result should be throw exception
