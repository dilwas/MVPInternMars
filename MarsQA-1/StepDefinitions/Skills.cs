using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using System.Threading;
using System.Windows.Interop;
using TechTalk.SpecFlow;

namespace MarsQA_1
{
    [Binding]
    public class Skills
    {
        SkillsPage skillsPageObj = new SkillsPage();
        
        [When(@"I add a new skill record including '([^']*)' '([^']*)'")]
        public void WhenIAddANewSkillRecordIncluding(string skill, string skillLevel)
        {
           skillsPageObj.AddSkill(skill, skillLevel);
        }

        [Then(@"New skill should save to the list including '([^']*)' '([^']*)'")]
        public void ThenNewSkillShouldSaveToTheListIncluding(string skill, string skillLevel)
        {
            Thread.Sleep(2000);
            Assert.That(skillsPageObj.PopUpMsg.Text == skill + " has been added to your skills", "skill has not been added");
            Assert.AreEqual(skill,skillsPageObj.SkillLbl.Text, "skill has not been added");
            Assert.AreEqual(skillLevel,skillsPageObj.SkillLevelLbl.Text, "skill level has not been added");
        }

        [Then(@"All skills should save to the list including '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
        public void ThenAllSkillsShouldSaveToTheListIncluding(string skill1, string skilllevel1, string skill2, string skillLevel2, string skill3, string skillLevel3)
        {
            Thread.Sleep(2000);
            Assert.AreEqual(skill1,skillsPageObj.SkillLbl.Text, "First skill has not been added");
            Assert.AreEqual(skilllevel1,skillsPageObj.SkillLevelLbl.Text, "First skill level has not been added");
            Assert.AreEqual(skill2,skillsPageObj.SkillLbl2.Text, "Second skill has not been added");
            Assert.AreEqual(skillLevel2,skillsPageObj.SkillLevelLbl2.Text, "Second skill level has not been added");
            Assert.AreEqual(skill3,skillsPageObj.SkillLbl3.Text, "Third skill has not been added");
            Assert.AreEqual(skillLevel3,skillsPageObj.SkillLevelLbl3.Text, "Third skill level has not been added");
        }

        [When(@"I cancel adding skill record")]
        public void WhenICancelAddingSkillRecord()
        {
            skillsPageObj.CancelAddingSkillRecord();
        }

        [Then(@"Adding new skill should be cancel")]
        public void ThenAddingNewSkillShouldBeCancel()
        {
            Assert.AreEqual(0,skillsPageObj.AddNewFields.Count, "Add new record fields are still appeared");
        }

        [When(@"I edit an exsisting skill including '([^']*)' '([^']*)'")]
        public void WhenIEditAnExsistingSkillIncluding(string updatedSkill, string updatedSkillLevel)
        {
            skillsPageObj.EditSkillRecord(updatedSkill, updatedSkillLevel);
        }

        [Then(@"Edited skill should save to the list including '([^']*)' '([^']*)'")]
        public void ThenEditedSkillShouldSaveToTheListIncluding(string updatedSkill, string updatedSkillLevel)
        {
            Thread.Sleep(2000);
            Assert.AreEqual(updatedSkill + " has been updated to your skills",skillsPageObj.PopUpMsg.Text, "skill has not been edited");
            Assert.AreEqual(updatedSkill,skillsPageObj.SkillLbl.Text, "skill has not been edited");
            Assert.AreEqual(updatedSkillLevel,skillsPageObj.SkillLevelLbl.Text, "skill level has not been edited");
        }

        [When(@"I delete an exsisting skill record")]
        public void WhenIDeleteAnExsistingSkillRecord()
        {
            skillsPageObj.DeleteSkillRecord();
        }

        [Then(@"The exsisting '([^']*)' skill should delete from skill records")]
        public void ThenTheExsistingLanguageShouldDeleteFromLanguageRecords(string skill)
        {
            Thread.Sleep(3000);
            Assert.AreEqual(skill + " has been deleted", skillsPageObj.PopUpMsg.Text, "skill has not been deleted");
        }
    }
}
