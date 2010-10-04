Feature: ListGameTableConfigurations
	In order to list game table configuration
	As a back server
	I want to be told the game table configuration

@record_mock
Scenario: ระบบรับข้อมูลชื่อ config, ระบบดึงข้อมูล game configurations กลับ
	Given The ListGameTableConfigurations has been created and initialized
	And sent Configuration name: 'config1' and expected game configuration as:
	|Name		|TableID	|GameDuration	|Interval	|
	|config1	|1			|10				|5			|
	|config1	|2			|20				|10			|
	|config1	|3			|15				|7			|

	When call ListGameTableConfigurations(name: 'config1')
	Then the game configurations should be('config1'):
	|Name		|TableID	|GameDuration	|Interval	|
	|config1	|1			|10				|5			|
	|config1	|2			|20				|10			|
	|config1	|3			|15				|7			|

@record_mock
Scenario: ระบบรับข้อมูลชื่อ config และมีข้อมูล config หลายชื่อ, ระบบดึงข้อมูล game configurations กลับ
	Given The ListGameTableConfigurations has been created and initialized
	And sent Configuration name: 'config1' and expected game configuration as:
	|Name		|TableID	|GameDuration	|Interval	|
	|config1	|1			|10				|5			|
	|config1	|2			|20				|10			|
	|config1	|3			|15				|7			|
	|config2	|1			|10				|5			|
	|config3	|2			|20				|10			|
	|config4	|3			|15				|7			|

	When call ListGameTableConfigurations(name: 'config1')
	Then the game configurations should be('config1'):
	|Name		|TableID	|GameDuration	|Interval	|
	|config1	|1			|10				|5			|
	|config1	|2			|20				|10			|
	|config1	|3			|15				|7			|
	|config2	|1			|10				|5			|
	|config3	|2			|20				|10			|
	|config4	|3			|15				|7			|
