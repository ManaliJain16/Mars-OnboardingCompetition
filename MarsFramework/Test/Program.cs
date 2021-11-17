using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test, Order(1)]
            public void TestCreateShareSkill()
            {
                // enter share skills
                ShareSkill shareSkillObj = new ShareSkill();
                shareSkillObj.EnterShareSkill();
            }

            [Test, Order(2)]
            public void TestEditListing()
            {
                ManageListings manageListingObj = new ManageListings();
                manageListingObj.Listings();
                manageListingObj.EditListing();

                ShareSkill shareSkillObj = new ShareSkill();
                shareSkillObj.EditShareSkill();
            }

            [Test, Order(3)]
            public void TestDeleteListing()
            {
                ManageListings manageListingObj = new ManageListings();
                manageListingObj.Listings();
                manageListingObj.DeleteListing();

                // TODO: popup
                  

            }

        }
    }
}