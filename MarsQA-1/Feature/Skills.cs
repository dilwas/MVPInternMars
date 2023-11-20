using MarsQA_1.Pages;
using TechTalk.SpecFlow;

namespace MarsQA_1
{
    [Binding]
    public class Skills
    {
        [When(@"I add a new skill record")]
        public void WhenIAddANewSkillRecord()
        {
            SkillsPage.AddSkill();
        }

        [Then(@"New skill should save to the list")]
        public void ThenNewSkillShouldSaveToTheList()
        {
            SkillsPage.VerifySkillRecord();
        }

        [When(@"I add a skill (.*)")]
        public void WhenIAddASkill(int num)
        {
            SkillsPage.AddSkillsByPassingANumber(num);
        }

        [Then(@"All skills should save to the list")]
        public void ThenAllSkillsShouldSaveToTheList()
        {
            SkillsPage.VerifySkillsRecords();
        }

        [When(@"I add a new skill record with special characters")]
        public void WhenIAddANewSkillRecordWithSpecialCharacters()
        {
            SkillsPage.AddNewSkillWithSpecialCharacters();
        }

        [Then(@"New skill with special characters should save to the list")]
        public void ThenNewSkillWithSpecialCharactersShouldSaveToTheList()
        {
            SkillsPage.VerifyNewSkillWithSpecialCharacters();
        }

        [When(@"I add a new skill record with 100 characters")]
        public void WhenIAddANewSkillRecordWithCharacters()
        {
            SkillsPage.AddNewSkillWith100Characters();
        }

        [Then(@"New skill with 100 characters should save to the list")]
        public void ThenNewSkillWithCharactersShouldSaveToTheList()
        {
            SkillsPage.VerifyNewSkillWith100Characters();
        }

        [When(@"I cancel adding skill record")]
        public void WhenICancelAddingSkillRecord()
        {
            SkillsPage.CancelAddingSkillRecord();
        }

        [Then(@"Adding new skill should be cancel")]
        public void ThenAddingNewSkillShouldBeCancel()
        {
            SkillsPage.VerifyCancelAddingSkillRecord();
        }

        [Then(@"I edit an exsisting skill")]
        public void ThenIEditAnExsistingSkillRecord()
        {
            SkillsPage.EditSkillRecord();
        }

        [Then(@"Edited skill should save to the list")]
        public void ThenEditedSkillShouldSaveToTheList()
        {
            SkillsPage.VerifyEditSkillRecord();
        }

        [Then(@"I edit an exsisting skill level")]
        public void ThenIEditAnExsistingSkillLevel()
        {
            SkillsPage.EditSkillLevel();
        }

        [Then(@"Edited skill level should save to the list")]
        public void ThenEditedSkillLevelShouldSaveToTheList()
        {
            SkillsPage.VerifyEditSkillLevelRecord();
        }

        [Then(@"I edit an exsisting skill and skill level")]
        public void ThenIEditAnExsistingSkillAndskillLevel()
        {
            SkillsPage.EditBothSkillAndSkillLevelRecord();
        }

        [Then(@"Edited skill and skill level should save to the list")]
        public void ThenEditedSkillAndSkillLevelShouldSaveToTheList()
        {
            SkillsPage.VerifyBothUpdatedSkillAndSkillLevelRecord();
        }

        [Then(@"I delete an exsisting skill record")]
        public void ThenUserDeleteAnExsistingSkillRecord()
        {
            SkillsPage.DeleteSkillRecord();
        }

        [Then(@"The exsisting skill should delete from skill records")]
        public void ThenTheExsistingSkillShouldDeleteFromSkillRecords()
        {
            SkillsPage.VerifyDeleteRecord();
        }

        [When(@"I try to add a new skill without selecting skill level")]
        public void WhenITryToAddANewSkillWithoutSelectingSkillLevel()
        {
            SkillsPage.AddSkillWithoutSkillLevel();
        }

        [When(@"I try to add a new skill without entering skill")]
        public void WhenITryToAddANewSkillWithoutEnteringSkill()
        {
            SkillsPage.AddSkillWithoutSkill();
        }

        [When(@"I try to add a new skill without entering skill and selecting skill level")]
        public void WhenITryToAddANewSkillWithoutEnteringSkillAndSelectingSkillLevel()
        {
            SkillsPage.AddSkillWithoutSkillAndSkillLevel();
        }

        [When(@"I try to add an existing skill")]
        public void WhenITryToAddAnExistingSkill()
        {
            SkillsPage.AddAnExistingSkill();
        }

        [When(@"I try to add an existing skill with different skill level")]
        public void WhenITryToAddAnExistingSkillWithDifferentSkillLevel()
        {
            SkillsPage.AddAnExistingSkillWithDifferentLevel();
        }
    }
}
