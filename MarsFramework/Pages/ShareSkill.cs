using System.Collections.Generic;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")] 
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //TODO: Learn to create 
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']/div[@class='ui radio checkbox']/input[@name='serviceType']")]
        private IList<IWebElement> ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']/div[@class='ui radio checkbox']/input[@name='locationType']")]
        private IList<IWebElement> LocationTypeOptions { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }
         
        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//input[@name='Available']")]
        private IList<IWebElement> Days { get; set; }
        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']/div[@class='ui radio checkbox']/input[@name='skillTrades']")]
        private IList<IWebElement> SkillTradeOptions { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit......name Charge
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']/div[@class='ui radio checkbox']/input[@name='isActive']")]
        private IList<IWebElement> ActiveOptions { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath + "TestDataShareSkill.xlsx", "ShareSkill");
            ShareSkillButton.Click();
            enterTitle();
            enterDescription();
            enterCategorySubCategory();
            enterTags();
            selectServiceType();
            selectLocationType();
            enterStartDateEndDate();
            selectDaysEnterStartAndEndTime();
            selectSkillTrade();
            enterSkillExchange();
            selectActiveOrHidden();

            // Save
            Save.Click();
        }

        internal void EditShareSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath + "TestDataManageListings.xlsx", "ManageListings");

            // enter updated values
            enterTitle();
            enterDescription();
            enterCategorySubCategory();
            enterTags();
            selectServiceType();
            selectLocationType();
            enterStartDateEndDate();
            selectDaysEnterStartAndEndTime();
            selectSkillTrade();
            enterCredit();
            selectActiveOrHidden();

            Save.Click();
        }

        private void enterTitle()
        {
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
        }

        private void enterDescription()
        {
            Description.Clear();
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
        }

        private void enterCategorySubCategory()
        {
            var newCategorySelect = new SelectElement(CategoryDropDown);
            newCategorySelect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            var newSubCategorySelect = new SelectElement(SubCategoryDropDown);
            newSubCategorySelect.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));
        }

        private void enterTags()
        {
            //Tag remoe 
            //var TagToDelete = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span[text()='ab']/a"));
            //TagToDelete.Click();
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags") + Keys.Return);
        }

        private void selectServiceType()
        {
            // service type
            if ("Hourly basis service".Equals(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")))
            {
                ServiceTypeOptions[0].Click();
            }
            else
            {
                ServiceTypeOptions[1].Click();
            }
        }

        private void selectLocationType()
        {
            // Location Type
            if ("On-site".Equals(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")))
            {
                LocationTypeOptions[0].Click();
            }
            else
            {
                LocationTypeOptions[1].Click();
            }
        }

        private void enterStartDateEndDate()
        {
            StartDateDropDown.Clear();
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            EndDateDropDown.Clear();
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));
        }

        private void selectDaysEnterStartAndEndTime()
        {
            switch (GlobalDefinitions.ExcelLib.ReadData(2, "Selectday"))
            {
                case "Sun":
                    Days[0].Click();
                    enterStartTimeAndEndTime(2);
                    break;
                case "Mon":
                    Days[1].Click();
                    enterStartTimeAndEndTime(3);
                    break;
                case "Tue":
                    Days[2].Click();
                    enterStartTimeAndEndTime(4);
                    break;
                case "Wed":
                    Days[3].Click();
                    enterStartTimeAndEndTime(5);
                    break;
                case "Thu":
                    Days[4].Click();
                    enterStartTimeAndEndTime(6);
                    break;
                case "Fri":
                    Days[5].Click();
                    enterStartTimeAndEndTime(7);
                    break;
                case "Sat":
                    Days[6].Click();
                    enterStartTimeAndEndTime(8);
                    break;
            }
        }

        private static void enterStartTimeAndEndTime(int dayDiv)
        {
            var startTime = GlobalDefinitions.driver.FindElement(By.XPath("//div["+dayDiv+"]/div[2]/input[1]"));
            startTime.Clear();
            startTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
            var endTime = GlobalDefinitions.driver.FindElement(By.XPath("//div[" + dayDiv + "]/div[3]/input[1]"));
            endTime.Clear();
            endTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
        }

        private void selectSkillTrade()
        {
            // Skill Trade
            if ("Skill-Exchange".Equals(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")))
            {
                SkillTradeOptions[0].Click();
            }
            else
            {
                SkillTradeOptions[1].Click();
            }
        }

        private void enterSkillExchange()
        {
            // Skill Exchange
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange") + Keys.Return);
        }

        private void enterCredit()
        {
            // Skill Exchange
            CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit") + Keys.Return);
        }

        private void selectActiveOrHidden()
        {
            // Active or Hidden
            if ("Active".Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Active")))
            {
                ActiveOptions[0].Click();
            }
            else
            {
                ActiveOptions[1].Click();
            }
        }
    }
}
