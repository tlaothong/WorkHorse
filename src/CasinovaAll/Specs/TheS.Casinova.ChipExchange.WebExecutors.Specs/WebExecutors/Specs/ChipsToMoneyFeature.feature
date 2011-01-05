Feature: ChipsToMoney
	In order to chips to money exchange
	As a system
	I want to sent ChipsToMoney information to back service

@record_mock
Scenario:[ChipsToMoney]ระบบได้รับข้อมูลครบถูกต้อง ระบบสามารถส่งข้อมูลเพื่อแลกชิพเป็นเงินไปยัง back server ได้ 
	Given The ChipsToMoneyExecutor has been created and initialized
	And   Sent UserName'Boy' Address'123/1 Khonkaen university' Amount'1000'
	When  Call ChipsToMoneyExecutor() 
	Then  The system can sent chips to money exchange information to back server 

@record_mock
Scenario:[ChipsToMoney]ระบบได้รับข้อมูล userName ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลเพื่อแลกชิพเป็นเงินไปยัง back server ได้ 
	Given The ChipsToMoneyExecutor has been created and initialized
	And   Sent UserName'' Address'123/1 Khonkaen university' Amount'1000'
	When  Call ChipsToMoneyExecutor() for validation 
	Then  The system can't sent chips to money exchange information to back server 

@record_mock
Scenario:[ChipsToMoney]ระบบได้รับข้อมูล address ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลเพื่อแลกชิพเป็นเงินไปยัง back server ได้ 
	Given The ChipsToMoneyExecutor has been created and initialized
	And   Sent UserName'Koy' Address'' Amount'1000'
	When  Call ChipsToMoneyExecutor() for validation 
	Then  The system can't sent chips to money exchange information to back server 

@record_mock
Scenario:[ChipsToMoney]ระบบได้รับข้อมูล amount ไม่ถูกต้อง ระบบไม่สามารถส่งข้อมูลเพื่อแลกชิพเป็นเงินไปยัง back server ได้ 
	Given The ChipsToMoneyExecutor has been created and initialized
	And   Sent UserName'Koy' Address'123/1 Khonkaen university' Amount'0'
	When  Call ChipsToMoneyExecutor() for validation 
	Then  The system can't sent chips to money exchange information to back server 