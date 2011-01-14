Feature: ListGamePlayAutoBetInfo
	In order to ให้ผู้เล่นทราบจำนวนเงินทั้งหมดที่ได้ลงเดิมพันแบบ auto bet ยังไม่เสร็จที่โต๊ะเกมนั้น ๆ
	As a User
	I want ดึงข้อมูลการลงเดิมพันแบบ auto bet



@record_mock
Scenario: [ListGamePlayAutoBet]ระบบได้รับข้อมูล userName ถูกต้อง และใน server มีข้อมูลการลงเดิมพันแบบอัตโนมัติไว้ ระบบสามารถดึงข้อมูลการลงเดิมพันแบบอัตโนมัติได้
	Given The ListGamePlayAutoBetInfoExecutor has been created and initialized
	And   Server has game play auto bet information as:
		 |UserName|RoundID	 |Amount|Interval|MoneyRefund|BetTrackingID							|ThruDateTime	|
		 |Nit	  |1		 |200	|5		 |	0		 |083CE9EC-7459-4A5A-9771-DD3E04D192D6	|00:00			|
		 |Nit	  |2		 |300	|10		 |	100		 |A92343C8-2484-4928-A95E-9BD3BAE17FD9	|12:00			|
		 |OhAe	  |1		 |200	|2		 |  0		 |DBAF58AD-EDB0-4BB8-AC8B-C783D23E73FC	|00:00			|
	And  Sent UserName 'Nit' 
	When Call ListGamePlayAutoBetInfoExecutor()
	Then The game play auto bet information should be as :
	     |UserName|RoundID	 |Amount|Interval|MoneyRefund|BetTrackingID							|ThruDateTime	|
		 |Nit	  |1		 |200	|5		 |	0		 |083CE9EC-7459-4A5A-9771-DD3E04D192D6	|00:00			|
		 |Nit	  |2		 |300	|10		 |	100		 |A92343C8-2484-4928-A95E-9BD3BAE17FD9	|12:00			|

@record_mock
Scenario: [ListGamePlayAutoBet]ระบบได้รับข้อมูล userName ถูกต้อง แต่ใน server ไม่มีข้อมูลการลงเดิมพันแบบอัตโนมัติไว้ ได้ข้อมูลการลงเดิมพันแบบอัตโนมัติเป็น null
	Given The ListGamePlayAutoBetInfoExecutor has been created and initialized
	And   Server has game play auto bet information as:
		 |UserName|RoundID	 |Amount|Interval|MoneyRefund|BetTrackingID							|ThruDateTime	|
		 |Nit	  |1		 |200	|5		 |	0		 |083CE9EC-7459-4A5A-9771-DD3E04D192D6	|00:00			|
		 |Nit	  |2		 |300	|10		 |	100		 |A92343C8-2484-4928-A95E-9BD3BAE17FD9	|12:00			|
		 |OhAe	  |1		 |200	|2		 |  0		 |DBAF58AD-EDB0-4BB8-AC8B-C783D23E73FC	|00:00			|
	And  Sent UserName 'Gogo'						 
	When Call ListGamePlayAutoBetInfoExecutor()	
	Then The game play auto bet information should be as :
		 |UserName|RoundID	 |Amount|Interval|MoneyRefund|BetTrackingID							|ThruDateTime	|
	   
@record_mock
Scenario: [ListGamePlayAutoBet]ระบบไม่ได้รับข้อมูล userName ระบบไม่สามารถลิสต์ข้อมูลการลงเดิมพันแบบอัตโนมัติได้
	Given The ListGamePlayAutoBetInfoExecutor has been created and initialized
	And   Sent UserName '' for validation					 
	When  Call ListGamePlayAutoBetInfoExecutor() for validate input	
	Then  The game play auto bet information should be throw exception