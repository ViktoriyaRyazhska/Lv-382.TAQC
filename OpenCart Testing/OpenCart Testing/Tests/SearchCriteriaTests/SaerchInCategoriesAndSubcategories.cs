using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchInCategoriesTest : TestRunner
    {
        private static readonly object[] ProductCategoryData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategories.json"), ProductRepository.GetSearchInCategoriesProducts() )
        };

        [Test, TestCaseSource(nameof(ProductCategoryData))]
        public void CheckSearchInCategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);          

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
            
         //   HomePage homePage = searchCriteriaPage.GotoHomePage();
            
         //   Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }

        private static readonly object[] ProductSubcategoryData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoryAndSubcategories.json"), ProductRepository.GetSearchInCategoryAndSybcategoryProducts() )
        };

        [Test, TestCaseSource(nameof(ProductSubcategoryData))]
        public void CheckSearchInCategoryAndSubcategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
           
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
            
        //    HomePage homePage = searchCriteriaPage.GotoHomePage();
            
        //    Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }
    }
}