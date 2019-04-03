using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchInCategoryAndDescriptionTest : TestRunner
    {
        private static readonly object[] ProductCategoryAndDescriptionData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoryAndDescription.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInCategoryAndDescription.json") )
        };

        [Test, TestCaseSource(nameof(ProductCategoryAndDescriptionData))]
        public void CheckSearchInCategoryAndDescription(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }
    }
}
