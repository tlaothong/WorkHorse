Feature: ActivatePlayerAccount
	In order to activate player account
	As a back server
	I want to be activate player account
	
@record_mock
Background: 
	Given (ActivatePlayerAccount)server has player account information as:
	|UserName	|AccountType	|CardType	|Active			|
	|OhAe		|Primary		|VISA		|false			|
	|OhAe		|Secondary		|MasterCard	|false			|
	|Boy		|Primary		|VISA		|true			|
	|Boy		|Secondary		|MasterCard	|true			|

	Given (ActivatePlayerAccount)server has user profile information as:
	|UserName	|Password	|
	|OhAe		|aaaa		|
	|Boy		|bbbb		|
	|Nittaya	|cccc		|
	|Au			|dddd		|

@record_mock
Scenario: (ActivatePlayerAccount)ผู้เล่นเปิดใช้งานบัญชีหลัก ที่ถูกยกเลิกไว้ รหัสผ่านยืนยันถูกต้อง, ระบบเปิดใช้งานบัญชีของผู้เล่น
	Given The ActivatePlayerAccount has been created and initialized
	And (ActivatePlayerAccount)sent UserName: 'OhAe', AccountType: 'Primary' the player account informaiton should recieved
	And (ActivatePlayerAccount)sent UserName: 'OhAe' player profile should recieved
	When call ActivatePlayerAccount(UserName: 'OhAe', AccountType: 'Primary', Password: 'aaaa') 
	Then the result should be create

@record_mock
Scenario: (ActivatePlayerAccount)ผู้เล่นเปิดใช้งานบัญชีรอง ที่ถูกยกเลิกไว้ รหัสผ่านยืนยันถูกต้อง, ระบบเปิดใช้งานบัญชีของผู้เล่น
	Given The ActivatePlayerAccount has been created and initialized
	And (ActivatePlayerAccount)sent UserName: 'OhAe', AccountType: 'Secondary' the player account informaiton should recieved
	And (ActivatePlayerAccount)sent UserName: 'OhAe' player profile should recieved
	When call ActivatePlayerAccount(UserName: 'OhAe', AccountType: 'Secondary', Password: 'aaaa') 
	Then the result should be create

@record_mock
Scenario: (ActivatePlayerAccount)ผู้เล่นเปิดใช้งานบัญชีหลัก ที่ถูกยกเลิกไว้ รหัสผ่านยืนยันไม่ถูกต้อง, ระบบแจ้งเตือน
	Given The ActivatePlayerAccount has been created and initialized
	And (ActivatePlayerAccount)sent UserName: 'OhAe', AccountType: 'Secondary' the player account informaiton should recieved
	And (ActivatePlayerAccount)sent UserName: 'OhAe' player profile should recieved
	When Expected exception and call ActivatePlayerAccount(UserName: 'OhAe', AccountType: 'Secondary', Password: 'XXXX') 
	Then the result should be throw exception

@record_mock
Scenario: (ActivatePlayerAccount)ผู้เล่นเปิดใช้งานบัญชีรอง เปิดใช้งานอยู่ รหัสผ่านยืนยันถูกต้อง, ระบบแจ้งเตือน
	Given The ActivatePlayerAccount has been created and initialized
	And (ActivatePlayerAccount)sent UserName: 'Boy', AccountType: 'Secondary' the player account informaiton should recieved
	And (ActivatePlayerAccount)sent UserName: 'Boy' player profile should recieved
	When Expected exception and call ActivatePlayerAccount(UserName: 'Boy', AccountType: 'Secondary', Password: 'aaaa') 
	Then the result should be throw exception
