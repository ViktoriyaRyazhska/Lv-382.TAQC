﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace OpencartTesting
{
    [TestFixture]
    public class OpencartTesting : TestRunner
    {

        private static readonly object[] SearchData_Positive =
        {
           "a",
           "i",
           "mac",
           "TestProductWith255SymbolsTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe"
        };
        [Test, TestCaseSource("SearchData_Positive")]
        public void SearchTest_Positive(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            int actual = int.Parse(driver.FindElement(By.CssSelector("#content > div:nth-child(9) > div.col-sm-6.text-right")).Text.Split(' ')[5]);
            List<string> searchResults = driver.FindElements(By.CssSelector("#content > div:nth-child(8) > div:nth-child(1) > div > div:nth-child(2) > div.caption > h4 > a")).ToList<IWebElement>().Select(x=>x.Text).ToList<string>();

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("MY_ADMLOGIN"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("MY_ADMPASSWORD"));
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("%" + searchText);
            driver.FindElement(By.Id("button-filter")).Click();
            int expected = int.Parse(driver.FindElement(By.CssSelector("#content > div.container-fluid > div > div.panel-body > div.row > div.col-sm-6.text-right")).Text.Split(' ')[5]);

            Assert.AreEqual(expected, actual);
            
            for (int i = 0; i < searchResults.Count; i++)
            {
                Assert.AreEqual(true, searchResults[i].ToLower().Contains(searchText.ToLower()));
            }
        }

        [Test]
        public void SearchTest_NoInput()
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(OpenQA.Selenium.Keys.Enter);
            Assert.AreEqual(true, driver.FindElements(By.CssSelector("#content > p:nth-child(7)")).Count > 0);
        }

        private static string[] SearchData_Negative =
        {
           "nonexistent",
           "TestProductWith255SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe"
        };

        [Test, TestCaseSource("SearchData_Negative")]
        public void SearchTest_Negative(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            Assert.AreEqual(true,driver.FindElements(By.CssSelector("#content > p:nth-child(7)")).Count > 0);
        }

        private static string[] SearchData_InvalidLength =
        {
           "TestProduct1With256SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe",
           "TestProductWith300SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest"
        };

        [Test, TestCaseSource("SearchData_InvalidLength")]
        public void SearchTest_InvalidLength(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            Assert.AreEqual("Search text maximum length is 255 characters. Please make a different search request.", driver.FindElement(By.Id("search_alert")).Text);
        }

        private static string[] SearchData_SpecialCharacters =
        {
            "*",
            "%",
            "%mac",
            "%r%",
            "like '%a%'",
            " "
        };

        [Test, TestCaseSource("SearchData_SpecialCharacters")]
        public void SearchTest_SpecialCharacters(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            Assert.AreEqual(true, driver.FindElements(By.CssSelector("#content > p:nth-child(7)")).Count > 0);
        }

        private static readonly object[] SearchData_Case_DefaultView =
       {
           "mac",
           "a",
           "i",
           "book"
        };
        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchCaseInsensitive_Test(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText.ToLower() + OpenQA.Selenium.Keys.Enter);
            int lowerResult = int.Parse(driver.FindElement(By.CssSelector("#content > div:nth-child(9) > div.col-sm-6.text-right")).Text.Split(' ')[5]);

            driver.Navigate().GoToUrl(homePageUrl);
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText.ToUpper() + OpenQA.Selenium.Keys.Enter);
            int upperResult = int.Parse(driver.FindElement(By.CssSelector("#content > div:nth-child(9) > div.col-sm-6.text-right")).Text.Split(' ')[5]);
 
            Assert.AreEqual(lowerResult,upperResult);
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchDefaultView_Test(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);

            bool actual = hasClass(driver.FindElement(By.Id("grid-view")),"active");
            Assert.AreEqual(true, actual);
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchSavedView_Test(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            bool wasGrid = false;
            if (hasClass(driver.FindElement(By.Id("grid-view")), "active"))
            {
                driver.FindElement(By.Id("list-view")).Click();
                wasGrid = true;
            }
            else
            {
                driver.FindElement(By.Id("grid-view")).Click();
            }

            driver.Navigate().GoToUrl(homePageUrl);
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            Assert.AreEqual(!wasGrid, hasClass(driver.FindElement(By.Id("grid-view")), "active"));
        }

        private bool hasClass(IWebElement element,string searchedClass)
        {
            string[] classes = element.GetAttribute("class").Split(' ');
            foreach(string str in classes)
            { 
                if (str.Equals(searchedClass))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
