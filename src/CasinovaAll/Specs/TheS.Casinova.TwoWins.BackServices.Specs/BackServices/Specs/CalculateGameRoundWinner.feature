Feature: CalculateGameRoundWinner
	In order to calculate winners
	As a back server
	I want to be update game round winner information

@record_mock
Background: Twowins_CalculateGameRoundWinner
	Given (Twowins_CalculateGameRoundWinner)server has game round winner information as:
	|RoundID |WinnerHiNorAmount	|WinnerHiNorCount |WinnerLoNorAmount |WinnerLoNorCount |WinnerHiCriAmount |WinnerHiCriCount |WinnerLoCriAmount |WinnerLoCriCount |
	|1		 |-1				|1				  |-1				 |1				   |-1				  |1			    |-1				   |1				 |
	|2		 |10				|1				  |3				 |1				   |10				  |1			    |3				   |1				 |

	And (Twowins_CalculateGameRoundWinner)server has bet information as:
	|HandID	|RoundID	|UserName	|Amount	|HandStatus	|CanChange	|
	|1562	|1			|OhAe		|12		|Normal		|true		|
	|1542	|1			|OhAe		|17		|Normal		|true		|
	|1549	|1			|OhAe		|7		|Normal		|true		|
	|1604	|1			|OhAe		|20		|Normal		|true		|
	|1611	|1			|OhAe		|25		|Normal		|true		|
	|1662	|1			|Boy		|23		|Normal		|true		|
	|1642	|1			|Boy		|17		|Normal		|true		|
	|1649	|1			|Boy		|7		|Normal		|true		|
	|1704	|1			|Boy		|2		|Normal		|true		|
	|1711	|1			|Boy		|28		|Normal		|true		|
	|1562	|2			|OhAe		|3		|Normal		|true		|
	|1542	|2			|OhAe		|10		|Normal		|true		|
	|1549	|2			|OhAe		|7		|Normal		|true		|
	|1604	|2			|OhAe		|2		|Normal		|true		|
	|1611	|2			|OhAe		|25		|Normal		|true		|
	|1662	|2			|Boy		|23		|Normal		|true		|
	|1642	|2			|Boy		|17		|Normal		|true		|
	|1649	|2			|Boy		|7		|Normal		|true		|
	|1704	|2			|Boy		|2		|Normal		|true		|
	|1711	|2			|Boy		|28		|Normal		|true		|
	
	And (Twowins_CalculateGameRoundWinner)server has round information as:
	|RoundID	|FromDateTime	|ThruDateTime	|CriticalTime	|Pot		|
	|1			|-20			|30				|25				|759.00		|
	|2			|-5				|5				|-3				|5266.00	|
	|3			|10				|20				|15				|15648.00	|

@record_mock
Scenario: (Twowins_CalculateGameRoundWinner)ระบบคำนวณหาผู้ชนะ โดยโต๊ะเกมยังไม่มีผู้ชนะ และได้ผู้ชนะทั้งสี่ ระบบคำนวณหาผู้ชนะทั้งหมดและบันทึกข้อมูล
	Given (Twowins_CalculateGameRoundWinner)The CalculateGameRoundWinnerExecutor has been created and initialized
	And (Twowins_CalculateGameRoundWinner)sent RoundID: '1' the bet information should recieved
	And (Twowins_CalculateGameRoundWinner)sent RoundID: '1' the round winner information should recieved
	And (Twowins_CalculateGameRoundWinner)sent roundID: '1' the round information should recieved
	And (Twowins_CalculateGameRoundWinner)the round winner information should be update (RoundID ='1', WinnerHiNorAmount ='28', WinnerHiNorCount ='1', WinnerLoNorAmount ='2', WinnerLoNorCount ='1', WinnerHiCriAmount ='28', WinnerHiCriCount ='1', WinnerLoCriAmount ='2', WinnerLoCriCount ='1')
	When (Twowins_CalculateGameRoundWinner)call CalculateGameRoundWinnerExecutor(RoundID: '1')
	Then the result should be create

@record_mock
Scenario: (Twowins_CalculateGameRoundWinner)ระบบคำนวณหาผู้ชนะ โดยโต๊ะเกมมีผู้ชนะแล้ว และได้ผู้ชนะสูงสุดช่วงปกติและช่วงวิกฤตใหม่ ระบบคำนวณหาผู้ชนะทั้งหมดและบันทึกข้อมูล
	Given (Twowins_CalculateGameRoundWinner)The CalculateGameRoundWinnerExecutor has been created and initialized
	And (Twowins_CalculateGameRoundWinner)sent RoundID: '2' the bet information should recieved
	And (Twowins_CalculateGameRoundWinner)sent RoundID: '2' the round winner information should recieved
	And (Twowins_CalculateGameRoundWinner)sent roundID: '2' the round information should recieved
	And (Twowins_CalculateGameRoundWinner)the round winner information should be update (RoundID ='2', WinnerHiNorAmount ='28', WinnerHiNorCount ='1', WinnerLoNorAmount ='3', WinnerLoNorCount ='1', WinnerHiCriAmount ='28', WinnerHiCriCount ='1', WinnerLoCriAmount ='3', WinnerLoCriCount ='1')
	When (Twowins_CalculateGameRoundWinner)call CalculateGameRoundWinnerExecutor(RoundID: '2')
	Then the result should be create

@record_mock
Scenario: (Twowins_CalculateGameRoundWinner)ระบบคำนวณหาผู้ชนะ โดยโต๊ะเกมยังไม่ได้เริ่มเล่น ระบบแจ้งเตือน
	Given (Twowins_CalculateGameRoundWinner)The CalculateGameRoundWinnerExecutor has been created and initialized
	And (Twowins_CalculateGameRoundWinner)sent RoundID: '3' the bet information should recieved
	And (Twowins_CalculateGameRoundWinner)sent RoundID: '3' the round winner information should recieved
	And (Twowins_CalculateGameRoundWinner)sent roundID: '3' the round information should recieved
	When (Twowins_CalculateGameRoundWinner)Expected exception and call CalculateGameRoundWinnerExecutor(RoundID: '3')
	Then the result should be throw exception

