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
    public static class LanguagesPage
    {
        private static IWebElement AddNewBtn => Driver.driver.FindElement(By.XPath("//DIV[@class='ui teal button '][text()='Add New']"));
        private static IWebElement AddLanguageTxt => Driver.driver.FindElement(By.Name("name"));
        private static IWebElement LanguageLevelDdn => Driver.driver.FindElement(By.Name("level"));
        private static IWebElement AddBtn => Driver.driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        private static IWebElement PopUpMsg => Driver.driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        private static IWebElement LanguageLbl => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td"));
        private static IWebElement EditIcn => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]/i"));
        private static IWebElement UpdateBtn => Driver.driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        private static IWebElement DeleteIcn => Driver.driver.FindElement(By.XPath("//i[@class='remove icon']"));
        private static IWebElement LanguageLevelLbl => Driver.driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        private static ReadOnlyCollection<IWebElement> LanguageRecords => Driver.driver.FindElements(By.XPath("//div[@data-tab='first']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        private static IWebElement CancelBtn => Driver.driver.FindElement(By.XPath("//INPUT[@class='ui button'][@value='Cancel']"));
        private static ReadOnlyCollection<IWebElement> AddNewFields => Driver.driver.FindElements(By.XPath("//DIV[@class='fields']"));
        private static IWebElement LanguageTab => Driver.driver.FindElement(By.XPath("//a[@data-tab='first']"));

        public static void ClearAllLanguageRecords()
        {
            //tbody count
            int records = LanguageRecords.Count();
            Console.WriteLine(records);
            //loop first delete icon
            for (int i = 0; i < records; i = i + 1)
            {
                Console.WriteLine(i);
                DeleteIcn.Click();
                Thread.Sleep(2000);
            }
        }

        public static void AddLanguage()
        {
            LanguageTab.Click();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(2, "Language"));

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            AddBtn.Click();
        }

        public static void VerifyLanguageRecord()
        {
            Thread.Sleep(2000);
            Assert.That(PopUpMsg.Text == ExcelLibHelper.ReadData(2, "Language") + " has been added to your languages", "Language has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Language"), LanguageLbl.Text, "Language has not been added");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Level"), LanguageLevelLbl.Text, "Language level has not been added");
        }

        public static void AddLanguagesByPassingANumber(int num)
        {
            LanguageTab.Click();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(num + 1, "Language"));

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(num + 1, "Level"));

            AddBtn.Click();
        }

        public static void VerifyAddNewButtonIsNotDisplay()
        {
            Thread.Sleep(2000);
            Boolean eleSelected = AddNewBtn.Displayed;
            Assert.IsFalse(eleSelected);
        }


        public static void AddNewLanguageWithSpecialCharacters()
        {
            LanguageTab.Click();
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys("Sinhala!@#");

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue("Basic");

            AddBtn.Click();
        }

        public static void VerifyNewLanguageWithSpecialCharacters()
        {
            Thread.Sleep(2000);
            Assert.That(PopUpMsg.Text == "Sinhala!@# has been added to your languages", "Language has not been added");
            Assert.AreEqual("Sinhala!@#", LanguageLbl.Text, "Language has not been added");
            Assert.AreEqual("Basic", LanguageLevelLbl.Text, "Language level has not been added");
        }

        public static void AddNewLanguageWith100Characters()
        {
            LanguageTab.Click();
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys("QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12");

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue("Fluent");

            AddBtn.Click();
        }

        public static void VerifyNewLanguageWith100Characters()
        {
            Thread.Sleep(2000);
            Assert.That(PopUpMsg.Text == "QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12 has been added to your languages", "Language has not been added");
            Assert.AreEqual("QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM1234567890QWERTYUIOPASDFGHJKLZXCVBNM12", LanguageLbl.Text, "Language has not been added");
            Assert.AreEqual("Fluent", LanguageLevelLbl.Text, "Language level has not been added");
        }

        public static void CancelAddingLanuageRecord()
        {
            LanguageTab.Click();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(3000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(2, "Language"));

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            CancelBtn.Click();
        }

        public static void VerifyCancelAddingLanuageRecord()
        {
            Console.WriteLine(AddNewFields.Count);
            Assert.AreEqual(0, AddNewFields.Count, "Add new record fields are still appeared");
        }

        //Edit language
        public static void EditLanguageRecord()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            AddLanguageTxt.Clear();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(3, "Language"));
            UpdateBtn.Click();
        }

        public static void VerifyEditLanguageRecord()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Language") + " has been updated to your languages", PopUpMsg.Text, "Language has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Language"), LanguageLbl.Text, "Language has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Level"), LanguageLevelLbl.Text, "Language level has not been edited");
        }

        public static void EditLanguageLevel()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            var selectElement = new SelectElement(LanguageLevelDdn);
            selectElement.SelectByValue(ExcelLibHelper.ReadData(3, "Level"));
            UpdateBtn.Click();
        }

        public static void VerifyEditLanguageLevelRecord()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Language") + " has been updated to your languages", PopUpMsg.Text, "Language has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Language"), LanguageLbl.Text, "Language has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Level"), LanguageLevelLbl.Text, "Language level has not been edited");
        }

        public static void EditBothLanguageAndLanguageLevelRecord()
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            AddLanguageTxt.Clear();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(3, "Language"));
            var selectElement = new SelectElement(LanguageLevelDdn);
            selectElement.SelectByValue(ExcelLibHelper.ReadData(3, "Level"));
            UpdateBtn.Click();
        }

        public static void VerifyBothUpdatedLanguageAndLanguageLevelRecord()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Language") + " has been updated to your languages", PopUpMsg.Text, "Language has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Language"), LanguageLbl.Text, "Language has not been edited");
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Level"), LanguageLevelLbl.Text, "Language level has not been edited");
        }

        public static void DeleteLanguageRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }

        public static void VerifyDeleteRecord()
        {
            Thread.Sleep(3000);
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Language") + " has been deleted from your languages", PopUpMsg.Text, "Language has not been deleted");
        }

        public static void AddLanguageWithoutLanguageLevel()
        {
            LanguageTab.Click();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(2, "Language"));
            AddBtn.Click();
        }

        public static void VerifyPopupMsg(string msg)
        {
            Thread.Sleep(2000);
            Assert.AreEqual(msg, PopUpMsg.Text, "Popup message is incorrect");
        }

        public static void AddLanguageWithoutLanguage()
        {
            LanguageTab.Click();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(2000);
            AddNewBtn.Click();

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            AddBtn.Click();
        }

        public static void AddLanguageWithoutLanguageAndLanguageLevel()
        {
            LanguageTab.Click();
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddBtn.Click();
        }

        public static void AddAnExistingLanguage()
        {
            LanguageTab.Click();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(2, "Language"));

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(2, "Level"));

            AddBtn.Click();
        }

        public static void AddAnExistingLanguageWithDifferentLevel()
        {
            LanguageTab.Click();
            ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys(ExcelLibHelper.ReadData(2, "Language"));

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue(ExcelLibHelper.ReadData(3, "Level"));

            AddBtn.Click();
        }
    }
}
