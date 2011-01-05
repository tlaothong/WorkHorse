Feature: ChipsToBonusChips
	In order to chips to bonus chips exchange
	As a system
	I want to sent chips to bonus chips exchange information

@record_mock
Background:
Given Server has user profile information for chips to bonus chips:
		|UserName	|Refundable	 |NonRefundable|
		|OhAe		|500		 |200		   |
		|Boy		|4500		 |500		   |
		|Nit		|300		 |589		   |

And Server has bonus points information for chips to bonus chips exchange:
		|UserName	|Bonus	|
		|Nit		|500	|
		|Ae			|900	|
		|Boy		|1000	|

@record_mock
Scenario:[ChipsToBonusChips] ระบบได้รับข้อมูลการแลกชิพเป็นเป็นชิพตายถูกต้อง ระบบทำการตรวจสอบจำนวนโบนัสมีเพียงพอ ระบบทำการตรวจสอบจำนวนชิพเป็นมีเพียงพอ ระบบสามารถส่งข้อมูลไปยัง back server ได้
	Given The ChipsToBonusChipsExecutor has been created and initialized
	And Sent UserName'Boy' Amount '1000' for chips to bonus chips exchange
	And Sent UserName'Boy' the player's bonus points for chips to bonus chips exchange should recieved
	And Sent UserName'Boy' the player's profile for chips to bonus chips exchange should recieved
	When Call ChipsToBonusChipsExecutor() 
	Then The system can sent chips to bonus chips exchange information to back server
