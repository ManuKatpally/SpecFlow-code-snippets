Scenario: Application Completed Successfully
Given I am on the Loan Application screen
And I enter firstname of manu
And I enter Last name of katpally
And I select that I have an existing loan account
And I confirm my acceptance of the terms and conditions
When I submit my Application
Then I should see the application complete confirmation for manu

Scenario: Cannot submit application unless terms and conditions accepted
Given I am on the Loan Application screen
And I enter firstname of Nagesh
And I enter Last name of Podduturi
And I select that I have an existing loan account
When I submit my Application
Then I should see an error message telling me I must accept the terms and conditions

