Feature: My Profile Skills
As a user I would be able to show what skills I know.
So that the people seeking for skills can look at what details I hold.

Background:
	Given I login to the website
	And All the exsisting records should be cleared

Scenario Outline: A_Add new skill
	When I add a new skill record including <Skill> <SkillLevel>
	Then New skill should save to the list including <Skill> <SkillLevel>

Examples:
	| Skill | SkillLevel |
	| 'C#'  | 'Beginner' |

Scenario Outline: B_Add multiple skills
	When I add a new skill record including <Skill1> <SkillLevel1>
	And I add a new skill record including <Skill2> <SkillLevel2>
	And I add a new skill record including <Skill3> <SkillLevel3>
	Then All skills should save to the list including <Skill1> <SkillLevel1> <Skill2> <SkillLevel2> <Skill3> <SkillLevel3>

Examples:
	| Skill1 | SkillLevel1 | Skill2 | SkillLevel2 | Skill3 | SkillLevel3    |
	| 'C#'   | 'Beginner'  | 'Java' | 'Beginner'  | 'Jira' | 'Intermediate' |

Scenario: C_Add a skill with disruptive data
	When I add a new skill record including <Skill> <SkillLevel>
	Then New skill should save to the list including <Skill> <SkillLevel>

Examples:
	| Skill                                                                                                                                      | SkillLevel |
	| 'Java$%^'                                                                                                                                  | 'Beginner' |
	| 'QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12' | 'Expert'   |

Scenario: D_Cancel adding lanuage record
	When I cancel adding skill record
	Then Adding new skill should be cancel

Scenario Outline: E_Edit existing skill records
	Given All the exsisting records should be cleared
	When I add a new skill record including <Skill> <SkillLevel>
	And I edit an exsisting skill including <UpdatedSkill> <UpdatedSkillLevel>
	Then Edited skill should save to the list including <UpdatedSkill> <UpdatedSkillLevel>

Examples:
	| Skill | SkillLevel | UpdatedSkill | UpdatedSkillLevel |
	| 'C#'  | 'Beginner' | 'Java'       | 'Beginner'        |
	| 'C#'  | 'Beginner' | 'C#'         | 'Expert'          |
	| 'C#'  | 'Beginner' | 'Cucumber'   | 'Intermediate'    |

Scenario Outline: F_Delete skill
	When I add a new skill record including <Skill> <SkillLevel>
	And I delete an exsisting skill record
	Then The exsisting <Skill> skill should delete from skill records

Examples:
	| Skill | SkillLevel |
	| 'C#'  | 'Beginner' |

Scenario Outline: G_Verify cannot add skill with invalid data
	When I add a new skill record including <Skill> <SkillLevel>
	Then Vaildation popup should appear as Please enter skill and experience level

Examples:
	| Skill | SkillLevel |
	| 'C#'  | ''         |
	| ''    | 'Beginner' |
	| ''    | ''         |

Scenario Outline: H_Verify cannot add an existing skills
	When I add a new skill record including <Skill> <SkillLevel>
	When I add a new skill record including <Skill2> <SkillLevel2>
	Then Vaildation popup should appear as <PopupMsg>

Examples:
	| Skill | SkillLevel | Skill2 | SkillLevel2    | PopupMsg                                        |
	| 'C#'  | 'Beginner' | 'C#'   | 'Beginner'     | This skill is already exist in your skill list. |
	| 'C#'  | 'Beginner' | 'C#'   | 'Intermediate' | Duplicated data                                 |
