using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchInAllCategories : TestRunner
    {
        private static readonly object[] ProductAllCategoriesData =
       {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInAllCategories.json"), ProductRepository.NewProductArrayFromJson("MacListProducts.json") )
        };

        [Test, TestCaseSource(nameof(ProductAllCategoriesData))]
        public void CheckSearchInCategoryAndDescription(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }
    }
}
