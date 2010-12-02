Feature: GetPlayerAccount
	In order to get player account
	As a system
	I want to get player account

@record_mock
Background:
Given Server has player account information for get data as:
	|AccountType	|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|
	|Primary		|OhAe		|Visa		 |1802345673888921	|0253	|10/31/2010	 |True	|
	|Primary		|Boy		|Master	Card |0019342567188211	|4830	|11/30/2010  |True	|
	|Primary		|Nit		|Visa		 |0012214544543212	|3223	|12/31/2010  |True	|	

@record_mock
Scenario:[GetPlayerAccount]ผู้เล่นต้องการข้อมูลบัญชีหลัก ระบบได้รับข้อมูลถูกต้อง และใน server มีข้อมูลที่ระบบต้องการ ระบบสามารถดึงข้อมูลบัญชีของผู้เล่นได้
	Given The GetPlayerAccountExecutor has been created and initialized
	And Sent UserName 'Nit' AccountType 'Primary'
	When Call GetPlayerAccountExecutor()
	Then The result of get player account should be as : CardType 'Visa' AccountNo '0012214544543212' CVV '3223' ExpireDate '12/31/2010'
			
@record_mock
Scenario:[GetPlayerAccount]ผู้เล่นต้องการข้อมูลบัญชีสำรอง ระบบได้รับข้อมูลถูกต้อง แต่ใน server ยังไม่มีข้อมูลบัญชีสำรอง ระบบดึงข้อมูลบัญชีของผู้เล่น ไม่มีข้อมูลใดๆ
	Given The GetPlayerAccountExecutor has been created and initialized
	And Sent UserName 'Nit' AccountType 'Secondary'
	When Call GetPlayerAccountExecutor()
	Then The result of get player account should be null
			

@record_mock
Scenario:[GetPlayerAccount]ผู้เล่นต้องการข้อมูลบัญชีหลัก ระบบได้รับข้อมูล username ที่ไม่มีใน server ระบบดึงข้อมูลบัญชีของผู้เล่น ไม่มีข้อมูลใดๆ
	Given The GetPlayerAccountExecutor has been created and initialized
	And  Sent UserName 'Meaw' AccountType 'Primary'
	When Call GetPlayerAccountExecutor()
	Then The result of get player account should be null

@record_mock
Scenario:[GetPlayerAccount]ผู้เล่นต้องการข้อมูลบัญชีหลัก ระบบไม่ได้รับข้อมูล username ระบบไม่สามารถดึงข้อมูลบัญชีของผู้เล่นได้
	Given The GetPlayerAccountExecutor has been created and initialized
	And Sent UserName '' AccountType 'Primary' for validate get player account
	When Call GetPlayerAccountExecutor() for validate input
	Then The result of get player account should be throw exception

@record_mock
Scenario:[GetPlayerAccount]ผู้เล่นต้องการข้อมูลบัญชีหลัก ระบบไม่ได้รับข้อมูล accountType ระบบไม่สามารถดึงข้อมูลบัญชีของผู้เล่นได้
	Given The GetPlayerAccountExecutor has been created and initialized
	And Sent UserName 'Nit' AccountType '' for validate get player account
	When Call GetPlayerAccountExecutor() for validate input
	Then The result of get player account should be throw exception