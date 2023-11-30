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
    public class SkillsPage : Driver
    {
        public IWebElement AddNewBtn => driver.FindElement(By.XPath("(//div[@class='ui teal button'])[1]"));
        public IWebElement AddSkillTxt => driver.FindElement(By.Name("name"));
        public IWebElement SkillLevelDdn => driver.FindElement(By.Name("level"));
        public IWebElement AddBtn => driver.FindElement(By.XPath("//INPUT[@value='Add']"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement SkillLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td"));
        public IWebElement SkillLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td"));
        public IWebElement SkillLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td"));
        public IWebElement EditIcn => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[3]/span[1]/i"));
        public IWebElement UpdateBtn => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        public IWebElement DeleteIcn => driver.FindElement(By.XPath("//i[@class='remove icon']"));
        public IWebElement SkillLevelLbl => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[2]"));
        public IWebElement SkillLevelLbl2 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[2]/tr/td[2]"));
        public IWebElement SkillLevelLbl3 => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody[3]/tr/td[2]"));
        public ReadOnlyCollection<IWebElement> SkillRecords => driver.FindElements(By.XPath("//div[@data-tab='second']/div/div[2]/div/table[@class='ui fixed table']/tbody"));
        public IWebElement CancelBtn => driver.FindElement(By.XPath("//INPUT[@class='ui button'][@value='Cancel']"));
        public ReadOnlyCollection<IWebElement> AddNewFields => driver.FindElements(By.XPath("//DIV[@class='fields']"));
        public IWebElement SkillTab => driver.FindElement(By.XPath("//a[@data-tab='second']"));

        public void ClearAllSkillRecords()
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

        public void AddSkill(string skill, string skillLevel)
        {
            Thread.Sleep(2000);
            AddNewBtn.Click();
            AddSkillTxt.SendKeys(skill);

            //create select element object 
            var selectElement = new SelectElement(SkillLevelDdn);

            //select by value
            selectElement.SelectByValue(skillLevel);

            AddBtn.Click();
        }

        public void CancelAddingSkillRecord()
        {
            Thread.Sleep(3000);
            AddNewBtn.Click();
            CancelBtn.Click();
        }

        //Edit skill
        public void EditSkillRecord(string updatedSkill, string updatedSkillLevel)
        {
            Thread.Sleep(1000);
            EditIcn.Click();
            AddSkillTxt.Clear();
            AddSkillTxt.SendKeys(updatedSkill);
            var selectElement = new SelectElement(SkillLevelDdn);
            selectElement.SelectByValue(updatedSkillLevel);
            UpdateBtn.Click();
        }

        public void DeleteSkillRecord()
        {
            Thread.Sleep(3000);
            DeleteIcn.Click();
        }
    }
}
