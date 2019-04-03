using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchCriteriaNegativeTest : TestRunner
    {
        private static readonly object[] SearchCriteriaData_Negative =
            ListUtils.ToMultiArray(SearchCriteriasRepository.NewSearchCriteriaArrayFromJson("NegativeSearchInDescriptionAndCategories.json"));

        [Test, TestCaseSource(nameof(SearchCriteriaData_Negative))]
        public void CheckSearchCriteriaWithNegativeData(SearchCriteria searchCriteria)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(), searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());
        }
    }
}
