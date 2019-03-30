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

        private static readonly object[] SearchData_Case_DefaultViewActive =
        {
            SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultViewActive.json")[0],
            SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultViewActive.json")[1],
            SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultViewActive.json")[2],
            SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultViewActive.json")[3]
        };

        [Test]
        [TestCaseSource("SearchData_Case_DefaultViewActive"), Order(1)]
        public void SearchDefaultView_Test(SimpleSearch1 searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(true, searchCriteriaPage.hasClass(searchCriteriaPage.GridView, searchText.State));

        }


        private static readonly object[] SearchData_Case_DefaultView =
        {
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Case_DefaultView.json"))
        };

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
            
        }

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchChangeViewNumberOfElements_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            
            int beforeChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
            if (searchCriteriaPage.hasClass(searchCriteriaPage.GridView, "active"))
            {
                searchCriteriaPage.ClickListView();
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }
            int afterChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
            searchCriteriaPage.GotoHomePage();
            Assert.AreEqual(beforeChange, afterChange);
        }

    }
}
