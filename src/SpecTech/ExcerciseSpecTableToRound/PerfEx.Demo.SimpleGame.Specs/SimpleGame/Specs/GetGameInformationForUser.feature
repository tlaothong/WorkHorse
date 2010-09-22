Feature: Get GamePlayInformationForUser
	In order to avoid silly mistakes
	As a user
	I want to be told the game information that a user has play and game is active

@record_mock
Scenario: Sent username that available in game 

	Given The GameTableConfigurator has been created and initialized
	And  server have John's gameInformation as
		|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID								|Winner		|
		|1		|5		|10						|20						|10:00		|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|White		|
		|2		|6		|34						|32 					|10:00		|C6BF4092-836B-4069-B2DD-392F8452FA91	|C6BF4092-836B-4069-B2DD-392F8452FA91	|Black		|
		|3		|7		|143 					|352					|10:00		|496B30C2-8849-49A2-B27F-CD0F5796D912	|496B30C2-8849-49A2-B27F-CD0F5796D912	|White		|
		|1		|8		|135 					|77						|10:00		|783B1532-D962-4719-A483-44613A136785	|783B1532-D962-4719-A483-44613A136785	|Black		|
		|2		|9		|67 					|388					|10:00		|AE27B886-D6C4-467C-8FE3-336CB5A5DC69	|AE27B886-D6C4-467C-8FE3-336CB5A5DC69	|White		|


	When Call GetGamePlayInformationForUser('John')
	Then the result should be 
		|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID						|Winner		|
		|1		|5		|10						|20						|10:00		|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|White		|
		|2		|6		|34						|32 					|10:00		|C6BF4092-836B-4069-B2DD-392F8452FA91	|C6BF4092-836B-4069-B2DD-392F8452FA91	|Black		|
		|3		|7		|143 					|352					|10:00		|496B30C2-8849-49A2-B27F-CD0F5796D912	|496B30C2-8849-49A2-B27F-CD0F5796D912	|White		|
		|1		|8		|135 					|77						|10:00		|783B1532-D962-4719-A483-44613A136785	|783B1532-D962-4719-A483-44613A136785	|Black		|
		|2		|9		|67 					|388					|10:00		|AE27B886-D6C4-467C-8FE3-336CB5A5DC69	|AE27B886-D6C4-467C-8FE3-336CB5A5DC69	|White		|

@record_mock
Scenario:username not available 

	Given The GameTableConfigurator has been created and initialized
	And  server have Yui's gameInformation as
		|TableID|RoundID|TotalBetAmountOfBlack  |TotalBetAmountOfWhite	|LastUpdate	|TrackingID								|OnGoingTrackingID								|Winner		|
		|1		|5		|10						|20						|10:00		|B21F8971-DBAB-400F-9D95-151BA24875C1	|B21F8971-DBAB-400F-9D95-151BA24875C1	|White		|
		|2		|6		|34						|32 					|10:00		|C6BF4092-836B-4069-B2DD-392F8452FA91	|C6BF4092-836B-4069-B2DD-392F8452FA91	|Black		|
		|3		|7		|143 					|352					|10:00		|496B30C2-8849-49A2-B27F-CD0F5796D912	|496B30C2-8849-49A2-B27F-CD0F5796D912	|White		|
		|1		|8		|135 					|77						|10:00		|783B1532-D962-4719-A483-44613A136785	|783B1532-D962-4719-A483-44613A136785	|Black		|
		|2		|9		|67 					|388					|10:00		|AE27B886-D6C4-467C-8FE3-336CB5A5DC69	|AE27B886-D6C4-467C-8FE3-336CB5A5DC69	|White		|


	When Call GetGamePlayInformationForUser('Yui')
	Then the result should be empty
	