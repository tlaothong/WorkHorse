Feature: ListDownLineByLevel
	In order to ให้ผู้เล่นทราบรายละเอียดจำนวน DownLine ทั้งหมดที่มีในแต่ละ level 
	As a User
	I want ดึงข้อมูลรายละเอียด DownLine ทั้งหมดที่มีใน level นั้น ๆ และ DownLine ทั้งหมดที่มีผลต่อผู้ใช้

@record_mock
Background:
Given Server has DownLine information :
	|UserName	|UplineLevel1	|UplineLevel2	|UplineLevel3	|BonusThisMonth	|BonusLastMonth	|TotalDownLineLevel1|TotalDownLineLevel2|TotalDownLineLevel3|TotalBonus	|
	|Nit		|TheS			|TheS			|TheS			|200			|300			|3					|3					|4					|2541		|
	|Boy		|Nit			|TheS			|TheS			|150			|274			|1					|3					|4					|503		|
	|OhAe		|Boy			|Nit			|TheS			|324			|350			|3					|4					|3					|1056		|
	|Jay		|OhAe			|Boy			|Nit			|200			|120			|2					|2					|0					|524		|
	|Art		|Jay			|OhAe			|Boy			|165			|155			|1					|0					|0					|426		|
	|Of			|OhAe			|Boy			|Nit			|106			|57				|1					|1					|0					|236		|
	|Kab		|Of				|OhAe			|Boy			|265			|254			|1					|0					|0					|630		|
	|Sak		|Kab			|Of				|OhAe			|120			|156			|0					|0					|0					|336		|
	|Boong		|Nit			|TheS			|TheS			|287			|365			|1					|1					|0					|854		|
	|Khak		|Nit			|TheS			|TheS			|51				|105			|1					|0					|0					|204		|
	|Toommy		|Khak			|Nit			|TheS			|265			|97				|0					|0					|0					|450		|
	|Pray		|Boong			|Nit			|TheS			|112			|110			|1					|0					|0					|320		|
	|Jo			|Jay			|OhAe			|Boy			|55				|25				|1					|0					|0					|110		|
	|Bird		|Jo				|Jay			|OhAe			|63				|45				|0					|0					|0					|200		|
	|Top		|OhAe			|Boy			|Nit			|20				|12				|1					|0					|0					|45			|
	|Toa		|Pray			|Boong			|Nit			|25				|5				|0					|0					|0					|25			|
	|Map		|Top			|OhAe			|Boy			|12				|10				|0					|0					|0					|20			|
	|Amp		|Art			|Jay			|OhAe			|2				|4				|0					|0					|0					|20			|

@record_mock
Scenario:[ListDownLineByLevel] ระบบได้รับข้อมูลการขอดูข้อมูล DownLine ตรวจสอบข้อมูล ข้อมูลถูกต้อง ดึงข้อมูล Downline แต่ละ level ได้
	Given The ListDownLineByLevelExecutor has been created and initialized
	And   Sent UserName'Boy' 
	When  Call ListDownLineBylavelExecutor()
	Then  DowwnLineLevel1 information should be as:
			|UserName	|GroupCount	|	
			|OhAe		|7			|
	And   DowwnLineLevel2 information should be as:
			|UserName	|GroupCount	|	
			|Jay		|1			|		
			|Of			|1			|
			|Top		|1			|
	And   DowwnLineLevel3 information should be as:
			|UserName	|GroupCount	|	
			|Art		|0			|		
			|Kab		|0			|
			|Jo			|0			|
			|Map		|0			|