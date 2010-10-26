Feature: Get game result
	In order to avoid game result when game end
	As a system
	I want to be told game result

@record_mock
Scenario: sent tableId and roundID that available
	Given The ColorGameService has been created and initialized
	And server has game information as:
		|TotalAmountOfBlack	|TotalAmountOfWhite	|HandCount	|
		|23					|24					|13			|

	And I have entered TableID 1 and RoundID 1
	When I press getting process
	Then the game result should be 
		|TotalAmountOfBlack	|TotalAmountOfWhite	|HandCount	|
		|23					|24					|13			|

@record_mock
Scenario: sent anothor data which available in DB
	Given The ColorGameService has been created and initialized
	And server has game information as:
		|TotalAmountOfBlack	|TotalAmountOfWhite	|HandCount	|
		|43					|25					|33			|
	And I have entered TableID 2 and RoundID 2
	When I press getting process
	Then the game result should be 
		|TotalAmountOfBlack	|TotalAmountOfWhite	|HandCount	|
		|43					|25					|33			|

@record_mock
Scenario: RoundID is not available
	Given The ColorGameService has been created and initialized
	And server has game information as:
		|TotalAmountOfBlack	|TotalAmountOfWhite	|HandCount	|

	When I press getting process
	Then the game result should be null
		
