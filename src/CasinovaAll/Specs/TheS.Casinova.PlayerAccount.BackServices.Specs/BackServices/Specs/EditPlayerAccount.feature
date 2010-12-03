Feature: EditPlayerAccount
	In order to edit account information
	As a back server
	I want to be update player account information

Background: 
	Given (EditPlayerAccount) server has player account information as:
	|UserName	|AccountType	|Active	|
	|OhAe		|Primary		|True	|
	|OhAe		|Secondary		|True	|
	|Nit		|Primary		|False	|
	|Nit		|Secondary		|False	|

@record_mock
Scenario: (EditPlayerAccount)ผู้เล่นแก้ไขข้อมูลบัญชีหลัก โดยใช้บัตรเครดิตและบัญชีเปิดใช้งานอยู่ ระบบบันทึกข้อมูลบัญชีที่แก้ไข
	Given The EditPlayerAccountExecutor has been created and initialized
	And (EditPlayerAccount)sent UserName: 'OhAe' player account information should recieved
	And the player account information should be update(UserName: 'OhAe', AccountType: 'Primary', AccountNo: '5136-2468-3246-3216', CardType: 'CreditCard', ExpireDate: '2011/12', FirstName: 'Siriwasan', LastName: 'Akanitthapichat')
	When call EditPlayerAccountExecutor(UserName: 'OhAe', AccountType: 'Primary', AccountNo: '5136-2468-3246-3216', CardType: 'CreditCard', ExpireDate: '2011/12', FirstName: 'Siriwasan', LastName: 'Akanitthapichat')
	Then the result should be create

@record_mock
Scenario: (EditPlayerAccount)ผู้เล่นแก้ไขข้อมูลบัญชีรอง โดยใช้บัตรเครดิตและบัญชีเปิดใช้งานอยู่ ระบบบันทึกข้อมูลบัญชีที่แก้ไข
	Given The EditPlayerAccountExecutor has been created and initialized
	And (EditPlayerAccount)sent UserName: 'OhAe' player account information should recieved
	And the player account information should be update(UserName: 'OhAe', AccountType: 'Secondary', AccountNo: '6598-2068-5680-3216', CardType: 'Visa', ExpireDate: '2011/06', FirstName: 'Wanida', LastName: 'Toommy')
	When call EditPlayerAccountExecutor(UserName: 'OhAe', AccountType: 'Secondary', AccountNo: '6598-2068-5680-3216', CardType: 'Visa', ExpireDate: '2011/06', FirstName: 'Wanida', LastName: 'Toommy')
	Then the result should be create

@record_mock
Scenario: (EditPlayerAccount)ผู้เล่นแก้ไขข้อมูลบัญชีหลัก โดยผู้เล่นใช้บัตรอื่นที่ไม่ใช่บัตรเครดิตและบัญชีเปิดใช้งานอยู่ ระบบแจ้งเตือนผู้เล่น
	Given The EditPlayerAccountExecutor has been created and initialized
	And (EditPlayerAccount)sent UserName: 'OhAe' player account information should recieved
	When Expected exception and call EditPlayerAccountExecutor(UserName: 'OhAe', AccountType: 'Primary', AccountNo: '6598-2068-5680-3216', CardType: 'Visa', ExpireDate: '2011/06', FirstName: 'Wanida', LastName: 'Toommy')
	Then the result should be throw exception

@record_mock
Scenario: (EditPlayerAccount)ผู้เล่นแก้ไขข้อมูลบัญชีหลัก โดยใช้บัตรเครดิตและบัญชีถูกปิดการใช้งานอยู่ ระบบแจ้งเตือนผู้เล่น
	Given The EditPlayerAccountExecutor has been created and initialized
	And (EditPlayerAccount)sent UserName: 'Nit' player account information should recieved
	When Expected exception and call EditPlayerAccountExecutor(UserName: 'Nit', AccountType: 'Primary', AccountNo: '6598-2068-5680-3216', CardType: 'Visa', ExpireDate: '2011/06', FirstName: 'Wanida', LastName: 'Toommy')
	Then the result should be throw exception
