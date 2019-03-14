using System;
using System.Threading;
using NUnit.Framework;
using OpenCartTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Linq;

namespace OpenCartTestProject
{
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class SeleniumTest : TestRuner
    {

        [Test]
        public void AddNewMenuItemValid()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.CssSelector(".page-header a.btn.btn-primary")).Click();
            driver.FindElement(By.Id("input-name1")).SendKeys("Test1");
            driver.FindElement(By.Id("input-meta-title1")).SendKeys("Test1");
            driver.FindElement(By.CssSelector("a[href*='data']")).Click();
            driver.FindElement(By.Id("input-top")).Click();
            driver.FindElement(By.Id("input-sort-order")).SendKeys("9");
            driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            driver.FindElement(By.CssSelector("a.asc")).Click();
            Thread.Sleep(2000);   //For presentation only
            Assert.AreEqual(true, driver.FindElements(By.XPath("//td[text()='Test1']/preceding-sibling::td/input")).Count>0, "No error message when expected!");

        }
        [Test]
        public void AddNewMenuItemValid1()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.CssSelector("a.asc")).Click();
            driver.FindElement(By.XPath("//td[text()='Test1']/preceding-sibling::td/input")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            //Thread.Sleep(3000);   //For presentation only
        }


        [Test]
        public void AddNewMenuItemInvalid()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.CssSelector(".page-header a.btn.btn-primary")).Click();
            driver.FindElement(By.Id("input-name1")).SendKeys("    ");
            driver.FindElement(By.Id("input-meta-title1")).SendKeys("    ");
            driver.FindElement(By.CssSelector("a[href*='data']")).Click();
            driver.FindElement(By.Id("input-top")).Click();
            driver.FindElement(By.Id("input-sort-order")).SendKeys("9");
            driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            Thread.Sleep(2000);   //For presentation only
            Assert.AreEqual(true, driver.FindElements(By.XPath("//td[text()='    ']/preceding-sibling::td/input")).Count <= 0, "No error message when expected!");
            //Assert.AreEqual(true, driver.FindElements(By.CssSelector(".alert.alert-danger")).Count>0, "No error message when expected!");
        }
        [Test]
        public void AddNewMenuItemInvalid1()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.XPath("//td[text()='    ']/preceding-sibling::td/input")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            
            //Thread.Sleep(3000);   //For presentation only
        }


        [Test]
        public void AddNewMenuSubItem()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.CssSelector(".page-header a.btn.btn-primary")).Click();
            driver.FindElement(By.Id("input-name1")).SendKeys("ear1");
            driver.FindElement(By.Id("input-meta-title1")).SendKeys("ear1");
            driver.FindElement(By.CssSelector("a[href*='data']")).Click();
            driver.FindElement(By.Id("input-parent")).SendKeys("Earphones");
            driver.FindElement(By.CssSelector("#tab-data > div:nth-child(1) > div > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-sort-order")).Clear();
            driver.FindElement(By.Id("input-sort-order")).SendKeys("1");
            driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            driver.FindElement(By.XPath("//td[contains(text(),'ear1')]/preceding-sibling::td/input")).Click();
            Thread.Sleep(2000);   //For presentation only
            Assert.AreEqual(true, driver.FindElements(By.XPath("//td[contains(text(),'ear1')]/preceding-sibling::td/input")).Count > 0, "No error message when expected!");

        }


        [Test]
        public void ReplaceMenuItem()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.XPath("//td[text()='Cameras']/../td/a")).Click();
            driver.FindElement(By.CssSelector("a[href*='data']")).Click();
            driver.FindElement(By.Id("input-sort-order")).Clear();
            driver.FindElement(By.Id("input-sort-order")).SendKeys("0");
            driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            driver.Navigate().GoToUrl(urlForMainPage);
            Thread.Sleep(2000);   //For presentation only

            string res = driver.FindElements(By.CssSelector("#menu a")).ToList<IWebElement>()[0].Text;
            Assert.AreEqual(res, "Cameras", "No error message when expected!");
        }
        [Test]
        public void ReplaceMenuItem1()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.XPath("//td[text()='Cameras']/../td/a")).Click();
            driver.FindElement(By.CssSelector("a[href*='data']")).Click();
            driver.FindElement(By.Id("input-sort-order")).Clear();
            driver.FindElement(By.Id("input-sort-order")).SendKeys("6");
            driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            //Thread.Sleep(3000);   //For presentation only
        }


        [Test]
        public void ReplaceMenuSubItem()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.XPath("//td[contains(text(),'Mice and Trackballs')]/preceding-sibling::td/input")).Click();
            driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(3) > td:nth-child(4) > a")).Click();
            driver.FindElement(By.CssSelector("a[href*='data']")).Click();
            driver.FindElement(By.Id("input-sort-order")).Clear();
            driver.FindElement(By.Id("input-sort-order")).SendKeys("5");
            driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            //Thread.Sleep(2000);   //For presentation only
        }
        [Test]
        public void ReplaceMenuSubItem1()
        {
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
            driver.FindElement(By.XPath("//td[contains(text(),'Mice and Trackballs')]/preceding-sibling::td/input")).Click();
            driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(3) > td:nth-child(4) > a")).Click();
            driver.FindElement(By.CssSelector("a[href*='data']")).Click();
            driver.FindElement(By.Id("input-sort-order")).Clear();
            driver.FindElement(By.Id("input-sort-order")).SendKeys("1");
            driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            //Thread.Sleep(3000);   //For presentation only
        }
    }
}
