using MarsQA_1.Pages;
using TechTalk.SpecFlow;

namespace MarsQA_1
{
    [Binding]
    public class Languages
    {
        [Given(@"All the exsisting records should be cleared")]
        public void GivenAllTheExsistingRecordsShouldBeCleared()
        {
            LanguagesPage.ClearAllLanguageRecords();
            SkillsPage.ClearAllSkillRecords();
        }

        [When(@"I add a new language record")]
        public void WhenIAddANewLanguageRecord()
        {
            LanguagesPage.AddLanguage();
        }

        [Then(@"New language should save to the list")]
        public void ThenNewLanguageShouldSaveToTheList()
        {
            LanguagesPage.VerifyLanguageRecord();
        }

        [When(@"I add a language (.*)")]
        public void WhenIAddALanguage(int num)
        {
            LanguagesPage.AddLanguagesByPassingANumber(num);
        }

        [Then(@"Add new button should not showing in the profile")]
        public void ThenAddNewButtonShouldNotShowingInTheProfile()
        {
            LanguagesPage.VerifyAddNewButtonIsNotDisplay();
        }

        [When(@"I add a new language record with special characters")]
        public void WhenIAddANewLanguageRecordWithSpecialCharacters()
        {
            LanguagesPage.AddNewLanguageWithSpecialCharacters();
        }

        [Then(@"New language with special characters should save to the list")]
        public void ThenNewLanguageWithSpecialCharactersShouldSaveToTheList()
        {
            LanguagesPage.VerifyNewLanguageWithSpecialCharacters();
        }

        [When(@"I add a new language record with 100 characters")]
        public void WhenIAddANewLanguageRecordWithCharacters()
        {
            LanguagesPage.AddNewLanguageWith100Characters();
        }

        [Then(@"New language with 100 characters should save to the list")]
        public void ThenNewLanguageWithCharactersShouldSaveToTheList()
        {
            LanguagesPage.VerifyNewLanguageWith100Characters();
        }

        [When(@"I cancel adding language record")]
        public void WhenICancelAddingLanguageRecord()
        {
            LanguagesPage.CancelAddingLanuageRecord();
        }

        [Then(@"Adding new language should be cancel")]
        public void ThenAddingNewLanguageShouldBeCancel()
        {
            LanguagesPage.VerifyCancelAddingLanuageRecord();
        }

        [Then(@"I edit an exsisting language")]
        public void ThenIEditAnExsistingLanguageRecord()
        {
            LanguagesPage.EditLanguageRecord();
        }

        [Then(@"Edited language should save to the list")]
        public void ThenEditedLanguageShouldSaveToTheList()
        {
            LanguagesPage.VerifyEditLanguageRecord();
        }

        [Then(@"I edit an exsisting language level")]
        public void ThenIEditAnExsistingLanguageLevel()
        {
            LanguagesPage.EditLanguageLevel();
        }

        [Then(@"Edited language level should save to the list")]
        public void ThenEditedLanguageLevelShouldSaveToTheList()
        {
            LanguagesPage.VerifyEditLanguageLevelRecord();
        }

        [Then(@"I edit an exsisting language and language level")]
        public void ThenIEditAnExsistingLanguageAndLanguageLevel()
        {
            LanguagesPage.EditBothLanguageAndLanguageLevelRecord();
        }

        [Then(@"Edited language and language level should save to the list")]
        public void ThenEditedLanguageAndLanguageLevelShouldSaveToTheList()
        {
            LanguagesPage.VerifyBothUpdatedLanguageAndLanguageLevelRecord();
        }

        [Then(@"I delete an exsisting language record")]
        public void ThenUserDeleteAnExsistingLanguageRecord()
        {
            LanguagesPage.DeleteLanguageRecord();
        }

        [Then(@"The exsisting language should delete from language records")]
        public void ThenTheExsistingLanguageShouldDeleteFromLanguageRecords()
        {
            LanguagesPage.VerifyDeleteRecord();
        }

        [When(@"I try to add a new language without selecting language level")]
        public void WhenITryToAddANewLanguageWithoutSelectingLanguageLevel()
        {
            LanguagesPage.AddLanguageWithoutLanguageLevel();
        }

        [Then(@"Vaildation popup should appear as (.*)")]
        public void ThenVaildationPopupShouldAppearAs(string msg)
        {
            LanguagesPage.VerifyPopupMsg(msg);
        }

        [When(@"I try to add a new language without entering language")]
        public void WhenITryToAddANewLanguageWithoutEnteringLanguage()
        {
            LanguagesPage.AddLanguageWithoutLanguage();
        }

        [When(@"I try to add a new language without entering language and selecting language level")]
        public void WhenITryToAddANewLanguageWithoutEnteringLanguageAndSelectingLanguageLevel()
        {
            LanguagesPage.AddLanguageWithoutLanguageAndLanguageLevel();
        }

        [When(@"I try to add an existing language")]
        public void WhenITryToAddAnExistingLanguage()
        {
            LanguagesPage.AddAnExistingLanguage();
        }

        [When(@"I try to add an existing language with different language level")]
        public void WhenITryToAddAnExistingLanguageWithDifferentLanguageLevel()
        {
            LanguagesPage.AddAnExistingLanguageWithDifferentLevel();
        }
    }
}
