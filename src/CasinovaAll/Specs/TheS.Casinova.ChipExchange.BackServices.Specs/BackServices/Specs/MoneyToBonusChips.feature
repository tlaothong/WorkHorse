Feature: MoneyToBonusChips
	In order to exchange money to bonus chips
	As a back server
	I want to be payment exhcange cost by credit card and given some bonus chips to player

@record_mock
Scenario: ผู้เล่นแลกเงินเป็นชิฟตาย บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนเงินมากกว่าจำนวนขั้นต่ำ, ระบบตรวจสอบบัตรเครดิตเพื่อชำระเงินและเพิ่มชิฟตายให้กับผู้เล่น
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task

Scenario: ผู้เล่นแลกเงินเป็นชิฟตาย บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนน้อยกว่าจำนวนขั้นต่ำ, ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task

Scenario: ผู้เล่นแลกเงินเป็นชิฟตาย บัตรเครดิตของผู้เล่นไม่ถูกต้อง ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToBonusChipsExecutor has been created and initialized
	When Pending for next task
	Then Pending for next task
