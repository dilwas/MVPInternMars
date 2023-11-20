Feature: My Profile Languages
As a user I would be able to show what languages I know.
So that the people seeking for languages can look at what details I hold.

Background:
	Given I login to the website
	And All the exsisting records should be cleared

Scenario: A_Add new language
	When I add a new language record
	Then New language should save to the list

Scenario: B_Add upto a maximum of four languages
    When I add a language 1
	And I add a language 2
	And I add a language 3
	And I add a language 4
	Then Add new button should not showing in the profile

Scenario: C_Add a language with special characters
	When I add a new language record with special characters
	Then New language with special characters should save to the list

Scenario: D_Add a language with 100 characters
	When I add a new language record with 100 characters
	Then New language with 100 characters should save to the list

Scenario: E_Cancel adding lanuage record
    When I cancel adding language record
	Then Adding new language should be cancel

Scenario: F_Edit existing language record by changing language
	When I add a new language record
	Then I edit an exsisting language
	And Edited language should save to the list

Scenario: G_Edit existing language record by changing language level
	When I add a new language record
	Then I edit an exsisting language level
	And Edited language level should save to the list
Scenario: H_Edit existing language record by changing both language and language level
	When I add a new language record
	Then I edit an exsisting language and language level
	And Edited language and language level should save to the list

Scenario: I_Delete language
	When I add a new language record
	Then I delete an exsisting language record
	And The exsisting language should delete from language records

Scenario: J_Verify cannot add language without language level
	When I try to add a new language without selecting language level
	Then Vaildation popup should appear as Please enter language and level

Scenario: K_Verify cannot add language without language text
	When I try to add a new language without entering language 
	Then Vaildation popup should appear as Please enter language and level

Scenario: L_Verify cannot add language without language and language level
	When I try to add a new language without entering language and selecting language level
	Then Vaildation popup should appear as Please enter language and level

Scenario: M_Verify cannot add an existing languages with same language level
	When I add a new language record
	And I try to add an existing language 
	Then Vaildation popup should appear as This language is already exist in your language list.

Scenario: N_Verify cannot add an existing languages with different language level
	When I add a new language record
	And I try to add an existing language with different language level
	Then Vaildation popup should appear as Duplicated data
