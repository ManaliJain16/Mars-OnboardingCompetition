using System.Collections.Generic;
using System.Threading;
using MarsFramework.Global;
using MarsFramework.Utils;
using NUnit.Framework;
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


        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }


        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']/button")]
        private IList<IWebElement> clickActionButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement PopUp { get; set; }

        [FindsBy(How =How.XPath, Using = "//table[@class='ui striped table']/tbody/tr[1]/td[3]")]
        private IWebElement RowTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='ui striped table']/tbody/tr[1]/td[4]")]
        private IWebElement RowDescription { get; set; }

        internal void Listings()
        {
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
        }

        public void verifyPopUpMessage(string message)
        {
            Wait.waitForElementToBeVisible(GlobalDefinitions.driver, LocatorType.XPath, "//*[@class='ns-box-inner']", 2);
            Assert.AreEqual(message, PopUp.Text, "popup text didn't match");
        }

        public void verifyRowData(string title, string description)
        {
            Wait.waitForElementExists(GlobalDefinitions.driver, LocatorType.XPath, "//table[@class='ui striped table']/tbody/tr[1]/td[3]", 2);
            Assert.AreEqual(title, RowTitle.Text, "title didn't match");
            Assert.AreEqual(description, RowDescription.Text, "description didn't match");
        }
    }
}
