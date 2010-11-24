Feature: Get game round winner
	In order to get information of winner in the round
	As as system
	I want to be told the game information of winner that a user has play and game is active

@record_mock
Scenario: Sent username that available in game and get information success

	Given The GameRoundWinner has been created and initialized
	And Sent username 'J.Doe' Game active formtime '10:00'
	And  server have J.Doe's gameRoundWinner as
		|Username	|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID						|Winner		|
		|J.Doe		|1		|5		|10						|20						|10:00		|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|White		|
		|J.Doe		|2		|6		|34						|32 					|10:00		|C6BF4092-836B-4069-B2DD-392F8452FA91	|C6BF4092-836B-4069-B2DD-392F8452FA91	|Black		|
		|J.Doe		|3		|7		|143 					|352					|10:00		|496B30C2-8849-49A2-B27F-CD0F5796D912	|496B30C2-8849-49A2-B27F-CD0F5796D912	|White		|


	When Call GetGameRoundWinner('J.Doe')
	Then the result should be 
		|Username	|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID						|Winner		|
		|J.Doe		|1		|5		|10						|20						|10:00		|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|White		|
		|J.Doe		|2		|6		|34						|32 					|10:00		|C6BF4092-836B-4069-B2DD-392F8452FA91	|C6BF4092-836B-4069-B2DD-392F8452FA91	|Black		|
		|J.Doe		|3		|7		|143 					|352					|10:00		|496B30C2-8849-49A2-B27F-CD0F5796D912	|496B30C2-8849-49A2-B27F-CD0F5796D912	|White		|

@record_mock
Scenario: Sent username that available in game but database do not have information

	Given The GameRoundWinner has been created and initialized
	And Sent username 'J.Doe' Game active formtime '10:00'
	And  server have J.Doe's gameRoundWinner as
		|Username	|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID						|Winner		|


	When Call GetGameRoundWinner('J.Doe')
	Then the result should be 
		|Username	|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID						|Winner		|


@record_mock
Scenario:username not available 

	Given The GameRoundWinner has been created and initialized
	And  server have John's gameRoundWinner as
		|Username	|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID						|Winner		|
		|John		|1		|5		|10						|20						|10:00		|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|White		|
		|John		|2		|6		|34						|32 					|10:00		|C6BF4092-836B-4069-B2DD-392F8452FA91	|C6BF4092-836B-4069-B2DD-392F8452FA91	|Black		|
		|John		|3		|7		|143 					|352					|10:00		|496B30C2-8849-49A2-B27F-CD0F5796D912	|496B30C2-8849-49A2-B27F-CD0F5796D912	|White		|


	When Call GetGameRoundWinner('John')
	Then the result should be empty
	