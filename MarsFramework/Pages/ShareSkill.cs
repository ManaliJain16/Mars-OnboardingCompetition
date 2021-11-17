using System.Collections.Generic;
using System.Threading;
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

        //Enter Tag names in textbox
        // If full tag than can we use LinkText
        //[FindsBy(How = How.LinkText, Using = "Tags")]

        //TODO: Learn to create 
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Tag to delete
        //[FindsBy(How = How.XPath, Using = "  //*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span[contains(@text,'ab')]/a")]
        //private IWebElement TagToDelete { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']/div[@class='ui radio checkbox']/input[@name='serviceType']")]
        private IList<IWebElement> ServiceTypeOptions { get; set; }

        ////Select Hourly basis service --- Value 0,1
        //[FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        //private IWebElement HourlyBasisService { get; set; }

        ////Select One-off service
        //[FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        //private IWebElement OneOffService { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']/div[@class='ui radio checkbox']/input[@name='locationType']")]
        private IList<IWebElement> LocationTypeOptions { get; set; }

        ////Select the Location Type -- Value 0,1
        //[FindsBy(How = How.XPath, Using = "//*[@id="service-listing-section"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        //private IWebElement LocationTypeOption { get; set; }

        ////Select the Location Type
        //[FindsBy(How = How.XPath, Using = "//*[@id="service-listing-section"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        //private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }
         
        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//input[@name='Available']")]
        private IList<IWebElement> Days { get; set; }

 

        //Can we do FindElements...for all the Checkboxes for the Days       //Storing the starttime......//*[@id="service-listing-section"]/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown.....name EndTime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

       //Click on Skill Trade option.....//*[@id="service-listing-section"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/label
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']/div[@class='ui radio checkbox']/input[@name='skillTrades']")]
        private IList<IWebElement> SkillTradeOptions { get; set; }

        //Enter Skill Exchange.....//*[@id="service-listing-section"]/div[2]/div/form/div[8]/div[4]/div/div
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Select Credit option ...//*[@id="service-listing-section"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input

        //Enter the amount for Credit......name Charge
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //select + plus... //*[@id="service-listing-section"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i

        //Select Active....//*[@id="service-listing-section"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input

        //Select Hidden ....//*[@id="service-listing-section"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/label

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']/div[@class='ui radio checkbox']/input[@name='isActive']")]
        private IList<IWebElement> ActiveOptions { get; set; }

        //TODO: Save & cancel----- Value Save/Cancel

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill()
        {
            ShareSkillButton.Click();
            Title.SendKeys("QA");
            Description.SendKeys("MJ");

            var categorySelect = new SelectElement(CategoryDropDown);
            categorySelect.SelectByText("Digital Marketing");
            
            var subCategorySelect = new SelectElement(SubCategoryDropDown);
            subCategorySelect.SelectByText("Video Marketing");

            Tags.SendKeys("ab"+ Keys.Return);
            Tags.SendKeys("cd" + Keys.Return);

            // click on second service type option
            ServiceTypeOptions[1].Click();

            LocationTypeOptions[0].Click();
            StartDateDropDown.Click();
            EndDateDropDown.Click();
            Days[0].Click();
            Days[1].Click();
            StartTime.Click();
            StartTimeDropDown.Click();
            EndTimeDropDown.Click();
            SkillTradeOptions[0].Click();
            SkillExchange.SendKeys("X" + Keys.Return);
            ActiveOptions[0].Click();
            Save.Click();
        }

        internal void EditShareSkill()
        {
            Title.Clear();
            Title.SendKeys("Fuge1");

            Description.Clear();
            Description.SendKeys("abc");

            var newcategorySelect = new SelectElement(CategoryDropDown);
            newcategorySelect.SelectByText("Music & Audio");

            var subCategorySelect = new SelectElement(SubCategoryDropDown);
            subCategorySelect.SelectByText("Other");

            //Tag remoe 
            var TagToDelete = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/span[text()='ab']/a"));
            TagToDelete.Click();
            Tags.SendKeys("oo" + Keys.Return);



            //Which radio button in service and location
            // if first ooption is selected, click on second option and vice versa
            //ServiceTypeOptions[1].Click();
            if (ServiceTypeOptions[0].Selected)
            {
                ServiceTypeOptions[1].Click();
            }
            else
            {
                ServiceTypeOptions[0].Click();
            }
            Thread.Sleep(1000);


            //ServiceTypeOptions.Click();
            LocationTypeOptions[1].Click();

            StartDateDropDown.SendKeys("20112021");

            EndDateDropDown.SendKeys("24112021");


            //Which days
            // Unselect Sunday
            if(Days[0].Selected)
            {
                Days[0].Click();
            }
            // select Wednesday
            if(!Days[4].Selected)
            {
                Days[4].Click();
            }
             
            SkillTradeOptions[1].Click();
           //how Credit radio button  
            CreditAmount.Clear();
            CreditAmount.SendKeys("6");


            Save.Click();
        }
    }
}
