using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTesting
{
    abstract public class TestRunner
    {
        protected string adminPageUrl = "http://192.168.150.131/opencart/upload/admin";
        protected string homePageUrl = "http://192.168.150.131/opencart/upload/index.php?route=product/search";

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
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "../../ErrorLogs/Log.txt",
                    "TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace + "\n");
                string screenshot = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                TakesScreenshot(AppDomain.CurrentDomain.BaseDirectory + "../../ErrorLogs/Screenshots/" + screenshot + ".png");
            }

            driver.Manage().Cookies.DeleteAllCookies();
        }

        protected void TakesScreenshot(string filePath)
        {
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }
    }  
}
