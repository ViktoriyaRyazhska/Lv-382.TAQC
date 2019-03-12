using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace OpenCartTestProject
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();          
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://taqc-opencart.epizy.com/");
        }

        [TearDown]
        //public void TearDown(ITestResult testResult)
        public void TearDown()
        {
            Console.WriteLine("TestContext.CurrentContext.Result = " + TestContext.CurrentContext.Result.Message);
            //if (testResult.ResultState.Status == TestStatus.Failed)
            //if (TestContext.CurrentContext.Result.Message.Length > 0)
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // TODO Save to File
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                // TODO Choose filename
                TakesScreenshot("d:/Screenshot12.png");
                TakesSources("");
                // Logout
                // Clear Cache
                //driver.Navigate().GoToUrl("http://taqc-opencart.epizy.com/");
            }
        }

        protected void TakesScreenshot(string filePath)
        {
            // TSave Screenshot
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }

        protected void TakesSources(string filePath)
        {
            // Save Sources
        }

    }
}
