Feature: CreatePlayerAccount
	In order to create new player account
	As a back server
	I want to be create player account

Background: 
	Given (CreatePlayerAccountInfo) server has player account information as:
	|UserName	|AccountType	|
	|OhAe		|Primary		|
	|OhAe		|Secondary		|
	|Nit		|Primary		|
	|Nit		|Secondary		|

@record_mock
Scenario: (CreatePlayerAccountInfo)ผู้เล่นสมัครสมาชิกใหม่ระบบทำการสร้างบัญชีให้ผู้เล่น โดยผู้เล่นใช้บัตรเครดิตสมัครและยังไม่มีบัญชี ระบบสร้างบัญชีหลักและบัญชีรอง(บัญชีปล่าว)ให้ผู้เล่น
	Given The CreatePlayerAccountExecutor has been created and initialized
	And sent UserName: 'Top' player account information should recieved
	And the player account information should be create(UserName: 'Top', CardType:'CreditCard', AccountNo: '4513-1456-5460-1004', CVV: '4156', ExpireDate: '2010/12', FirstName: 'Sirinarin', LastName: 'Akanitthapichat') 
	When call CreatePlayerAcoountExecutor(UserName: 'Top', CardType:'CreditCard', AccountNo: '4513-1456-5460-1004', CVV: '4156', ExpireDate: '2010/12', FirstName: 'Sirinarin', LastName: 'Akanitthapichat')
	Then the result should be create

@record_mock
Scenario: (CreatePlayerAccountInfo)ผู้เล่นสมัครสมาชิกใหม่ระบบทำการสร้างบัญชีให้ผู้เล่น โดยผู้เล่นเคยสร้างบัญชีไว้แล้ว ระบบสร้างบัญชีหลักและบัญชีรอง(บัญชีปล่าว)ให้ผู้เล่น
	Given The CreatePlayerAccountExecutor has been created and initialized
	And sent UserName: 'OhAe' player account information should recieved
	When Expected exception and call CreatePlayerAcoountExecutor(UserName: 'OhAe', CardType:'CreditCard', AccountNo: '4513-1456-5460-1004', CVV: '4156', ExpireDate: '2010/12', FirstName: 'Sirinarin', LastName: 'Akanitthapichat')
	Then the result should be throw exception

@record_mock
Scenario: (CreatePlayerAccountInfo)ผู้เล่นสมัครสมาชิกใหม่ระบบทำการสร้างบัญชีให้ผู้เล่น โดยผู้เล่นใช้บัตรอื่นที่ไม่ใช่บัตรเครดิตและยังไม่มีบัญชี ระบบสร้างบัญชีหลักและบัญชีรอง(บัญชีปล่าว)ให้ผู้เล่น
	Given The CreatePlayerAccountExecutor has been created and initialized
	And sent UserName: 'Top' player account information should recieved
	When Expected exception and call CreatePlayerAcoountExecutor(UserName: 'Top', CardType:'Visa', AccountNo: '4513-1456-5460-1004', CVV: '4156', ExpireDate: '2010/12', FirstName: 'Sirinarin', LastName: 'Akanitthapichat')
	Then the result should be throw exception

@record_mock
Scenario: (CreatePlayerAccountInfo)ผู้เล่นสมัครสมาชิกใหม่ระบบทำการสร้างบัญชีให้ผู้เล่น โดยผู้เล่นใช้บัตรอื่นที่ไม่ใช่บัตรเครดิตและเคยสร้างบัญชีไว้แล้ว ระบบสร้างบัญชีหลักและบัญชีรอง(บัญชีปล่าว)ให้ผู้เล่น
	Given The CreatePlayerAccountExecutor has been created and initialized
	And sent UserName: 'OhAe' player account information should recieved
	When Expected exception and call CreatePlayerAcoountExecutor(UserName: 'OhAe', CardType:'Visa', AccountNo: '4513-1456-5460-1004', CVV: '4156', ExpireDate: '2010/12', FirstName: 'Sirinarin', LastName: 'Akanitthapichat')
	Then the result should be throw exception
