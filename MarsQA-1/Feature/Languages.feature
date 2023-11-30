Feature: My Profile Languages
As a user I would be able to show what languages I know.
So that the people seeking for languages can look at what details I hold.

Background:
	Given I login to the website
	And All the exsisting records should be cleared

Scenario Outline: A_Add new language
	When I add a new language record including <Language> <LanguageLevel>
	Then new language should save to the list including <Language> <LanguageLevel>

Examples:
	| Language | LanguageLevel |
	| 'French' | 'Basic'       |

Scenario Outline: B_Add upto a maximum of four languages
	When I add a new language record including <Language1> <LanguageLevel1>
	And I add a new language record including <Language2> <LanguageLevel2>
	And I add a new language record including <Language3> <LanguageLevel3>
	And I add a new language record including <Language4> <LanguageLevel4>
	Then Add new button should not showing in the profile

Examples:
	| Language1 | LanguageLevel1 | Language2 | LanguageLevel2     | Language3 | LanguageLevel3   | Language4   | LanguageLevel4 |
	| 'French'  | 'Basic'        | 'Sinhala' | 'Native/Bilingual' | 'Tamil'   | 'Conversational' | 'Manderine' | 'Fluent'       |

Scenario Outline: C_Add new language with disruptive data
	When I add a new language record including <Language> <LanguageLevel>
	Then new language should save to the list including <Language> <LanguageLevel>

Examples:
	| Language                                                                                                                                   | LanguageLevel |
	| 'Sinhala!@#'                                                                                                                               | 'Basic'       |
	| 'QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12' | 'Fluent'      |

Scenario: D_Cancel adding lanuage record
	When I cancel adding language record
	Then Adding new language should be cancel

Scenario Outline: E_Edit existing language records
	Given All the exsisting records should be cleared
	When I add a new language record including <Language> <LanguageLevel>
	Then I edit an exsisting language including <UpdatedLanguage> <UpdatedLanguageLevel>
	Then Edited language should save to the list including <UpdatedLanguage> <UpdatedLanguageLevel>

Examples:
	| Language | LanguageLevel | UpdatedLanguage | UpdatedLanguageLevel |
	| 'French' | 'Basic'       | 'Tamil'         | 'Basic'              |
	| 'French' | 'Basic'       | 'French'        | 'Fluent'             |
	| 'French' | 'Basic'       | 'English'       | 'Conversational'     |

Scenario Outline: F_Delete language
	When I add a new language record including <Language> <LanguageLevel>
	Then I delete an exsisting language record
	And The exsisting <Language> language should delete from language records

Examples:
	| Language | LanguageLevel |
	| 'French' | 'Basic'       |

Scenario Outline: G_Verify cannot add language with invalid data
	When I add a new language record including <Language> <LanguageLevel>
	Then Vaildation popup should appear as Please enter language and level

Examples:
	| Language | LanguageLevel |
	| 'French' | ''            |
	| ''       | 'Basic'       |
	| ''       | ''            |

Scenario Outline: H_Verify cannot add an existing languages
	When I add a new language record including <Language> <LanguageLevel>
	When I add a new language record including <Language2> <LanguageLevel2>
	Then Vaildation popup should appear as <PopupMsg>

Examples:
	| Language | LanguageLevel | Language2 | LanguageLevel2 | PopupMsg                                              |
	| 'French' | 'Basic'       | 'French'  | 'Basic'        | This language is already exist in your language list. |
	| 'French' | 'Basic'       | 'French'  | 'Fluent'       | Duplicated data                                       |
