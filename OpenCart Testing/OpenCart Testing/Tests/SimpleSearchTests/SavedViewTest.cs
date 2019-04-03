using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData.SimpleSearchData;
using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Tests.SimpleSearchTests
{
    [TestFixture]
    public class SavedViewTest : TestRunner
    {
        private static readonly object[] SearchData_Case_DefaultView =
           ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json"));

        //[Test, TestCaseSource("SearchData_Case_DefaultView")]
        //public void SearchSavedView_Test(SimpleSearch searchText)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(searchText.Name);
        //    Assert.IsTrue(searchCriteriaPage.isView(ViewType.Grid));
        //    searchCriteriaPage.ClickListView();
        //    SearchCriteriaPage searchCriteriaPage1 = LoadApplication()
        //        .SearchItems(searchText.Name);
        //    Assert.IsFalse(searchCriteriaPage1.isView(ViewType.Grid));
        //}

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchSavedView_Test(SimpleSearch searchText)
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
    }
}
