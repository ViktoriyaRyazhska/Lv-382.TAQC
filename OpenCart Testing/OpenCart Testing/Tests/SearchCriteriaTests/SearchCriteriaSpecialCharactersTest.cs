using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using OpenCart_Testing.Tools;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchCriteriaSpecialCharactersTest : TestRunner
    {
        private static readonly object[] SearchCriteriaData_SpecialCharacters =
            ListUtils.ToMultiArray(SearchCriteriasRepository.NewSearchCriteriaArrayFromJson("SpecialCharactersSearchCriteria.json"));

        [Test, TestCaseSource(nameof(SearchCriteriaData_SpecialCharacters))]
        public void CheckSearchWithSpecialCharacters(SearchCriteria searchCriteria)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(), searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());
        }
    }
}
