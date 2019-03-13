using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace TestOpenCart
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        static readonly string adminName = Environment.GetEnvironmentVariable("adminName", EnvironmentVariableTarget.User).ToString();
        static readonly string adminPass = Environment.GetEnvironmentVariable("adminPass", EnvironmentVariableTarget.User).ToString();


        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
            driver.Navigate().GoToUrl("http://192.168.79.128/opencart/upload/");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#top-links .dropdown-toggle")).Click();
            driver.FindElement(By.CssSelector(("#top-links a[href*='account/login']"))).Click();
            driver.FindElement(By.Name("email")).SendKeys(adminName);
            driver.FindElement(By.Name("password")).SendKeys(adminPass + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TestContext.CurrentContext.Result = " + NUnit.Framework.TestContext.CurrentContext.Result.Message);
            if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("TestContext.CurrentContext.Result.StackTrace = " + NUnit.Framework.TestContext.CurrentContext.Result.StackTrace);
                TakesScreenshot("d:/Screenshot12.png");
                TakesSources("");
            }
        }
        protected void TakesScreenshot(string filePath)
        {
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }

        protected void TakesSources(string filePath)
        {

        }
    }
}
