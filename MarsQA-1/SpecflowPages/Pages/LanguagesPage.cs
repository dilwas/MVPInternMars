using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace MarsQA_1.Pages
{
    public class LanguagesPage : Driver
    {
        public IWebElement AddNewBtn => driver.FindElement(By.XPath("//DIV[@class='ui teal button '][text()='Add New']"));
        public IWebElement AddLanguageTxt => driver.FindElement(By.Name("name"));
        public IWebElement LanguageLevelDdn => driver.FindElement(By.Name("level"));
        public IWebElement AddBtn => driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement LanguageLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td"));
        public IWebElement EditIcn => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]/i"));
        public IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        public IWebElement DeleteIcn => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement LanguageLevelLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        public ReadOnlyCollection<IWebElement> LanguageRecords => driver.FindElements(By.XPath("//div[@data-tab='first']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//INPUT[@class='ui button'][@value='Cancel']"));
        public ReadOnlyCollection<IWebElement> AddNewFields => driver.FindElements(By.XPath("//DIV[@class='fields']"));
        public IWebElement LanguageTab => driver.FindElement(By.XPath("//a[@data-tab='first']"));

        public void ClearAllLanguageRecords()
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

        public void AddLanguage(string language, string languageLevel)
        {
            LanguageTab.Click();
            //ExcelLibHelper.PopulateInCollection(@"MarsQA-1\SpecflowTests\Data\Data.xlsx", "Language");
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddLanguageTxt.SendKeys(language);

            //create select element object 
            var selectElement = new SelectElement(LanguageLevelDdn);

            //select by value
            selectElement.SelectByValue(languageLevel);

            AddBtn.Click();
        }

        public void CancelAddingLanuageRecord()
        {
            LanguageTab.Click();
            Thread.Sleep(3000);
            AddNewBtn.Click();
            CancelBtn.Click();
        }

        //Edit language
        public void EditLanguageRecord(string updatedLanguage, string updatedLanguageLevel)
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            AddLanguageTxt.Clear();
            AddLanguageTxt.SendKeys(updatedLanguage);
            var selectElement = new SelectElement(LanguageLevelDdn);
            selectElement.SelectByValue(updatedLanguageLevel);
            UpdateBtn.Click();
        }

        public void DeleteLanguageRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }
    }
}
