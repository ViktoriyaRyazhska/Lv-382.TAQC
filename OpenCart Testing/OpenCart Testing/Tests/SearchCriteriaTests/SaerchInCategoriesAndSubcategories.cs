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
            new object[] {SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategories.json"), ProductRepository.GetSearchInCategoriesProducts() }
        };

        [Test, TestCaseSource(nameof(ProductCategoryData))]
        public void CheckSearchInCategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            //Check
            //Assert.IsTrue(searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames().Contains(data));

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());

            // Return to Previous State
            HomePage homePage = searchCriteriaPage.GotoHomePage();
            //
            // Check
            // Check
            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }

        private static readonly object[] ProductSubcategoryData =
        {
            new object[] {SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoryAndSubcategories.json"), ProductRepository.GetSearchInCategoryAndSybcategoryProducts() }
        };

        [Test, TestCaseSource(nameof(ProductSubcategoryData))]
        public void CheckSearchInCategoryAndSubcategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            //Check
            //Assert.IsTrue(searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames().Contains(data));

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());

            // Return to Previous State
            HomePage homePage = searchCriteriaPage.GotoHomePage();
            //
            // Check
            // Check
            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }
    }
}