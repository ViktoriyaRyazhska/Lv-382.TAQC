using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCart_Testing
{

    [TestClass]
    public class OpenCartAutomationTests : TestRunner
    {
        [Test]
        public void ChangePasswordPositiveTest()
        {
            driver.Navigate().GoToUrl("http://192.168.19.131/opencart/upload/index.php");
            LoginProcess("UserEmail", "UserPassword");
            //Password changing process
            driver.FindElement(By.CssSelector("a[href*='account/password']")).Click();
            Thread.Sleep(1000); //For presentation only
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("NewPassword"));
            Thread.Sleep(1000); //For presentation only
            driver.FindElement(By.Id("input-confirm")).SendKeys(Environment.GetEnvironmentVariable("NewPassword") + Keys.Enter);
            //Checking the password change
            LogoutProcess();
            LoginProcess("UserEmail", "UserPassword");
            LogoutProcess();
        }

        [Test]
        public void ChangePasswordNegativeTest()
        {
            driver.Navigate().GoToUrl("http://192.168.19.131/opencart/upload/index.php");
            LoginProcess("UserEmail", "UserPassword");
            //Password changing process
            driver.FindElement(By.CssSelector("a[href*='account/password']")).Click();
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("UserPassword"));
            driver.FindElement(By.Id("input-confirm")).SendKeys("Wrong Confirm Password" + Keys.Enter);
            LogoutProcess();
            //Check absence of password reset
            LoginProcess("UserEmail", "UserPassword"); //Log in with old password
            LogoutProcess();
        }

        [Test]
        public void RestorePasswordTest()
        {
            driver.Navigate().GoToUrl("http://taqc-opencart.epizy.com/index.php");
            driver.FindElement(By.ClassName("caret")).Click();
            driver.FindElement(By.CssSelector("a[href*='account/login']")).Click();
            driver.FindElement(By.CssSelector("a[href*='account/forgotten']")).Click();
            //Recovery request sending
            driver.FindElement(By.Id("input-email")).SendKeys(Environment.GetEnvironmentVariable("TestingEmail") + Keys.Enter);
            //Mail checking process
            driver.Navigate().GoToUrl("https://mail.ukr.net");
            driver.FindElement(By.Id("id-l")).SendKeys(Environment.GetEnvironmentVariable("TestingEmail"));
            driver.FindElement(By.Id("id-p")).SendKeys(Environment.GetEnvironmentVariable("UserPassword")  + Keys.Enter);
            driver.FindElement(By.Id("unread")).Click();
            //Reloading the page until the letter is received
            //Wrong
            while (!driver.FindElement(By.ClassName("msglist__row_href")).Displayed) 
            {
                Thread.Sleep(7000);
                driver.Navigate().Refresh();
            }
            driver.FindElement(By.ClassName("msglist__row_href")).Click();
            driver.FindElement(By.XPath("//a[@rel='noreferrer noopener']")).Click();

            //--------------Tab switching------------------//
            ReadOnlyCollection<string> handles = driver.WindowHandles;
            driver.SwitchTo().Window(handles[1]);                        
            driver.FindElement(By.CssSelector("a[href*='taqc-opencart.epizy.com']")).Click();
            //---------------------------------------------//

            PasswordChangeProcess("NewPassword");


        }

        [Test]
        public void LockingUserTest()
        {
            driver.Navigate().GoToUrl("http://192.168.19.131/opencart/upload/index.php");
            driver.FindElement(By.ClassName("caret")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("a[href*='account/login']")).Click();
            Thread.Sleep(1000);
            //Entering wrong password 6 times
            driver.FindElement(By.Id("input-email")).SendKeys(Environment.GetEnvironmentVariable("UserEmail"));
            for (int i = 0; i < 6; i++)
            { 
                driver.FindElement(By.Id("input-password")).SendKeys("Wrong Password" + Keys.Enter);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("input-password")).Clear();
            }
            //Going to admin page and unlocking the user
            driver.Navigate().GoToUrl("http://192.168.19.131/opencart/upload/admin/index.php");
            //admin login
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("AdminUserName"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("AdminPassword") + Keys.Enter);
            driver.FindElement(By.CssSelector(".fa.fa-user.fw")).Click();
            driver.FindElement(By.CssSelector("#menu-customer a[href*= 'customer/customer&']")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-warning")).Click();
        }
    }
}
