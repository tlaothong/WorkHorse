Feature: GetPlayerAccount
	In order to get player account
	As a system
	I want to get player account

@record_mock
Background:
Given Server has player account information as:
	|PlayerAccountID|UserName	|AccountType |AccountNo			|CVV	| ExpireDate |Active|
	|001			|OhAe		|Visa		 |1802345673888921	|0253	|10/31/2010	 |True	|
	|002			|Boy		|Master	Card |0019342567188211	|4830	|11/30/2010  |True	|
	|003			|Nit		|Visa		 |0012214544543212	|3223	|12/31/2010  |True	|

@record_mock
Scenario: ระบบได้รับข้อมูล username ถูกต้อง ระบบสามารถดึงข้อมูลบัญชีของผู้เล่นได้ # GetPlayerAccount 
	Given The GetPlayerAccountExecutor has been created and initialized
	And Sent UserName 'Nit' 
	When Call GetPlayerAccountExecutor
	Then The result of get player account should be as : AccountType 'Visa' AccountNo '0012214544543212' CVV '3223' ExpireDate '12/31/2010 ' Active 'true'
			

@record_mock
Scenario: ระบบได้รับข้อมูล username ที่ไม่มีใน server ระบบไม่สามารถดึงข้อมูลบัญชีของผู้เล่นได้ # GetPlayerAccount 
	Given The GetPlayerAccountExecutor has been created and initialized
	And Sent UserName 'Meaw' 
	When Call GetPlayerAccountExecutor
	Then The result of get player account should be null

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล username ระบบไม่สามารถดึงข้อมูลบัญชีของผู้เล่นได้ # GetPlayerAccount 
	Given The GetPlayerAccountExecutor has been created and initialized
	And Sent UserName '' 
	When Call GetPlayerAccountExecutor
	Then The result of get player account should be null