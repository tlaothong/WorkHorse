Feature:ListPlayerActionInfoToPayForColorsWinnerInfo
	In order to list player action information
	As a back server
	I want to be checking that player ever pay for winner on this round

@record_mock
Background:
Given server has player action information as:
|RoundID	|UserName	|ActionType	|DateTime(for example not use this row)			|
|12			|OhAe		|GetWinner	|2553/3/12 10:00	|
|12			|Boy		|GetWinner	|2553/3/12 11:20	|
|12			|OhAe		|Black		|2553/3/12 11:22	|
|12			|OhAe		|GetWinner	|2553/3/12 11:28	|
|13			|Nit		|GetWinner	|2553/3/12 10:00	|
|13			|Boy		|White		|2553/3/12 11:20	|
|14			|OhAe		|GetWinner	|2553/3/12 11:22	|
|14			|OhAe		|Black		|2553/3/12 11:28	|

@record_mock
Scenario: ได้รับ RoundID และ UserName ,ระบบมีข้อมูล PlayerActionInfo ในระบบ, ระบบดึงข้อมูล PlayerActionInfo กลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent RoundID: '12', UserName: 'OhAe' and expected PlayerActionInfo(s) in server
	When call List(PayForColorsWinnerInfoCommand), RoundID: '12', UserName: 'OhAe' 
	Then player should have PlayerActionInfo on this round as:
	|RoundID	|UserName	|ActionType	|DateTime(for example not use this row)			|
	|12			|OhAe		|GetWinner	|2553/3/12 10:00	|
	|12			|OhAe		|GetWinner	|2553/3/12 11:28	|

	@record_mock
Scenario: ได้รับ RoundID และ UserName ,ระบบไม่มีข้อมูล PlayerActionInfo ในระบบ, ระบบดึงข้อมูล PlayerActionInfo เปล่ากลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent RoundID: '13', UserName: 'OhAe' and expected PlayerActionInfo(s) in server
	When call List(PayForColorsWinnerInfoCommand), RoundID: '12', UserName: 'OhAe' 
	Then player should have PlayerActionInfo on this round as:
	|RoundID	|UserName	|ActionType	|DateTime(for example not use this row)			|
