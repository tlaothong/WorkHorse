Feature: RegisterUser
	In order to register user
	As a system
	I want to register user profile

@record_mock
Scenario Outline: ระบบได้รับข้อมูลการ register ของผู้เล่น ระบบตรวจสอบข้อมูล และทำการส่งข้อมูลไปยัง back server ต่อไป
	Given The RegisterUserExecutor has been created and initialized
	And  Server has UserName information as:
		|UserName	|Password	|Email					|CellPhone	 | Upline |Refundable|NonRefundable|Active|
		|Boy		|5843		|pongsak@gmail.com		|0862202260  |Nit	  |4500		 |500		   |True  |
		|Nit		|1311		|nayit_nit@hotmail.com	|0892131356  |	      |1000		 |589		   |True  |

	And Sent UserName '<UserName>' Password'<Password>' Email'<Email>' CellPhone'<CellPhone>' Upline'<Upline>'
	When Call RegisterUserExecutor
	Then The server can sent RegisterUser information
	Then The server can't sent RegisterUser information

	Examples:
	|UserName	|Password	|Email					|CellPhone	 | Upline |
	|OhAe		|1234		|sirinarin@hotmail.com	|0892165437	 |Nit	  |
	|#$@!		|1234		|sirinarin@hotmail.com	|0892165437	 |Nit	  |
	|OhAe		|#@$%^		|sirinarin@hotmail.com	|0892165437	 |Nit	  |
	|OhAe		|1234		|sirinarin				|0892165437	 |Nit	  |
	|OhAe		|1234		|sirinarin@hotmail.com	|##########	 |Nit	  |
	|OhAe		|1234		|sirinarin@hotmail.com	|0892165437	 |Tummy   |
	|Nit		|1234		|sirinarin@hotmail.com	|0892165437	 |Nit	  |
	|OhAe		|1234		|nayit_nit@hotmail.com	|0892165437	 |Nit	  |
