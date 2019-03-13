using System;
using System.Threading;
using NUnit.Framework;
using OpenCartTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace OpenCartTestProject
{
        [TestFixture]
        //[Parallelizable(ParallelScope.All)]
        public class SeleniumTest : TestRuner
        {
            [Test]
            public void AddNewMenuItem()
            {
                driver.Navigate().GoToUrl(tokenHttp);
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

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
            [Test]
            public void AddNewMenuItem1()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.Id("menu-catalog")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
                driver.FindElement(By.CssSelector("a.asc")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(1) > td.text-center > input[type='checkbox']")).Click();
                driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
                driver.SwitchTo().Alert().Accept();
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }


            //DataProvider
            private static readonly object[] ConverterData =
            {
            new object[] {"ear1", "ear1", 1},
            new object[] {"ear2", "ear2", 2},
            new object[] {"ear3", "ear3", 3}
            };
            [Test, TestCaseSource("ConverterData")]
            public void AddNewMenuSubItem(string n, string t, int o)
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.Id("menu-catalog")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
                driver.FindElement(By.CssSelector(".page-header a.btn.btn-primary")).Click();
                driver.FindElement(By.Id("input-name1")).SendKeys(n);
                driver.FindElement(By.Id("input-meta-title1")).SendKeys(t);
                driver.FindElement(By.CssSelector("a[href*='data']")).Click();
                driver.FindElement(By.Id("input-parent")).SendKeys("Earphones");
                driver.FindElement(By.CssSelector("#tab-data > div:nth-child(1) > div > ul > li:nth-child(2) > a")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys(o.ToString());
                driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }


            [Test]
            public void ReplaceMenuItem()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.Id("menu-catalog")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(1) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("a[href*='data']")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("0");
                driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

            driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
            [Test]
            public void ReplaceMenuItem1()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.Id("menu-catalog")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(1) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("a[href*='data']")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("6");
                driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }


            [Test]
            public void ReplaceMenuSubItem()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.Id("menu-catalog")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(3) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("a[href*='data']")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("5");
                driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
            [Test]
            public void ReplaceMenuSubItem1()
            {
                driver.Navigate().GoToUrl(tokenHttp);
                driver.FindElement(By.Id("menu-catalog")).Click();
                driver.FindElement(By.CssSelector("#menu-catalog a[href*='category']")).Click();
                driver.FindElement(By.CssSelector("#form-category > div > table > tbody > tr:nth-child(3) > td:nth-child(4) > a")).Click();
                driver.FindElement(By.CssSelector("a[href*='data']")).Click();
                driver.FindElement(By.Id("input-sort-order")).Clear();
                driver.FindElement(By.Id("input-sort-order")).SendKeys("1");
                driver.FindElement(By.CssSelector("div.pull-right .btn.btn-primary")).Click();
                driver.FindElement(By.CssSelector(".btn.btn-default")).Click();

                driver.Navigate().GoToUrl(urlForMainPage);
                //Thread.Sleep(3000);   //For presentation only
            }
        }
    }
