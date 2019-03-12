using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;


namespace OpencartTesting
{
    abstract public class TestRunner
    {
        protected string adminPageUrl = "http://192.168.204.128/opencart/upload/admin";
        protected string homePageUrl = "http://192.168.204.128/opencart/upload";

        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(homePageUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TestContext.CurrentContext.Result = " + TestContext.CurrentContext.Result.Message);

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory+ "../../ErrorLogs/Log.txt",
                    "TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace + "\n");
                string screenshot = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
                TakesScreenshot(AppDomain.CurrentDomain.BaseDirectory + "../../ErrorLogs/Screenshots/" + screenshot+".png");
                TakesSources("");
            }

            driver.Manage().Cookies.DeleteAllCookies();
        }

        protected void TakesScreenshot(string filePath)
        {
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