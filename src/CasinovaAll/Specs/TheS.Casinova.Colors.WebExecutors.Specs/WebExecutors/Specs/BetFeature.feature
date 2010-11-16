Feature: Bet
	In order to bet colors game
	As a system
	I want to sent bet information to back server

@record_mock
Scenario Outline: ระบบได้รับข้อมูลการลงเดิมพันเกมใน colors ของผู้เล่น ระบบทำการตรวจสอบข้อมูล เพื่อทำการ generete trackingID และส่งข้อมูลไปยัง bck server ต่อไป
	Given The BetColorsExecutor has been created and initialized
	When  Call BetColorsExecutor(UserName '<UserName>' RoundID '<RoundID>', ActionType '<ActionType>', Amount '<Amount>') 
	Then  The system can generate trckingID for bet colors game 
	Then  The system can't generate trackingID for bet colors game

	Examples:
	|UserName	|RoundID	|ActionType	|Amount	|
	|Nit	 	|4			| White		|50		|
	|Nit	 	|4			| White		|-50	|
	|Nit	 	|4			|			|50		|
	|Nit	 	|-2			| White		|50		|
	|		 	|4			| White		|50		|
