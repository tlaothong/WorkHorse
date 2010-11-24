Feature: MoneyToChips
	In order to exchange money to chips
	As a back server
	I want to be payment exhcange cost by credit card and given some chips to player

@record_mock
Scenario: ผู้เล่นแลกเงินเป็นชิฟเป็น บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนเงินมากกว่าจำนวนขั้นต่ำ, ระบบตรวจสอบบัตรเครดิตเพื่อชำระเงินและเพิ่มชิฟเป็นให้กับผู้เล่น
	Given The MoneyToChipsExecutor has been created and initialized

Scenario: ผู้เล่นแลกเงินเป็นชิฟเป็น บัตรเครดิตของผู้เล่นถูกต้อง ระบุจำนวนน้อยกว่าจำนวนขั้นต่ำ, ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToChipsExecutor has been created and initialized

Scenario: ผู้เล่นแลกเงินเป็นชิฟเป็น บัตรเครดิตของผู้เล่นไม่ถูกต้อง ระบบไม่อนุญาติให้แลกเงิน
	Given The MoneyToChipsExecutor has been created and initialized
  



