Feature: ListGamePlayAutoBetInfo
	In order to list game play auto bet information 
	As a math System
	I want to list game play auto bet information by userName



@record_mock
Scenario: ระบบได้รับข้อมูล userName ถูกต้อง และใน server มีข้อมูลการลงเดิมพันแบบอัตโนมัติไว้ #ListGamePlayAutoBetInfo
	Given The ListGamePlayAutoBetInfoExecutor has been created and initialized
	And  server has game play auto bet information as:
		|UserName|RoundID|Amount|Interval|MoneyRefund|StartTrackingID						|StopTrackingID						 |
		|Nit	 |1		 |200	|5		 |			 |083CE9EC-7459-4A5A-9771-DD3E04D192D6	|									 |
		|Nit	 |2		 |300	|10		 |	100		 |A92343C8-2484-4928-A95E-9BD3BAE17FD9	|8AF03309-CA2C-4781-9012-146003746309|
	When Call ListGamePlayAutoBetInfoExecutor
	Then The GamePlayAutoBetInformation should be as :
	    |UserName|RoundID|Amount|Interval|MoneyRefund|StartTrackingID						|StopTrackingID						 |
		|Nit	 |1		 |200	|5		 |			 |083CE9EC-7459-4A5A-9771-DD3E04D192D6	|									 |
		|Nit	 |2		 |300	|10		 |	100		 |A92343C8-2484-4928-A95E-9BD3BAE17FD9	|8AF03309-CA2C-4781-9012-146003746309|

@record_mock
Scenario: ระบบได้รับข้อมูล userName ถูกต้อง แต่ใน server ไม่มีข้อมูลการลงเดิมพันแบบอัตโนมัติไว้ #ListGamePlayAutoBetInfo
	Given The ListGamePlayAutoBetInfoExecutor has been created and initialized
	And  server has game play auto bet information as:
		|UserName	|RoundID	|Amount	|Interval	|MoneyRefund	|StartTrackingID	|StopTrackingID		|
							 
	When Call ListGamePlayAutoBetInfoExecutor	
	Then The GamePlayAutoBetInformation should be null
	   
@record_mock
Scenario: ระบบได้รับข้อมูล userName ไม่ถูกต้อง #ListGamePlayAutoBetInfo
	Given The ListGamePlayAutoBetInfoExecutor has been created and initialized
	And  server has game play auto bet information as:
		|UserName	|RoundID	|Amount	|Interval	|MoneyRefund	|StartTrackingID	|StopTrackingID		|
							 
	When Call ListGamePlayAutoBetInfoExecutor	
	Then The GamePlayAutoBetInformation should be null