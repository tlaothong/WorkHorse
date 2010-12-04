Feature: ChangePassWord
	In order to change password
	As a system
	I want to change new password

@record_mock
Scenario Outline:[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The ChangePasswordExecutor has been created and initialized
	And   Sent UserName '<UserName>' OldPassword '<OldPassWord>' NewPassword '<NewPassword>'
	When  Call ChangePasswordExecutor() for validation input
	Then  Get null and skip checking trackingID for change password

Examples:
	|UserName|OldPassWord		|NewPassword | 
	|Nit	 |1311				|538956		 |
	|Nit	 |131144			|1234		 |
	|		 |131154			|538956		 |
	|Nit	 |130055			|			 |
	|Nit	 |12345678901234567	|53895		 |
	

@record_mock
Scenario:[ChangePassword]ระบบได้รับข้อมูลรหัสผ่านใหม่จากผู้เล่น ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The ChangePasswordExecutor has been created and initialized
	And   Sent UserName 'Nayit' OldPassword '123br4' NewPassword 'nit4532'
	And   The system generated TrackingID for change password:'942D2F350FAA4A32870CF9CF9A5C7A2E'
	When  Call ChangePasswordExecutor()
	Then  TrackingID for change password should be :'942D2F350FAA4A32870CF9CF9A5C7A2E'
	