Feature: CalculateGameRoundWinner
	In order to find all winner of end round
	As a back server
	I want to be calculate reward each winner

@record_mock
Background: 
	Given (Colors_CalculateGameRoundWinner)server has player profile information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|463.61			|200			|	
	|Boy		|121.99			|321			|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|

	Given (Colors_CalculateGameRoundWinner)server has game round information as:
	|RoundID	|BlackPot	|WhitePot	|
	|1			|1526		|1263		|
	|2			|123		|456		|
	|3			|12			|74			|
	|4			|156		|123		|

	Given (Colors_CalculateGameRoundWinner)server has player action information as:
	|RoundID	|UserName	|ActionType		|BonusChips		|Chips		|Amount	|
	|1			|OhAe		|White			|3				|3			|6		|
	|1			|OhAe		|Black			|7				|0			|7		|
	|1			|Boy		|White			|351			|3			|354	|
	|1			|Boy		|Black			|0				|12			|12		|
	|1			|Au			|White			|3				|3			|6		|
	|1			|Au			|Black			|7				|0			|7		|

@record_mock
Scenario: (Colors_CalculateGameRoundWinner)ผู้เล่นได้กำไร โดยลงพนันทั้งสองสี ระบบคำนวณเงินรางวัลแล้วส่งต่อให้ระบบ Reward ทำงานต่อ
	Given The CalculateGameRoundWinnerExecutor has been created and initialized
	And (Colors_CalculateGameRoundWinner)sent name: 'OhAe' the player's balance should recieved
	And (Colors_CalculateGameRoundWinner)sent roundID: '1' the round information should recieved
	And (Colors_CalculateGameRoundWinner)sent roundID: '1' the player action information should recieved
	When (Colors_CalculateGameRoundWinner)call CalculateGameRoundWinnerExecutor(RoundID: '1')
	Then the result should be create
