Feature: Scoring a game of bowlping
	In order to know how well I did
    As a bowler
	I want to know my bowling score at the end of a game	

Scenario: Rolling all gutter balls scores 0
	Given I have rolled 20 times and knocked down 0 pins each
	When I ask for the score
	Then the result should be 0

Scenario: Only hitting 1 pin
	Given I have rolled 20 times and knocked down 1 pin each
	When I ask for the score
	Then the result should be 20

Scenario: Spare will score the bonus ball
    Given I have rolled 1 time and knocked down 4 pins each
    And I have rolled 1 time and knocked down 6 pins each
    And I have rolled 1 time and knocked down 4 pins each
    And I have rolled 17 times and knocked down 0 pins each
    When I ask for the score
    Then the result should be 18
    
Scenario: Perfect game
    Given I have rolled 12 times and knocked down 10 pins each
    When I ask for the score
    Then the result should be 300