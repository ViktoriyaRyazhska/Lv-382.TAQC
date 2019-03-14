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
    abstract public class TestRuner
    {
        protected IWebDriver driver;
        protected string urlForAdminPage = "http://192.168.85.129/opencart/upload/admin";
        protected string urlForMainPage = "http://192.168.85.129/opencart/upload";
        protected string tokenHttp;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(urlForAdminPage);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("adminLogin"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("adminPassword"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            tokenHttp = driver.Url;
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(tokenHttp);
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

            //driver.Manage().Cookies.DeleteAllCookies();
        }

        protected void TakesScreenshot(string filePath)
        {
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }
    }
}
