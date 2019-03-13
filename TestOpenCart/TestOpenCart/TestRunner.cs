﻿using System;
using System.IO;
using System.Threading;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://192.168.79.128/opencart/upload/");           
            driver.FindElement(By.CssSelector("#top-links .dropdown-toggle")).Click();
            driver.FindElement(By.CssSelector(("#top-links a[href*='account/login']"))).Click();
            driver.FindElement(By.Name("email")).SendKeys(adminName);
            driver.FindElement(By.Name("password")).SendKeys(adminPass + Keys.Enter);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
           driver.Quit();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TestContext.CurrentContext.Result = " + TestContext.CurrentContext.Result.Message);

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string failTime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "../../ErrorLogs/Log.txt",
                    failTime + "\nTestContext.CurrentContext.Result.StackTrace = " + TestContext.CurrentContext.Result.StackTrace + "\n");
                TakesScreenshot(AppDomain.CurrentDomain.BaseDirectory + "../../ErrorLogs/Screenshots/" + failTime + ".png");
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