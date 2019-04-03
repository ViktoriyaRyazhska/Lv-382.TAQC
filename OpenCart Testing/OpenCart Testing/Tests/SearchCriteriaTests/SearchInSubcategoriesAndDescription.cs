using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchInSubcategoriesAndDescriptionTest : TestRunner
    {
        private static readonly object[] ProductSubcategoriesAndDescriptionData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInSubcategoriesAndDescription.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInSubcategoryAndDescription.json") )
        };

        [Test, TestCaseSource(nameof(ProductSubcategoriesAndDescriptionData))]
        public void CheckSearchInCategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }
    }
}
