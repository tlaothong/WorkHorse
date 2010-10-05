﻿Feature: GetGameResult
	In order to get game result
	As a system
	I want to get game result when game finish

@record_mock
Scenario: sent tableId and roundID that available
	Given The GameRoundInformation has been created and initialized
	And Server has game information 
		|BlackPot	| WhitePot	|HandCount	|
		|23		    |24			|13			|
	When Call GetGameResultExecutor(RoundID'1')
	Then the game result should be 
		|BlackPot| WhitePot	|HandCount	|
		|23	     |24	    |13			|

@record_mock
Scenario: sent anothor data which available in DB
	Given The GameRoundInformation has been created and initialized
	And Server has game information
		|BlackPot	| WhitePot	|HandCount	|
		|50		    |100		|20			|
	When Call GetGameResultExecutor(RoundID'2')
	Then the game result should be 
		|BlackPot| WhitePot	|HandCount	|
		|50		 |100		|20	        |

@record_mock
Scenario: RoundID is not available
	Given The GameRoundInformation has been created and initialized
	And Server has game information
		|BlackPot	| WhitePot	|HandCount	|
		
	When Call GetGameResultExecutor(RoundID'3')
	Then the game result should be null
		
	