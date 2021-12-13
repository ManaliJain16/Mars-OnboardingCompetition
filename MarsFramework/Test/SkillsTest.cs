using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class SkillsTest
    {
        [TestFixture]
        [Category("Task2")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void TestCreateShareSkill()
            {
                test = extentReport.StartTest("Create Share Skill");
                // enter share skills
                ShareSkill shareSkillObj = new ShareSkill();
                shareSkillObj.EnterShareSkill();

                // Assert title and description for the newly created skill
                ManageListings manageListingsObj = new ManageListings();
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath + "TestDataShareSkill.xlsx", "ShareSkill");
                var expectedTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                var expectedDescription = GlobalDefinitions.ExcelLib.ReadData(2, "Description");

                Assert.AreEqual(expectedTitle, manageListingsObj.getRowTitle(), "title didn't match");
                Assert.AreEqual(expectedDescription, manageListingsObj.getRowDescription(), "description didn't match");
            }

            [Test, Order(2)]
            public void TestEditListing()
            {
                test = extentReport.StartTest("Edit Listing");
                ManageListings manageListingObj = new ManageListings();
                manageListingObj.Listings();
                manageListingObj.EditListing();

                ShareSkill shareSkillObj = new ShareSkill();
                shareSkillObj.EditShareSkill();

                // Assert title and description for the updated skill
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath + "TestDataManageListings.xlsx", "ManageListings");
                var expectedTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                var expectedDescription = GlobalDefinitions.ExcelLib.ReadData(2, "Description");

                Assert.AreEqual(expectedTitle, manageListingObj.getRowTitle(), "title didn't match");
                Assert.AreEqual(expectedDescription, manageListingObj.getRowDescription(), "description didn't match");
            }

            [Test, Order(3)]
            public void TestDeleteListing()
            {
                test = extentReport.StartTest("Delete Listing");
                ManageListings manageListingObj = new ManageListings();
                manageListingObj.Listings();
                manageListingObj.DeleteListing();

                // Assert popup message
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath + "TestDataManageListings.xlsx", "ManageListings");
                var title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");

                var expectedMessage = title + " has been deleted";

                Assert.AreEqual(expectedMessage, manageListingObj.getPopUpText(), "popup text didn't match");
            }

        }
    }
}