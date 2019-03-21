using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenCart_Testing.Pages;

namespace OpenCart_Testing
{
    [TestFixture]
    public class TestRunner
    {
        protected IWebDriver driver;
        protected const int spanTime = 15;
        protected const int sleepTime = 2000;
         
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(spanTime); 
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
        [SetUp]
        public void BeforeAllTests()
        {
            driver.Navigate().GoToUrl("http://192.168.244.134/opencart/upload/");
        }


        public HomePage LoadApplication()
        {
            return new HomePage(driver);
        }
    }


}
