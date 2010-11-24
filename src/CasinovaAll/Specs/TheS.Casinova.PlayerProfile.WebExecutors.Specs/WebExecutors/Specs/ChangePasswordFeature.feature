Feature: ChangePassWord
	In order to change password
	As a system
	I want to change new password

@record_mock
Scenario Outline: ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล และ update ข้อมูลต่อไป
	Given The ChangePasswordExecutor has been created and initializedr
	And  Server has password information of Nit :
		|UserName	|Password	|
		|Nit		|1311	    |

	And Sent UserName '<UserName>' OldPassword '<OldPassWord>' NewPassword '<NewPassWord>'
	When Call ChangePasswordExecutor
	Then The system can update new password
	Then The system can't update new password

Examples:
	|UserName|OldPassWord	|NewPassword | 
	|Nit	 |1311			|5389		 |
	|Nit	 |1311			|d#$$		 |
	|Nit	 |1311			|			 |
	|Nit	 |1300			|5389		 |
	|Nit	 |$%#@			|5389		 |
	|		 |1311			|5389		 |
	|Nit	 |				|5389		 |
	