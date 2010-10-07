Feature: GetPlayerInfoForPayForColorsWinnerInfo
	In order to get player information
	As a back server
	I want to be get player information(balance)

@record_mock
Background:
Given server has user information as:
|UserName	|Balance	|
|OhAe		|463.61		|
|Boy		|121.21		|
|Nit		|36.99		|
|Au			|234.00		|

@record_mock
Scenario: ได้รับ username และระบบมีข้อมูล balance ของ username ที่รับมา, ระบบดึงข้อมูลของผู้ใช้กลับ
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent userName: 'OhAe' and expected player's balance should be '463.61'
	When call Get(PayForColorsWinnerInfoCommand), UserName: 'OhAe'
	Then the result should be same as expected balance

@record_mock
Scenario: ได้รับ username และระบบมีข้อมูล balance ของ username ที่รับมา, ระบบดึงข้อมูลของผู้ใช้กลับ2
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And sent userName: 'Au' and expected player's balance should be '234.00'
	When call Get(PayForColorsWinnerInfoCommand), UserName: 'Au'
	Then the result should be same as expected balance

