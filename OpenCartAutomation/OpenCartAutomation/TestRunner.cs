using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartAutomation
{
    [TestFixture]
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        [OneTimeSetUp]
        protected virtual void BeforeAllTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        [OneTimeTearDown]
        protected virtual void AfterAllTests()
        {
            driver.Quit();
        }
        [SetUp]
        protected virtual void BeforeEachTest()
        {
            driver.Navigate().GoToUrl("http://192.168.244.134/opencart/upload/");
        }
        [TearDown]
        protected virtual void AfterEachTest()
        {
            Console.WriteLine("TestContext.CurrentContext.Result = " + TestContext.CurrentContext.Result.Message);
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace);
                TakesScreenshot($"C:/Users/Lutik/Desktop/SoftServe/{TestContext.CurrentContext.Result}.png");
            }
        }
        protected void TakesScreenshot(string filePath)
        {
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }
    }
}
