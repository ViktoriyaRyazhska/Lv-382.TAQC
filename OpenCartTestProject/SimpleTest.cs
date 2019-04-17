using System;
using System.IO;
using System.Text;
using System.Threading;
using Allure.Commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace OpenCartTestProject
{
    [AllureNUnit]
    [AllureDisplayIgnored]
    //[TestClass]
    [TestFixture]
    public class SimpleTest
    {
        private const string FOLDER_BIN = "bin";
        private const string ALLURE_CONFIG = "allureConfig.json";
        //
        public static Logger log = LogManager.GetLogger("rolling0"); // nlog

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            log.Info("BeforeAllMethods() Start");
            //PrepareAllureConfig();
            log.Info("BeforeAllMethods() Done");
        }

        private void PrepareAllureConfig()
        {
            log.Debug("PrepareAllureConfig() Start");
            string runtimePath = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = runtimePath.Remove(runtimePath.IndexOf(FOLDER_BIN)) + ALLURE_CONFIG;
            log.Trace("runtimePath = " + runtimePath
                + "%n\t sourcePath = " + sourcePath
                + "%n\t runtimePath + ALLURE_CONFIG" + runtimePath + ALLURE_CONFIG);
            if (File.Exists(sourcePath))
            {
                if (File.Exists(runtimePath + ALLURE_CONFIG))
                {
                    File.Delete(runtimePath + ALLURE_CONFIG);
                }
                File.Copy(sourcePath, runtimePath + ALLURE_CONFIG);
                log.Trace("PrepareAllureConfig() Copy Done");
            }
            else
            {
                log.Warn("File " + sourcePath + " NOT FOUND.");
            }
            log.Debug("PrepareAllureConfig() Done");
        }

        //[TestMethod]
        //[Test]
        public void CheckLogin()
        {
            // Precondition
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
            driver.Navigate().GoToUrl("https://softserve.academy/");
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // Steps
            //driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.CssSelector(".login a[href*='login']")).Click();
            Thread.Sleep(1000); // For Presentation ONLY
            //
            // - - - - - - - - - - - - - - - - - - - -
            //
            //IWebElement username = driver.FindElement(By.Id("username"));
            //
            //username.Click();
            //username.Clear();
            //username.SendKeys("Hello Temp");
            //Thread.Sleep(2000); // For Presentation ONLY
            //
            // TODO new Code ...
            //
            //driver.Navigate().Refresh();
            //Thread.Sleep(2000); // For Presentation ONLY
            //
            //username.SendKeys(" new Hello");
            //Thread.Sleep(2000); // For Presentation ONLY
            //
            // - - - - - - - - - - - - - - - - - - - -
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello Temp");
            Thread.Sleep(2000); // For Presentation ONLY
            //
            // TODO new Code ...
            //
            driver.Navigate().Refresh();
            Thread.Sleep(2000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("username")).SendKeys(" new Hello");
            Thread.Sleep(2000); // For Presentation ONLY
            //
            // - - - - - - - - - - - - - - - - - - - -
            //
            //driver.FindElement(By.Id("username")).Click();
            //driver.FindElement(By.Id("username")).Clear();
            //driver.FindElement(By.Id("username")).SendKeys("Hello");
            //Thread.Sleep(2000); // For Presentation ONLY
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            //driver.FindElement(By.Id("password")).SendKeys("qwerty");
            string myPassword = Environment.GetEnvironmentVariable("MY_PASSWORD");
            Console.WriteLine("myPassword is: " + myPassword);
            driver.FindElement(By.Id("password")).SendKeys(myPassword);
            Thread.Sleep(2000); // For Presentation ONLY
            //
            driver.Quit();
        }

        //[Test]
        public void CheckScript()
        {
            // Precondition
            IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // by default 0
            //driver.Navigate().GoToUrl("https://softserve.academy/");
            driver.Navigate().GoToUrl("https://www.seleniumhq.org/download/");
            Thread.Sleep(2000); // For Presentation ONLY
            //
            // MoveToElement
            //Actions action = new Actions(driver);
            //action.MoveToElement(driver.FindElement(By.CssSelector("a[name='side_plugins'] h3"))).Perform();
            //action.MoveToElement(driver.FindElement(By.LinkText("Useful information"))).Perform();
            //action.MoveToElement(driver.FindElement(By.Id("instance-2797-header"))).Perform();
            //
            // Use JavaScript Injection
            //IWebElement clock = driver.FindElement(By.Id("instance-2797-header"));
            IWebElement clock = driver.FindElement(By.CssSelector("a[name='side_plugins'] h3"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //
            // Search WebElements
            //IWebElement clock = (IWebElement)js
            //    .ExecuteScript("return document.getElementsByName('side_plugins')[0];", new object[1] { "" });
            //Console.WriteLine("side_plugins TEXT: " + clock.Text);
            //
            // MoveToElement
            js.ExecuteScript("arguments[0].scrollIntoView(true);", clock);
            Thread.Sleep(2000);
            //
            //js.ExecuteScript("alert('Hello');");
            //Thread.Sleep(4000);
            //driver.SwitchTo().Alert().Accept();
            //
            // TakesScreenshot
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile("d:/Screenshot1.png", ScreenshotImageFormat.Png);
            Thread.Sleep(4000); // For Presentation ONLY
            //
            driver.Quit();
        }

        [Test]
        [AllureTag("Regression_Tag")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("HI-61")]
        [AllureTms("TMS-12")]
        [AllureOwner("User_Owner")]
        [AllureParentSuite("With_parameters_ParentSuite")]
        [AllureSuite("Passed_Suite")]
        [AllureSubSuite("NoAssert_SubSuite")]
        [AllureEpic("Retry_Epic")]
        [AllureFeature("RetrySmall_Feature")]
        [AllureLink("softserve_ITA_Link", "https://softserve.academy/")]
        public void SoftserveAcademy()
        {
            log.Info("SoftserveAcademy() Start");
            log.Info("ThreadID = " + Thread.CurrentThread.ManagedThreadId);
            //
            IWebDriver driver;
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // by default = 0
            //
            driver.Navigate().GoToUrl("https://softserve.academy/");
            Thread.Sleep(1000); // DO NOT USE
            //
            driver.FindElement(By.LinkText("Log in")).Click();
            Thread.Sleep(1000); // DO NOT USE
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello2");
            Thread.Sleep(2000); // DO NOT USE
            //
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("Hello");
            Thread.Sleep(2000); // DO NOT USE
            //
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(2000); // DO NOT USE
            //
            //
            ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            byte[] bytes = screenshot.AsByteArray;
            AllureLifecycle.Instance.AddAttachment("Screenshot_01", "image/png", bytes);
            Thread.Sleep(2000); // DO NOT USE
            //
            string htmlCode = driver.PageSource;
            bytes = Encoding.ASCII.GetBytes(htmlCode);
            AllureLifecycle.Instance.AddAttachment("HTML_Source", "text/plain", bytes);
            //
            string runtimePath = AppDomain.CurrentDomain.BaseDirectory;
            string file = File.ReadAllText(runtimePath + ALLURE_CONFIG);
            bytes = Encoding.ASCII.GetBytes(file);
            AllureLifecycle.Instance.AddAttachment("External_File_allureConfig.json", "text/plain", bytes);
            //
            //
            driver.Quit();
            log.Info("SoftserveAcademy() Done");
        }
    }
}
