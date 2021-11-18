using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.IO;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extentReport;
        #endregion

        #region setup and tear down
        [OneTimeSetUp]
        public void SetUp()
        {
            #region Initialise Reports
            extentReport = new ExtentReports(ReportPath, true, DisplayOrder.OldestFirst);
            extentReport.LoadConfig(MarsResource.ReportXMLPath);
            #endregion
        }

        [SetUp]
        public void Inititalize()
        {
            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    GlobalDefinitions.wait(10);
                    break;

            }

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String imagePath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
            // test.Log(LogStatus.Info, "Image path: " + img);
            test.Log(LogStatus.Info, test.AddScreenCapture(imagePath));
            // end test. (Reports)
            extentReport.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            extentReport.Flush();
            // Close the driver :)            
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }
        #endregion

    }
}