using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData.SimpleSearchData;

namespace OpenCart_Testing.Tests.SimpleSearchTests
{
    [TestFixture]
    public class SavedViewTest : TestRunner
    {
        private static readonly object[] SearchData_Positive =
        {
             new object[] { SimpleSearchRepository.NewSearchDataFromJson("SearchData_Positive.json") }
        };

        [Test, TestCaseSource("SearchData_Positive")]
        public void SearchSavedView_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.IsTrue(searchCriteriaPage.isView(ViewType.Grid));
            searchCriteriaPage.ClickListView();
            searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.IsFalse(searchCriteriaPage.isView(ViewType.Grid));
        }
    }
}
