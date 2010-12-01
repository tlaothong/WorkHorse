Feature: ListPlayerAccount
	In order to list player account
	As a system
	I want to list player account

@record_mock
Background:
Given Server has player account information as:
	|AccountType	|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|
	|Primary		|OhAe		|Visa		 |1802345673888921	|0253	|10/31/2011	 |True	|
	|Primary		|Boy		|Master	Card |0019342567188211	|4830	|11/30/2011  |True	|
	|Primary		|Nit		|Visa		 |0012214544543212	|3223	|12/31/2011  |True	|	

@record_mock
Scenario:[ListPlayerAccount]ระบบได้รับข้อมูล username ถูกต้อง ระบบสามารถดึงข้อมูลบัญชีทั้งหมดของผู้เล่นได้ 
	Given The ListPlayerAccountExecutor has been created and initialized
	And  Sent UserName 'Nit' for list player account 
	When Call ListPlayerAccountExecutor()
	Then The result of player account should be as:
	|AccountType	|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|
	|Primary		|Nit		|Visa	      |0012214544543212		|3223	|12/31/2011  |True	|

@record_mock
Scenario:[ListPlayerAccount]ระบบได้รับข้อมูล username ที่ไม่มีใน server ระบบไม่สามารถดึงข้อมูลบัญชีทั้งหมดของผู้เล่นได้ 
	Given The ListPlayerAccountExecutor has been created and initialized
	And  Sent UserName 'Meaw' for list player account
	When Call ListPlayerAccountExecutor()
	Then The result of player account should be as:
	|AccountType	|UserName	|CardType	 |AccountNo			|CVV	| ExpireDate |Active|

@record_mock
Scenario:[ListPlayerAccount]ระบบไม่ได้รับข้อมูล username ระบบไม่สามารถดึงข้อมูลบัญชีทั้งหมดของผู้เล่นได้ 
	Given The ListPlayerAccountExecutor has been created and initialized
	And Sent UserName '' for validate list player account information
	When Call ListPlayerAccountExecutor() for validate input
	Then The result of player account should be throw exception