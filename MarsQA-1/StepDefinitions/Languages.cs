using MarsQA_1.Pages;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsQA_1
{
    [Binding]
    public class Languages
    {
        LanguagesPage languagesPageObj = new LanguagesPage();
        SkillsPage skillsPageObj = new SkillsPage();

        [Given(@"All the exsisting records should be cleared")]
        public void GivenAllTheExsistingRecordsShouldBeCleared()
        {
            languagesPageObj.ClearAllLanguageRecords();
            skillsPageObj.ClearAllSkillRecords();
        }

        [When(@"I add a new language record including '([^']*)' '([^']*)'")]
        public void WhenIAddANewLanguageRecordIncluding(string language, string languageLevel)
        {
            languagesPageObj.AddLanguage(language,languageLevel);
        }

        [Then(@"new language should save to the list including '([^']*)' '([^']*)'")]
        public void ThenNewLanguageShouldSaveToTheListIncluding(string language, string languageLevel)
        {
            Thread.Sleep(2000);
            Assert.That(languagesPageObj.PopUpMsg.Text == language + " has been added to your languages", "Language has not been added");
            Assert.AreEqual(language, languagesPageObj.LanguageLbl.Text, "Language has not been added");
            Assert.AreEqual(languageLevel, languagesPageObj.LanguageLevelLbl.Text, "Language level has not been added");
        }

        [Then(@"Add new button should not showing in the profile")]
        public void ThenAddNewButtonShouldNotShowingInTheProfile()
        {
            Thread.Sleep(2000);
            Boolean eleSelected = languagesPageObj.AddNewBtn.Displayed;
            Assert.IsFalse(eleSelected);
        }

        [When(@"I cancel adding language record")]
        public void WhenICancelAddingLanguageRecord()
        {
            languagesPageObj.CancelAddingLanuageRecord();
        }

        [Then(@"Adding new language should be cancel")]
        public void ThenAddingNewLanguageShouldBeCancel()
        {
            Assert.AreEqual(0, languagesPageObj.AddNewFields.Count, "Add new record fields are still appeared");
        }

        [Then(@"I edit an exsisting language including '([^']*)' '([^']*)'")]
        public void ThenIEditAnExsistingLanguageIncluding(string updatedLanguage, string updatedLanguageLevel)
        {
            languagesPageObj.EditLanguageRecord(updatedLanguage, updatedLanguageLevel);
        }

        [Then(@"Edited language should save to the list including '([^']*)' '([^']*)'")]
        public void ThenEditedLanguageShouldSaveToTheListIncluding(string updatedLanguage, string updatedLanguageLevel)
        {
            Thread.Sleep(2000);
            Assert.AreEqual(updatedLanguage + " has been updated to your languages", languagesPageObj.PopUpMsg.Text, "Language has not been edited");
            Assert.AreEqual(updatedLanguage,languagesPageObj.LanguageLbl.Text, "Language has not been edited");
            Assert.AreEqual(updatedLanguageLevel,languagesPageObj.LanguageLevelLbl.Text, "Language level has not been edited");
        }

        [Then(@"I delete an exsisting language record")]
        public void ThenUserDeleteAnExsistingLanguageRecord()
        {
            languagesPageObj.DeleteLanguageRecord();
        }

        [Then(@"The exsisting '([^']*)' language should delete from language records")]
        public void ThenTheExsistingLanguageShouldDeleteFromLanguageRecords(string language)
        {
            Thread.Sleep(3000);
            Assert.AreEqual(language + " has been deleted from your languages", languagesPageObj.PopUpMsg.Text, "Language has not been deleted");

        }

        [Then(@"Vaildation popup should appear as (.*)")]
        public void ThenVaildationPopupShouldAppearAs(string msg)
        {
            Thread.Sleep(2000);
            Assert.AreEqual(msg,languagesPageObj.PopUpMsg.Text, "Popup message is incorrect");
        }
    }
}
