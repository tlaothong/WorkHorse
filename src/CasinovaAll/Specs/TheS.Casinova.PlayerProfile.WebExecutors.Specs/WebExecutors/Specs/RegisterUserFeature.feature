Feature: RegisterUser
	In order to register user
	As a system
	I want to register user information to profile

@record_mock
Scenario Outline:[RegisterUser]ระบบได้รับข้อมูลการ register ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The RegisterUserExecutor has been created and initialized
	And  Sent register user information : UserName '<UserName>' Password'<Password>' Email'<Email>' CellPhone'<CellPhone>' Upline'<Upline>'
	When Call RegisterUserExecutor() for validate register user input
	Then Get null and skip checking trackingID for register user

	Examples:
	|UserName	|Password			|Email					|CellPhone	 | Upline |
	|			|123456				|sirinarin@hotmail.com	|0892165437	 |Nit	  |
	|OhAe		|1234				|sirinarin@hotmail.com	|0892165437	 |		  |
	|OhAe		|12345678901234567	|sirinarin@hotmail.com	|0892165437	 |		  |
	|OhAe		|123456				|						|0892165437	 |Nit	  |
	|OhAe		|123456				|sirinarin@hotmail.com	|			 |Nit	  |
	|ohAe		|123456				|sirinarin.com			|0892165437	 |Nit	  |

@record_mock
Scenario:[RegisterUser]ระบบได้รับข้อมูลการ register ของผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The RegisterUserExecutor has been created and initialized
	And   Sent register user information : UserName 'Nit' Password'123456' Email'nayit_n@hotmail.com' CellPhone'0892131356' Upline'boy'
	And   Call membership service to validate register user information : UserName 'Nit' Password'123456' Email'nayit_n@hotmail.com' CellPhone'0892131356' Upline'boy'
	And   The system generated TrackingID for register user:'942D2F350FAA4A32870CF9CF9A5C7A2E'
	When  Call RegisterUserExecutor() 
	Then  TrackingID for register user should be :'942D2F350FAA4A32870CF9CF9A5C7A2E'
	
