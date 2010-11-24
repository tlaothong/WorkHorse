Feature: VoucherToBonusChips
	In order to exchange voucher to bonus chips
	As a back server
	I want to be given some bonus chips to player and update used voucher

@record_mock
Scenario: ผู้เล่นแลกคูปองเป็นชิฟตาย มีคูปองตามรหัสที่ระบุและคูปองยังไม่ถูกใช้งาน, ระบบตรวจสอบคูปองและเพิ่มชิฟตายให้กับผู้เล่น
	Given The VoucherToBounusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task

Scenario: ผู้เล่นแลกคูปองเป็นชิฟตาย มีคูปองตามรหัสที่ระบุและคูปองถูกใช้งานแล้ว, ระบบตรวจสอบคูปองและแจ้งเตือน
	Given The VoucherToBounusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task

Scenario: ผู้เล่นแลกคูปองเป็นชิฟตาย ไม่มีคูปองตามรหัสที่ระบุ, ระบบตรวจสอบคูปองและแจ้งเตือน
	Given The VoucherToBounusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task
