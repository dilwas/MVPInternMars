using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace MarsQA_1.Pages
{
    public static class SkillsPage
    {
        private static IWebElement AddNewBtn => Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button'])[1]"));
        private static IWebElement AddSkillTxt => Driver.driver.FindElement(By.Name("name"));
        private static IWebElement SkillLevelDdn => Driver.driver.FindElement(By.Name("level"));
        private static IWebElement AddBtn => Driver.driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        private static IWebElement PopUpMsg => Driver.driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        private static IWebElement SkillLbl => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td"));
        private static IWebElement SkillLbl2 => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td"));
        private static IWebElement SkillLbl3 => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td"));
        private static IWebElement EditIcn => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement UpdateBtn => Driver.driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        private static IWebElement DeleteIcn => Driver.driver.FindElement(By.XPath("//i[@class='remove icon']"));
        private static IWebElement SkillLevelLbl => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        private static IWebElement SkillLevelLbl2 => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[2]"));
        private static IWebElement SkillLevelLbl3 => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[2]"));
        private static ReadOnlyCollection<IWebElement> SkillRecords => Driver.driver.FindElements(By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        private static IWebElement CancelBtn => Driver.driver.FindElement(By.XPath("//INPUT[@class='ui button'][@value='Cancel']"));
        private static ReadOnlyCollection<IWebElement> AddNewFields => Driver.driver.FindElements(By.XPath("//DIV[@class='fields']"));
        private static IWebElement SkillTab => Driver.driver.FindElement(By.XPath("//a[@data-tab='second']"));


        public static void ClearAllSkillRecords()
        {
            SkillTab.Click();

            //tbody count
            int records = SkillRecords.Count();
            Console.WriteLine(records);
            //loop first delete icon
            for (int i = 0; i < records; i = i + 1)
            {
                Console.WriteLine(i);
                DeleteIcn.Click();
                Thread.Sleep(2000);
            }
        }

        public static void AddSkill()
        {
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "skill");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(2, "Skill"));

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            AddBtn.Click();
        }

        public static void VerifySkillRecord()
        {
            Thread.Sleep(2000);
            Assert.That(PopUpMsg.Text == ExcelLibHelper.ReadData(2, "Skill") + " has been added to your skills", "skill has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Skill"), SkillLbl.Text, "skill has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Level"), SkillLevelLbl.Text, "skill level has not been added");
        }

        public static void AddSkillsByPassingANumber(int num)
        {
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Skill");
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(num + 1, "Skill"));

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(num + 1, "Level"));

            AddBtn.Click();
        }

        public static void VerifySkillsRecords()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Skill"), SkillLbl.Text, "First skill has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Level"), SkillLevelLbl.Text, "First skill level has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Skill"), SkillLbl2.Text, "Second skill has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Level"), SkillLevelLbl2.Text, "Second skill level has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(4, "Skill"), SkillLbl3.Text, "Third skill has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(4, "Level"), SkillLevelLbl3.Text, "Third skill level has not been added");
        }

        public static void AddNewSkillWithSpecialCharacters()
        {
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys("SQL!@#");

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue("Beginner");

            AddBtn.Click();
        }

        public static void VerifyNewSkillWithSpecialCharacters()
        {
            Thread.Sleep(2000);
            Assert.That(PopUpMsg.Text == "SQL!@# has been added to your skills", "skill has not been added");
            Assert.AreEqual("SQL!@#", SkillLbl.Text, "skill has not been added");
            Assert.AreEqual("Beginner", SkillLevelLbl.Text, "skill level has not been added");
        }

        public static void AddNewSkillWith100Characters()
        {
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys("QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12");

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue("Intermediate");

            AddBtn.Click();
        }

        public static void VerifyNewSkillWith100Characters()
        {
            Thread.Sleep(2000);
            Assert.That(PopUpMsg.Text == "QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12 has been added to your skills", "skill has not been added");
            Assert.AreEqual("QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12", SkillLbl.Text, "skill has not been added");
            Assert.AreEqual("Intermediate", SkillLevelLbl.Text, "skill level has not been added");
        }

        public static void CancelAddingSkillRecord()
        {
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Skill");
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(2, "Skill"));

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            CancelBtn.Click();
        }

        public static void VerifyCancelAddingSkillRecord()
        {
            Console.WriteLine(AddNewFields.Count);
            Assert.AreEqual(0, AddNewFields.Count, "Add new record fields are still appeared");
        }

        //Edit skill
        public static void EditSkillRecord()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            AddSkillTxt.Clear();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(3, "Skill"));
            UpdateBtn.Click();
        }

        public static void VerifyEditSkillRecord()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Skill") + " has been updated to your skills", PopUpMsg.Text, "skill has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Skill"), SkillLbl.Text, "skill has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Level"), SkillLevelLbl.Text, "skill level has not been edited");
        }

        public static void EditSkillLevel()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            var selectElement = new SelectElement(SkillLevelDdn);
            selectElement.SelectByValue(ExcelLibHelper.ReadData(3, "Level"));
            UpdateBtn.Click();
        }

        public static void VerifyEditSkillLevelRecord()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Skill") + " has been updated to your skills", PopUpMsg.Text, "skill has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Skill"), SkillLbl.Text, "skill has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Level"), SkillLevelLbl.Text, "skill level has not been edited");
        }

        public static void EditBothSkillAndSkillLevelRecord()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            AddSkillTxt.Clear();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(3, "Skill"));
            var selectElement = new SelectElement(SkillLevelDdn);
            selectElement.SelectByValue(ExcelLibHelper.ReadData(3, "Level"));
            UpdateBtn.Click();
        }

        public static void VerifyBothUpdatedSkillAndSkillLevelRecord()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Skill") + " has been updated to your skills", PopUpMsg.Text, "skill has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Skill"), SkillLbl.Text, "skill has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Level"), SkillLevelLbl.Text, "skill level has not been edited");
        }

        public static void DeleteSkillRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }

        public static void VerifyDeleteRecord()
        {
            Thread.Sleep(3000);
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Skill") + " has been deleted", PopUpMsg.Text, "skill has not been deleted");
        }

        public static void AddSkillWithoutSkillLevel()
        {
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Skill");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(2, "Skill"));
            AddBtn.Click();
        }

        public static void VerifyPopupMsg(string msg)
        {
            Thread.Sleep(2000);
            Assert.AreEqual(msg, PopUpMsg.Text, "Popup message is incorrect");
        }

        public static void AddSkillWithoutSkill()
        {
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Skill");
            Thread.Sleep(2000);
            AddNewBtn.Click();

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            AddBtn.Click();
        }

        public static void AddSkillWithoutSkillAndSkillLevel()
        {
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddBtn.Click();
        }

        public static void AddAnExistingSkill()
        {
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Skill");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(2, "Skill"));

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            AddBtn.Click();
        }

        public static void AddAnExistingSkillWithDifferentLevel()
        {
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Skill");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys(ExcelLibHelper.ReadData(2, "Skill"));

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(3, "Level"));

            AddBtn.Click();
        }
    }
}
