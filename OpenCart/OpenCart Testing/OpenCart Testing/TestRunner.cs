using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace OpenCart_Testing
{
    public class TestRunner
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); 
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        public void LoginProcess(string user_email, string user_password)
        {
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.CssSelector("a[href*='account/login']")).Click(); ;
            driver.FindElement(By.Id("input-email")).SendKeys(Environment.GetEnvironmentVariable(user_email));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable(user_password));
            driver.FindElement(By.XPath("//input[contains(@type, 'submit')]")).Click();
        }

        public void LogoutProcess()
        {
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.CssSelector("a[href*='account/logout']")).Click();
            driver.FindElement(By.CssSelector("a[href*='common/home']")).Click();
        }

        public void PasswordChangeProcess(string new_password)
        {
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable(new_password));
            driver.FindElement(By.Id("input-confirm")).SendKeys(Environment.GetEnvironmentVariable(new_password) + Keys.Enter);
        }
    }


}
