using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.UIMapping;
using OpenCart_Testing.TestData.SimpleSearchData;
using OpenCart_Testing.Tools;
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
            ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultViewActive.json"));

        [Test]
        [TestCaseSource("SearchData_Case_DefaultView"), Order(1)]
        public void SearchDefaultView_Test(SimpleSearchView searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.IsTrue(searchCriteriaPage.isView(ViewType.Grid));

        }

        //[Test, TestCaseSource("SearchData_Case_DefaultView")]
        //public void SearchSavedView_Test(SimpleSearchView searchText)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(searchText.Name);
        //    Assert.IsTrue(searchCriteriaPage.isView(ViewType.List));
        //    searchCriteriaPage.ClickGridView();
        //    SearchCriteriaPage searchCriteriaPage1 = LoadApplication()
        //        .SearchItems(searchText.Name);
        //    Assert.IsFalse(searchCriteriaPage1.isView(ViewType.List));

        //}

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchSavedView_Test(SimpleSearchView searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            bool wasGrid = false;

            if (searchCriteriaPage.isView(ViewType.Grid))
            {
                searchCriteriaPage.ClickListView();
                wasGrid = true;
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }
            SearchCriteriaPage searchCriteriaPage1 = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(!wasGrid, searchCriteriaPage.isView(ViewType.Grid));
        }


        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchChangeViewNumberOfElements_Test(SimpleSearchView searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);

            int beforeChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
            if (searchCriteriaPage.isView(ViewType.Grid))
            {
                searchCriteriaPage.ClickListView();
            }
            else
            {
                searchCriteriaPage.ClickGridView();
            }
            int afterChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
            Assert.AreEqual(beforeChange, afterChange);
        }

        



        //private static readonly object[] SearchData_Case_DefaultView =
        //    ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json"));

        //[Test]
        //[TestCaseSource("SearchData_Case_DefaultView"), Order(1)]
        //public void SearchDefaultView_Test(SimpleSearch searchText)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(searchText.SearchData);
        //    Assert.AreEqual(true, searchCriteriaPage.hasClass(searchCriteriaPage.GridView, "active"));

        //}


        //[Test, TestCaseSource("SearchData_Case_DefaultView")]
        //public void SearchSavedView_Test(SimpleSearch searchText)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(searchText.SearchData);
        //    bool wasGrid = false;

        //    if (searchCriteriaPage.hasClass(searchCriteriaPage.GridView, "active"))
        //    {
        //        searchCriteriaPage.ClickListView();
        //        wasGrid = true;
        //    }
        //    else
        //    {
        //        searchCriteriaPage.ClickGridView();
        //    }

        //    SearchCriteriaPage searchCriteriaPage1 = LoadApplication()
        //        .SearchItems(searchText.SearchData);

        //    Assert.AreEqual(!wasGrid, searchCriteriaPage.hasClass(searchCriteriaPage1.GridView, "active"));

        //}


        //[Test, TestCaseSource("SearchData_Case_DefaultView")]
        //public void SearchChangeViewNumberOfElements_Test(SimpleSearch searchText)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(searchText.SearchData);

        //    int beforeChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
        //    if (searchCriteriaPage.hasClass(searchCriteriaPage.GridView, "active"))
        //    {
        //        searchCriteriaPage.ClickListView();
        //    }
        //    else
        //    {
        //        searchCriteriaPage.ClickGridView();
        //    }
        //    int afterChange = searchCriteriaPage.GetProductComponentsContainer().GetProductComponentsCount();
        //    searchCriteriaPage.GotoHomePage();
        //    Assert.AreEqual(beforeChange, afterChange);
        //}
    }
}
