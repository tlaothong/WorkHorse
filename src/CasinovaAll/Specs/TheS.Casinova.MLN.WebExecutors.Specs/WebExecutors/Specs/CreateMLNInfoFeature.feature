Feature: CreateMLNInformation
	In order to เพื่อเก็บข้อมูล Upline และโบนัสทั้งหมด
	As a Web server
	I want สร้างข้อมูล MLN ของผู้ใช้

@record_mock
Scenario:[CreateMLNInfo] Web server ได้รับข้อมูลเพื่อสร้างระบบเครือข่าย ทำการตรวจสอบข้อมูลที่ได้รับ ผู้ใช้กรอกฃ้อมูลถูกต้อง ส่งข้อมูลไป Back server ต่อไป
	Given The CreateMLNInfoExecutor has been created and initialized
	And  Sent UserName 'Nit' UplineLevel1 'Sak'
	When Call CreateMLNInfoExecutor()
	Then MLN information can sent to back server

@record_mock
Scenario:[CreateMLNInfo] Web server ได้รับข้อมูลเพื่อสร้างระบบเครือข่าย ทำการตรวจสอบข้อมูลที่ได้รับ ผู้ใช้กรอกฃ้อมูล userName ไม่ถูกต้อง ไม่สามารถส่งข้อมูลไป Back server ได้
	Given The CreateMLNInfoExecutor has been created and initialized
	And  Sent UserName '' UplineLevel1 'Sak'
	When Call CreateMLNInfoExecutor() for validation
	Then MLN information can't sent to back server

@record_mock
Scenario:[CreateMLNInfo] Web server ได้รับข้อมูลเพื่อสร้างระบบเครือข่าย ทำการตรวจสอบข้อมูลที่ได้รับ ผู้ใช้กรอกฃ้อมูล uplineLevel1 ไม่ถูกต้อง ไม่สามารถส่งข้อมูลไป Back server ได้
	Given The CreateMLNInfoExecutor has been created and initialized
	And  Sent UserName 'Nit' UplineLevel1 ''
	When Call CreateMLNInfoExecutor() for validation
	Then MLN information can't sent to back server