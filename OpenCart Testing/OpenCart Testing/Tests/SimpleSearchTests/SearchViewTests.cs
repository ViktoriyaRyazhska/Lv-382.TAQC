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
    public class SearchViewTests : TestRunner
    {
        private static readonly object[] SearchData_Case_DefaultView =
        {
            "mac",
            "a",
            "i",
            "book"
         };


        protected bool hasClass(IWebElement element, string searchedClass)
        {
            string[] classes = element.GetAttribute("class").Split(' ');
            foreach (string str in classes)
            {
                if (str.Equals(searchedClass))
                {
                    return true;
                }
            }
            return false;
        }


        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchDefaultView_Test(string searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText);
            bool actual = hasClass(searchCriteriaPage.GridView, "active");
            Assert.AreEqual(true, actual);
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchSavedView_Test(string searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText);
            bool wasGrid = false;

            if (hasClass(searchCriteriaPage.GridView, "active"))
            {
                searchCriteriaPage.ClickListView();
                wasGrid = true;
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }

            SearchCriteriaPage searchCriteriaPage1 = LoadApplication()
                .SearchItems(searchText);

            Assert.AreEqual(!wasGrid, hasClass(searchCriteriaPage1.GridView, "active"));
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchChangeViewNumberOfElements_Test(string searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText);
            int beforeChange = searchCriteriaPage.FindActualCount();
            if (hasClass(searchCriteriaPage.GridView, "active"))
            {
                searchCriteriaPage.ClickListView();
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }
            int afterChange = searchCriteriaPage.FindActualCount();

            Assert.AreEqual(beforeChange, afterChange);
        }

    }
}
