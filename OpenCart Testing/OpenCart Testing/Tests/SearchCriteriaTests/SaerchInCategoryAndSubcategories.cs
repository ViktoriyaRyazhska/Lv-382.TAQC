using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchInCategoryAndSubcategoriesTest : TestRunner
    {
        private static readonly object[] ProductCategoryData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategory.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInCategory.json") )
        };

        [Test, TestCaseSource(nameof(ProductCategoryData))]
        public void CheckSearchInCategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {            
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);          
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());     
        }


        private static readonly object[] ProductSubcategoryData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoryAndSubcategories.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInCategoryAndSubcategory.json") )
        };

        [Test, TestCaseSource(nameof(ProductSubcategoryData))]
        public void CheckSearchInCategoryAndSubcategories(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {           
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());        
        }
    }
}