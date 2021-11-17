using System.Collections.Generic;
using System.Threading;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }


        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }


        //Delete the listing...
        // For delete this can be used as the XPath ---> (//i[@class='remove icon'])[1]
        //tbody/div[contains(@class,'ui small icon buttons basic vertical')]/i[@class='remove icon']
        //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }


        //Click on Yes or No
        //For No button ----> //*[@class='ui negative button']
        //For Yes button ---> //*[@class='ui icon positive right labeled button']
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']/button")]
        private IList<IWebElement> clickActionButtons { get; set; }

        internal void Listings()
        {
            //Populate the Excel Sheet
            // GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            manageListingsLink.Click();
            
        }

        internal void EditListing()
        {
            edit.Click();
        }

        internal void DeleteListing()
        {
            delete.Click();
            Thread.Sleep(1000);

            clickActionButtons[1].Click();

           //Managing Popup
           // GlobalDefinitions.driver.SwitchTo().Alert().Accept();

        }
    }
}
