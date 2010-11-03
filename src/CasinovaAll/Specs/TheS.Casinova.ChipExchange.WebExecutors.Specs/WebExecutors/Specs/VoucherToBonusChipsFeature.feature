Feature: VoucherToBonusChips
	In order to voucher to BonusChips exchange
	As a system
	I want to sent voucher code to back server

@record_mock
Background:
	Given Server has voucher information as :
		|UserName	|VoucherCode						|Amount	|CanUse	|
		|Nit		|0A15D2C519764BF4B698E31B9F77FE90	| 100	|True	|
		|Ae			|16F67B16ABDF469FA42D6D3BFC380745	| 200	|false	|
		
@record_mock
Scenario: ระบบได้รับข้อมูล voucher code และ userName ครบ  ระบบตรวจสอบการใช้งาน คูปองสามารถใช้งานได้ ระบบส่งข้อมูลไป back server ได้  
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Nit' VoucherCode '0A15D2C519764BF4B698E31B9F77FE90' the player's voucher information should recieve
	When  Call VoucherToBonusChipsExecutor (UserName'Nit' VoucherCode '0A15D2C519764BF4B698E31B9F77FE90') 
	Then  The system can sent information to back server #VoucherToBonusChips

@record_mock
Scenario: ระบบได้รับข้อมูล voucher code และ userName ครบ  ระบบตรวจสอบการใช้งาน คูปองไม่สามารถใช้งานได้ ระบบส่งข้อมูลไป back server ไม่ได้  
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Ae' VoucherCode '16F67B16ABDF469FA42D6D3BFC380745' the player's voucher information should recieve
	When  Call VoucherToBonusChipsExecutor (UserName'Ae' VoucherCode '16F67B16ABDF469FA42D6D3BFC380745') 
	Then  The system can't sent information to back server #VoucherToBonusChips

@record_mock
Scenario: ระบบได้รับข้อมูล voucher code และ userName ครบ  ระบบตรวจสอบรหัสคูปอง ไม่มีข้อมูลคูปอง ระบบส่งข้อมูลไป back server ไม่ได้  
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Ae' VoucherCode 'DA60FEA34A9D42299B8C066EDC141DC5' the player's voucher information should not recieve
	When  Call VoucherToBonusChipsExecutor (UserName'Ae' VoucherCode 'DA60FEA34A9D42299B8C066EDC141DC5') 
	Then  The system can't sent information to back server #VoucherToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล voucher code ระบบส่งข้อมูลไป back server ไม่ได้_VoucherToBonusChips   
	Given The VoucherToBonusChipsExecutor has been created and initialized
	When  Call VoucherToBonusChipsExecutor (UserName'Ae' VoucherCode '') 
	Then  The system can't sent information to back server #VoucherToBonusChips

@record_mock
Scenario: ระบบไม่ได้รับข้อมูล UserName ระบบส่งข้อมูลไป back server ไม่ได้_VoucherToBonusChips  
	Given The VoucherToBonusChipsExecutor has been created and initialized
	When  Call VoucherToBonusChipsExecutor (UserName'' VoucherCode '16F67B16ABDF469FA42D6D3BFC380745') 
	Then  The system can't sent information to back server #VoucherToBonusChips