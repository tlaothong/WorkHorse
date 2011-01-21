Feature: ListMLNInformation
	In order to ให้ผู้เล่นได้ทราบถึงสถิติการได้โบนัสของตนเอง และจำนวน downline ทั้งหมดที่มี
	As a Web server
	I want ดึงข้อมูลสถิติยอดจำนวนโบนัสที่ได้รับ และจำนวน downline ทั้งหมดที่ผู้เล่นมีในแต่ละ level

@record_mock
Background:
Given Server has MLN information :
	|UserName	|BonusThisMonth	|BonusLastMonth	|TotalDownLineLevel1|TotalDownLineLevel2|TotalDownLineLevel3|TotalBonus	|
	|OhAe		|200			|300			|15					|33					|68					|799		|
	|Boy		|150			|274			|7					|16					|48					|503		|
	|Nit		|324			|350			|18					|20					|89					|1056		|

@record_mock
Scenario:[ListMLNInfo] Web server ได้รับข้อมูลการขอดูข้อมูลเครือข่ายของผู้เล่น ทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง Web server สามารถดึงข้อมูลเครือข่ายของผู้เล่นได้
	Given The ListMLNInfoExecutor has been created and initialized
	And   Sent UserName 'OhAe' for list MLN information 
	When  Call ListMLNInformation()
	Then  MLN information should be as: UserName'OhAe' BonusThisMonth'200' BonusLastMonth'300' TotalDownLineLevel1'15' TotalDownLineLevel2'33' TotalDownLineLevel3'68' TotalBonus'799'

@record_mock
Scenario:[ListMLNInfo] Web server ได้รับข้อมูลการขอดูข้อมูลเครือข่ายของผู้เล่น ทำการตรวจสอบข้อมูล ข้อมูลถูกต้อง แต่ผู้เล่นยังไม่มีสถิติจำนวนโบนัสและ downline ได้ข้อมูล MLN เป็น null 
	Given The ListMLNInfoExecutor has been created and initialized
	And   Sent UserName 'Nayit' for list MLN information 
	When  Call ListMLNInformation()
	Then  MLN information should be null
	
@record_mock
Scenario:[ListMLNInfo] Web server ได้รับข้อมูลการขอดูข้อมูลเครือข่ายของผู้เล่น ทำการตรวจสอบข้อมูล ข้อมูลไม่ถูกต้อง ไม่สามารถดึงข้อมูลได้
	Given The ListMLNInfoExecutor has been created and initialized
	And   Sent UserName '' for list MLN information 
	When  Call ListMLNInformation() for validation
	Then  MLN information should be throw exception
	