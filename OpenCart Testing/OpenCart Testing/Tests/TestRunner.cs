using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.AccountPages;

namespace OpenCart_Testing
{
    [TestFixture]
    public class TestRunner
    {
        protected IWebDriver driver;
        protected const int spanTime = 2;
        protected const int sleepTime = 2000;


        protected string baseUrl = "http://192.168.150.137/opencart/upload/";

        //protected string baseUrl = "http://taqc-opencart.epizy.com/";
        protected User REGISTERED = new User(Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL"), Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD"));




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
            driver.Navigate().GoToUrl(baseUrl);
        }

        public HomePage LoadApplication()
        {
            return new HomePage(driver);
        }

    }
}
