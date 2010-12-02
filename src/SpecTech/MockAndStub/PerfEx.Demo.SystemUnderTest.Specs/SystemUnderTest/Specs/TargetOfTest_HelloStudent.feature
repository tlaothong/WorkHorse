Feature: Hello Student
	In order to greet all students
	As a person
	I want to be told the words to greet a student, given a student id

@record_mock
Scenario: Hello Student given the existing student id
	Given an instance of TargetOfTest initializes with mock up of IWorkTogether
	And There is a student id #1 names 'John'
	And Expects Log('HelloStudent')
	And Expects Log('Found: John')
	When call HelloStudent(1)
	Then the result should be 'Hello John.'

@record_mock
Scenario Outline: Hello existing Students
	Given an instance of TargetOfTest initializes with mock up of IWorkTogether
	And There is a student id #<studentId> names '<name>'
	And Expects Log('HelloStudent')
	And Expects Log('Found: <name>')
	When call HelloStudent(<studentId>)
	Then the result should be 'Hello <name>.'

	Examples:
		|studentId	|name	|
		|1			|John	|
		|2			|Tom	|
		|3			|Mary	|
