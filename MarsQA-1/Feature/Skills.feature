Feature: My Profile Skills
As a user I would be able to show what skills I know.
So that the people seeking for skills can look at what details I hold.

Background:
	Given I login to the website
	And All the exsisting records should be cleared

Scenario: A_Add new skill
	When I add a new skill record
	Then New skill should save to the list

Scenario: B_Add multiple skills
    When I add a skill 1
	And I add a skill 2
	And I add a skill 3
	Then All skills should save to the list

Scenario: C_Add a skill with special characters
	When I add a new skill record with special characters
	Then New skill with special characters should save to the list

Scenario: D_Add a skill with 100 characters
	When I add a new skill record with 100 characters
	Then New skill with 100 characters should save to the list

Scenario: E_Cancel adding lanuage record
    When I cancel adding skill record
	Then Adding new skill should be cancel

Scenario: F_Edit existing skill record by changing skill
	When I add a new skill record
	Then I edit an exsisting skill
	And Edited skill should save to the list

Scenario: G_Edit existing skill record by changing skill level
	When I add a new skill record
	Then I edit an exsisting skill level
	And Edited skill level should save to the list

Scenario: H_Edit existing skill record by changing both skill and skill level
	When I add a new skill record
	Then I edit an exsisting skill and skill level
	And Edited skill and skill level should save to the list

Scenario: I_Delete skill
	When I add a new skill record
	Then I delete an exsisting skill record
	And The exsisting skill should delete from skill records

Scenario: J_Verify cannot add skill without skill level
	When I try to add a new skill without selecting skill level
	Then Vaildation popup should appear as Please enter skill and experience level

Scenario: K_Verify cannot add skill without skill text
	When I try to add a new skill without entering skill 
	Then Vaildation popup should appear as Please enter skill and experience level

Scenario: L_Verify cannot add skill without skill and skill level
	When I try to add a new skill without entering skill and selecting skill level
	Then Vaildation popup should appear as Please enter skill and experience level

Scenario: M_Verify cannot add an existing skills with same skill level
	When I add a new skill record
	And I try to add an existing skill 
	Then Vaildation popup should appear as This skill is already exist in your skill list.

Scenario: N_Verify cannot add an existing skills with different skill level
	When I add a new skill record
	And I try to add an existing skill with different skill level
	Then Vaildation popup should appear as Duplicated data
