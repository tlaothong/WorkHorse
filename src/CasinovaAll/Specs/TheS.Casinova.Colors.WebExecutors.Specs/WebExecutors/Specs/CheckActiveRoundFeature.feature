﻿Feature: CheckActiveRoundToCreate
	In order to check active round
	As a system
	I want to check active round for sent command to back server 

@record_mock
Scenario: ระบบส่งค่า Name ถูกต้อง ระบบตรวจสอบจำนวน active round ที่มี มีค่าเท่ากับจำนวน active round ทั้งหมดที่ระบบต้องการ 
	Given The GameRoundConfigurations has been created and initialized
	And Active round has'5', Expect active round '5'  
	When Execute CheckActiveRoundToCreateCommand 
	Then The system don't add ActiveRound

@record_mock
Scenario: ระบบตรวจสอบจำนวน active round ที่มี มีค่ามากกว่าจำนวน active round ทั้งหมดที่ระบบต้องการ 
	Given The GameRoundConfigurations has been created and initialized
	And Active round has'6', Expect active round '5'  
	When Execute CheckActiveRoundToCreateCommand 
	Then The system don't add ActiveRound

@record_mock
Scenario: ระบบตรวจสอบจำนวน active round ที่มี มีค่าน้อยกว่าจำนวน active round ทั้งหมดที่ระบบต้องการ 
	Given The GameRoundConfigurations has been created and initialized
	And Active round has'4', Expect active round '5'  
	When Execute CheckActiveRoundToCreateCommand 
	Then The system sent command to back server

@record_mock
Scenario: ระบบไม่ได้ส่งค่า Name ระบบไม่สามารถตรวจสอบจำนวน active round ได้ 
	Given The GameRoundConfigurations has been created and initialized
	When Execute CheckActiveRoundToCreateCommand 
	Then The system don't add ActiveRound