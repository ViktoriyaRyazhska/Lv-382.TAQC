using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests.SimpleSearchTests
{
    [TestFixture]
    public class SearchFieldTests : TestRunner
    {
        private static readonly object[] SearchData_Positive =
        {
           "a",
           "i",
           "mac"//,
           //"TestProductWith255SymbolsTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe"
        };

        [Test, TestCaseSource("SearchData_Positive")]
        public void SearchTest_Positive(string searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText);
           
            int actual = searchCriteriaPage.FindActualCount();
            //int actual = int.Parse(driver.FindElement(MSearchCriteriaPage.locatorSearchItemsCount).Text.Split(' ')[5]);
            //List<string> searchResults = driver.FindElements(MSearchCriteriaPage.locatorSearchItemCaption)
            //.ToList<IWebElement>().Select(x => x.Text).ToList<string>();
            List<string> searchResults = driver.FindElements(MSearchCriteriaPage.locatorSearchItemCaption)
            .ToList<IWebElement>().Select(x => x.Text).ToList<string>();

            driver.Navigate().GoToUrl("http://192.168.85.129/opencart/upload/admin");
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("adminLogin"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("adminPassword"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("%" + searchText);
            driver.FindElement(By.Id("button-filter")).Click();
            int expected = int.Parse(driver.FindElement(By.CssSelector("div.col-sm-6.text-right")).Text.Split(' ')[5]);

            //Thread.Sleep(3000);//FOR PRESENTATION ONLY!

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
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText);
            Assert.AreEqual("There is no product that matches the search criteria.",
                searchCriteriaPage.GetItemNotMatchesMessage());
        }


        private static readonly string[] SearchData_InvalidLength =
        {
            "TestProduct1With256SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe",
            "TestProductWith300SymbolsTestNotnotnotnotTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest"
         };

        [Test, TestCaseSource("SearchData_InvalidLength")]
        public void SearchTest_InvalidLength(string searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText);
            Assert.AreEqual("Search text maximum length is 255 characters. Please make a different search request.",
                searchCriteriaPage.GetSearchAlertMessage());
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
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText);
            Assert.AreEqual("There is no product that matches the search criteria.",
                searchCriteriaPage.GetItemNotMatchesMessage());
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
            SearchCriteriaPage searchCriteriaPageLower = LoadApplication()
                .SearchItems(searchText.ToLower());
            int lowerResult = searchCriteriaPageLower.FindActualCount();

            SearchCriteriaPage searchCriteriaPageUpper = LoadApplication()
                .SearchItems(searchText.ToUpper());
            int upperResult = searchCriteriaPageUpper.FindActualCount();

            Assert.AreEqual(lowerResult, upperResult);
        }
    }
}
