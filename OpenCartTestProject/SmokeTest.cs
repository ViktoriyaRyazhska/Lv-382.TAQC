using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTestProject
{
    [TestFixture]
    public class SmokeTest : TestRunner
    {
        // DataProvider

        //[Test]
        public void CheckSearch()
        {
            driver.FindElement(By.Name("search")).Click();
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys("mac");
            //
            driver.FindElement(By.CssSelector("button.btn.btn-default.btn-lg")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            //driver.FindElement(By.Name("search1"));
        }
    }
}
