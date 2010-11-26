Feature: N2N Get list game play auto bet information
	1.Game has display list active game rounds finish (Silverlight)
	2.Send request get list game play information indentify by username to web server (Silverlight)
	3.List game play information where owner name and username is match (Web Server)
	4.Send game play information back to client (Web Server)
	5.Display game play information (Silverlight)

Background:
	Given Create and initialize GamePlayViewModel and MagicNine game service
	And Web server have game play auto bet information are
		|UserName	|RoundID	|Amount	|
		|Sakul		|1			|30		|
		|Sakul		|2			|560	|
		|Sakul		|4			|10245	|
	And Client have active game rounds are:
		|RoundID|WinnerPoint	|
		|1		|9				|
		|2		|99				|
		|3		|999			|
		|4		|9999			|

@record_mock
Scenario: Send request get list auto bet game play information to web server 
	When Send request GetListGamePlayAutoBet( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Name	|Amount	|IsPlaying	|
		|1		|9		|30		|true		|
		|2		|99		|560	|true		|
		|3		|999	|0		|false		|
		|4		|9999	|10245	|true		|
		
@record_mock
Scenario: Send request get list auto bet game play information to web server, don't have game play auto bet information
	When Send request GetListGamePlayAutoBet( 'Mary' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Name	|Amount	|IsPlaying	|
		|1		|9		|0		|false		|
		|2		|99		|0		|false		|
		|3		|999	|0		|false		|
		|4		|9999	|0		|false		|

@record_mock
Scenario: Send request get list auto bet game play information to web server more than one request
	When Send request GetListGamePlayAutoBet( 'Sakul' )
	And Send request GetListGamePlayAutoBet( 'Sakul' )
	Then Tables in GamePlayViewModel display game play information are
		|Round	|Name	|Amount	|IsPlaying	|
		|1		|9		|30		|true		|
		|2		|99		|560	|true		|
		|3		|999	|0		|false		|
		|4		|9999	|10245	|true		|