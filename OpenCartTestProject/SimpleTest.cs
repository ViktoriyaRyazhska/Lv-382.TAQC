using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace OpenCartTestProject
{
    //[TestClass]
    [TestFixture]
    public class SimpleTest
    {
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
            driver.FindElement(By.Id("password")).SendKeys("qwerty");
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
    }
}
