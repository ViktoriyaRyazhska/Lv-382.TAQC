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
        protected const string adminPageUrl = "http://192.168.204.128/opencart/upload/admin";
        protected const string homePageUrl = "http://192.168.204.128/opencart/upload";

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
                string failTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory+ "../../ErrorLogs/Log.txt",
                    failTime + "\nTestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace + "\n");
                TakesScreenshot(AppDomain.CurrentDomain.BaseDirectory + "../../ErrorLogs/Screenshots/" + failTime +".png");
                TakesSources(failTime);
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
            File.Copy(AppDomain.CurrentDomain.BaseDirectory + "../../OpencartTest.cs",
                AppDomain.CurrentDomain.BaseDirectory + "../../ErrorLogs/Source/"+filePath+".cs");
        }

        protected bool hasClass(IWebElement element, string searchedClass)
        {
            string[] classes = element.GetAttribute("class").Split(' ');
            foreach (string str in classes)
            {
                if (str.Equals(searchedClass))
                {
                    return true;
                }
            }
            return false;
        }
    }
}