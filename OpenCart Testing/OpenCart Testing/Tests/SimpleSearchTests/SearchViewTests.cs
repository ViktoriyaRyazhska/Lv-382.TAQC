using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.UIMapping;
using OpenCart_Testing.TestData.SimpleSearchData;
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
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Case_DefaultView.json"))
        };


        //protected bool hasClass(IWebElement element, string searchedClass)
        //{
        //    string[] classes = element.GetAttribute("class").Split(' ');
        //    foreach (string str in classes)
        //    {
        //        if (str.Equals(searchedClass))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchDefaultView_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            bool actual = searchCriteriaPage.hasClass(searchCriteriaPage.GridView, "active");
            Assert.AreEqual(true, actual);
            searchCriteriaPage.GotoHomePage();
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchSavedView_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            bool wasGrid = false;

            if (searchCriteriaPage.hasClass(searchCriteriaPage.GridView, "active"))
            {
                searchCriteriaPage.ClickListView();
                wasGrid = true;
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }

            SearchCriteriaPage searchCriteriaPage1 = LoadApplication()
                .SearchItems(searchText.SearchData);

            Assert.AreEqual(!wasGrid, searchCriteriaPage.hasClass(searchCriteriaPage1.GridView, "active"));
            searchCriteriaPage.GotoHomePage();
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchChangeViewNumberOfElements_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            int beforeChange = searchCriteriaPage.FindActualCount();
            if (searchCriteriaPage.hasClass(searchCriteriaPage.GridView, "active"))
            {
                searchCriteriaPage.ClickListView();
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }
            int afterChange = searchCriteriaPage.FindActualCount();

            Assert.AreEqual(beforeChange, afterChange);
            searchCriteriaPage.GotoHomePage();
        }

    }
}
