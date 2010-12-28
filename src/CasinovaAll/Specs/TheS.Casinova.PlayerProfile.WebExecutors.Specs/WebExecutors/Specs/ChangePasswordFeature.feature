Feature: ChangePassWord
	In order to change password
	As a system
	I want to change new password

@record_mock
Scenario Outline:[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่สามารถเปลี่ยน password ใหม่ได้
	Given The ChangePasswordExecutor has been created and initialized
	And   Sent UserName '<UserName>' OldPassword '<OldPassWord>' NewPassword '<NewPassword>'
	When  Call ChangePasswordExecutor() for validation input
	Then  Skip call membership service to change new password

Examples:
	|UserName|OldPassWord		|NewPassword | 
	|Nit	 |1311				|538956		 |
	|Nit	 |131144			|1234		 |
	|		 |131154			|538956		 |
	|Nit	 |130055			|			 |
	|Nit	 |12345678901234567	|53895		 |
	

@record_mock
Scenario:[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบสามารถเปลี่ยน password ใหม่ได้
	Given The ChangePasswordExecutor has been created and initialized
	And   Sent UserName 'Nayit' OldPassword '123br4' NewPassword 'nit4532'
	And   Call membership service to validate change password information : UserName 'Nayit' OldPassword '123br4' NewPassword 'nit4532'
	When  Call ChangePasswordExecutor()
	Then  Membership service can change new password 
	