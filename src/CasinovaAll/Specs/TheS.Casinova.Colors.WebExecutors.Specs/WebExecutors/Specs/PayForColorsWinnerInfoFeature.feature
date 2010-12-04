Feature: PayForColorsWinnerInformation
	In order to pay for colors winner information 
	As a system
	I want to sent information for pay colors winner

@record_mock
Scenario Outline:[PayForColorsWinner]ระบบได้รับข้อมูล PayForColorsWinnerInformation ระบบทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ระบบไม่ทำการ generate trackingID
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And   PayForColorWinner Informations as : UserName '<UserName>' RoundID '<RoundID>' ActionType '<ActionType>'
	When  Call PayForColorsWinnerInfoExecutor() for validate PayForColorWinner informations
	Then  PayForColorWinnerInfo get null and skip checking trackingID

Examples:
	|UserName	|RoundID	| ActionType|
	|		 	|2			|	Black	|
	|Nit	 	|-2			|	Black	|
	|Nit	 	|2			|			|


@record_mock
Scenario:[PayForColorsWinner]ระบบได้รับข้อมูล PayForColorsWinnerInformation ระบบทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง ระบบทำการ generate trackingID
	Given The PayForColorsWinnerInfoExecutor has been created and initialized
	And   PayForColorWinner Informations as : UserName 'Nataya' RoundID '3' ActionType 'PayForWinner'
	And   The system generated TrackingID:'955D6ACDE4E04D1C90ACF3715BB2685A' for PayForColorWinnerInfo
	When  Call PayForColorsWinnerInfoExecutor()
	Then  TrackingID for PayForColorWinnerInfo should be :'955D6ACDE4E04D1C90ACF3715BB2685A'
	

	

