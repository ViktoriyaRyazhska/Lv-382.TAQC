using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace OpenCartTestProject
{
        [TestFixture]
        //[Parallelizable(ParallelScope.All)]
        public class SeleniumTest
        {
            private IWebDriver driver;
            private string urlForAdminPage = "http://192.168.85.129/opencart/upload/admin";
            private string urlForMainPage = "http://192.168.85.129/opencart/upload";
            static readonly string adminLogin = Environment.GetEnvironmentVariable("adminLogin");
            static readonly string adminPassword = Environment.GetEnvironmentVariable("adminPassword");
            private string tokenHttp;

            [OneTimeSetUp]
            public void BeforeAllMethods()
            {
                driver = new ChromeDriver();
                //driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.Navigate().GoToUrl(urlForAdminPage);
                driver.FindElement(By.Id("input-username")).SendKeys(adminLogin);
                driver.FindElement(By.Id("input-password")).SendKeys(adminPassword);
                driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
                tokenHttp = driver.Url;
            }

            [OneTimeTearDown]
            public void AfterAllMethods()
            {
                driver.Quit();
            }

            [Test]
            public void AddNewMenuItem()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.CssSelector("#menu-catalog > a > i")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(1) > a")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-primary > i")).Click();
                driver.FindElement(By.Id("input-name1")).SendKeys("Test1");
                driver.FindElement(By.Id("input-meta-title1")).SendKeys("Test1");
                driver.FindElement(By.CssSelector("#form-category > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-top")).Click();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("9");
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > button")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
            [Test]
            public void AddNewMenuItem1()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.CssSelector("#menu-catalog > a > i")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(1) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > thead > tr > td.text-left > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(1) > td.text-center > input[type='checkbox']")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > button")).Click();
                driver.SwitchTo().Alert().Accept();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }


            //DataProvider
            private static readonly object[] ConverterData =
            {  new object[] {"ear1", "ear1", 1},
           new object[] {"ear2", "ear2", 2},
           new object[] {"ear3", "ear3", 3}
        };
            [Test, TestCaseSource("ConverterData")]
            public void AddNewMenuSubItem(string n, string t, int o)
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.CssSelector("#menu-catalog > a > i")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(1) > a")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-primary > i")).Click();
                driver.FindElement(By.Id("input-name1")).SendKeys(n);
                driver.FindElement(By.Id("input-meta-title1")).SendKeys(t);
                driver.FindElement(By.CssSelector("#form-category > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-parent")).SendKeys("Ea");
                driver.FindElement(By.CssSelector("#tab-data > div:nth-child(1) > div > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys(o.ToString());
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > button")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }


            [Test]
            public void ReplaceMenuItem()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.CssSelector("#menu-catalog > a > i")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(1) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(1) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("0");
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > button")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
            [Test]
            public void ReplaceMenuItem1()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.CssSelector("#menu-catalog > a > i")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(1) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(1) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("6");
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > button")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }


            [Test]
            public void ReplaceMenuSubItem()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.CssSelector("#menu-catalog > a > i")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(1) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(3) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("5");
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > button")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
            [Test]
            public void ReplaceMenuSubItem1()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.CssSelector("#menu-catalog > a > i")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(1) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(3) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("#form-category > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("1");
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > button")).Click();
                driver.FindElement(By.CssSelector("#content > div.page-header > div > div > a.btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
        }
    }
