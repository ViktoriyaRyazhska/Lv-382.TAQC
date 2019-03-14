using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Collections.Generic;

namespace OpencartTesting
{
    [TestFixture]
    public class OpencartTest : TestRunner
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
            driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
            int actual = int.Parse(driver.FindElement(By.CssSelector(".col-sm-6.text-right")).Text.Split(' ')[5]);
            List<string> searchResults = driver.FindElements(By.CssSelector(".caption a")).ToList<IWebElement>().Select(x=>x.Text).ToList<string>();

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("MY_ADMLOGIN"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("MY_ADMPASSWORD"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("%" + searchText);
            driver.FindElement(By.Id("button-filter")).Click();
            int expected = int.Parse(driver.FindElement(By.CssSelector("div.col-sm-6.text-right")).Text.Split(' ')[5]);

            Assert.AreEqual(expected, actual);
            
            for (int i = 0; i < searchResults.Count; i++)
            {
                Assert.AreEqual(true, searchResults[i].ToLower().Contains(searchText.ToLower()));
            }
        }

        private static readonly string[] SearchData_Negative =
        {
            "",
           "nonexistent",
           "TestProductWith255SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe"
        };

        [Test, TestCaseSource("SearchData_Negative")]
        public void SearchTest_Negative(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
            Assert.AreEqual("There is no product that matches the search criteria.", driver.FindElement(By.CssSelector("#button-search ~ p")).Text);
        }

        private static readonly string[] SearchData_InvalidLength =
        {
           "TestProduct1With256SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe",
           "TestProductWith300SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest"
        };

        [Test, TestCaseSource("SearchData_InvalidLength")]
        public void SearchTest_InvalidLength(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
            Assert.AreEqual("Search text maximum length is 255 characters. Please make a different search request.", driver.FindElement(By.Id("search_alert")).Text);
        }

        private static readonly string[] SearchData_SpecialCharacters =
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
            driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
            Assert.AreEqual("There is no product that matches the search criteria.", driver.FindElement(By.CssSelector("#button-search ~ p")).Text);
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
            driver.FindElement(By.Name("search")).SendKeys(searchText.ToLower() + Keys.Enter);
            int lowerResult = int.Parse(driver.FindElement(By.CssSelector(".col-sm-6.text-right")).Text.Split(' ')[5]);

            driver.Navigate().GoToUrl(homePageUrl);
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText.ToUpper() + Keys.Enter);
            int upperResult = int.Parse(driver.FindElement(By.CssSelector(".col-sm-6.text-right")).Text.Split(' ')[5]);
 
            Assert.AreEqual(lowerResult,upperResult);
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchDefaultView_Test(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);

            bool actual = hasClass(driver.FindElement(By.Id("grid-view")),"active");
            Assert.AreEqual(true, actual);
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchSavedView_Test(string searchText)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
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
            driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
            Assert.AreEqual(!wasGrid, hasClass(driver.FindElement(By.Id("grid-view")), "active"));
        }
    }
}
