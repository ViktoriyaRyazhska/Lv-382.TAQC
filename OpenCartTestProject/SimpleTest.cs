using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartTestProject
{
    //[TestClass]
    [TestFixture]
    public class SimpleTest
    {
        //[TestMethod]
        [Test]
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
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
            Thread.Sleep(2000); // For Presentation ONLY
            //
            driver.Quit();
        }
    }
}
