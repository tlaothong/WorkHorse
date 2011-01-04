Feature: ReturnReward
	In order to return reward to winner
	As a back server
	I want to be update user profile

@record_mock
Background: ReturnReward
	Given (PlayerProfile_ReturnReward)server has player information as:
	|UserName	|NonRefundable	|Refundable		|
	|OhAe		|462.61			|200			|	
	|Boy		|0.99			|0				|
	|Toommy		|36.95			|37				|
	|Au			|234.00			|326			|
	|Game		|1				|5				|
	|Khag		|0.50			|45				|
	|Ple		|0.99			|452			|

@record_mock
Scenario: (PlayerProfile_ReturnReward)ผู้เล่นชนะเกม โดยลงพนันเฉพาะชิฟตาย ระบบอัพเดทชิฟเพิ่มให้ผู้เล่น
	Given The ReturnRewardExecutor has been created and initialized	
	And (PlayerProfile_ReturnReward)sent name: 'OhAe' the player's balance should recieved
	And the user profile should be update(UserName: 'OhAe', NonRefundable: '463.61', Refundable: '208')
	When call ReturnRewardExecutor(UserName: 'OhAe', NonRefundable: '1', Refundable: '8')
	Then the result should be update 
