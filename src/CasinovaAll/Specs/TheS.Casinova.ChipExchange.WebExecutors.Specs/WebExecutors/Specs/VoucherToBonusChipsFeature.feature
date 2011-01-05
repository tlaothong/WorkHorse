Feature: VoucherToBonusChips
	In order to voucher to BonusChips exchange
	As a system
	I want to sent voucher code to BonusChips exchange
		
@record_mock
Scenario:[VoucherToBonusChips]ระบบได้รับข้อมูล voucher code และ userName ระบบทำการตรวจสอบข้อมูล ข้อมูล voucher code ถูกต้อง ระบบสามารถ generate trackingID ได้  
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Nit' VoucherCode '448021228C7A10D3'
	And   The system generated TrackingID for VoucherToBonusChips:'942D2F350FAA4A32870CF9CF9A5C7A2E'
	When  Call VoucherToBonusChipsExecutor() 
	Then  TrackingID for VoucherToBonusChips should be :'942D2F350FAA4A32870CF9CF9A5C7A2E'


@record_mock
Scenario:[VoucherToBonusChips]ระบบได้รับข้อมูล voucher code และ userName ระบบทำการตรวจสอบข้อมูล ข้อมูล voucher code ไม่ถูกต้อง ระบบไม่สามารถ generate trackingID ได้
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Nit' VoucherCode '448065728C7A10D3'
	When  Call VoucherToBonusChipsExecutor() for validate input
	Then  VoucherToBonusChips get null and skip checking trackingID

@record_mock
Scenario:[VoucherToBonusChips]ระบบได้รับข้อมูล voucher code และ userName ระบบทำการตรวจสอบข้อมูล ข้อมูล voucher code มีจำนวนไม่ถูกต้อง ระบบไม่สามารถ generate trackingID ได้
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Nit' VoucherCode '448065728C7A'
	When  Call VoucherToBonusChipsExecutor() for validate input
	Then  VoucherToBonusChips get null and skip checking trackingID

@record_mock
Scenario:[VoucherToBonusChips]ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถ generate trackingID ได้
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'' VoucherCode '448021228C7A10D3'
	When  Call VoucherToBonusChipsExecutor() for validate input
	Then  VoucherToBonusChips get null and skip checking trackingID

@record_mock
Scenario:[VoucherToBonusChips]ระบบไม่ได้รับข้อมูล voucher code ระบบไม่สามารถ generate trackingID ได้
	Given The VoucherToBonusChipsExecutor has been created and initialized
	And   Sent UserName'Nit' VoucherCode ''
	When  Call VoucherToBonusChipsExecutor() for validate input
	Then  VoucherToBonusChips get null and skip checking trackingID

