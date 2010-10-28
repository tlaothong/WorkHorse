Feature: GetUserProfile
	In order to get user profile
	As a system
	I want to get profile of player by userName

@record_mock
Background:
Given Server has user profile information as:
|UserName	|Password	|Email					|CellPhone	 | Upline |Refundable|NonRefundable|Active|
|OhAe		|1234		|sirinarin@hotmail.com	|0892165437	 |Nit	  |500		 |200		   |True  |
|Boy		|5843		|pongsak@gmail.com		|0862202260  |Nit	  |4500		 |500		   |True  |
|Nit		|1311		|nayit_nit@hotmail.com	|0892131356  |	      |1000		 |589		   |True  |

@record_mock
Scenario: ระบบได้รับข้อมูล username ถูกต้อง ระบบสามารถดึงข้อมูล user profile ของผู้เล่นได้
	Given The GetUserProfileExecutor has been created and initialized
	And   Sent UserName: 'OhAe'
	When  Call GetUserProfileExecutor
	Then User Profile information should be UserName 'OhAe' Password '1234' Email 'sirinarin@hotmail.com' CellPhone '0892165437' Upline 'Nit'Refundable '500' NonRefundable '200' Active 'True'
	

@record_mock
Scenario: ระบบได้รับข้อมูล username ไม่ถูกต้อง ระบบไม่สามารถดึงข้อมูล user profile ของผู้เล่นได้
	Given The GetUserProfileExecutor has been created and initialized
	And   Sent UserName: ''
	When  Call GetUserProfileExecutor
	Then User Profile information should be null
