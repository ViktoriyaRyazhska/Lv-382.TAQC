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
    public class SearchInCategoriesAndDescriptionTest : TestRunner
    {
        private static readonly object[] ProductCategoryAndDescriptionData =
        {
            new object[] {SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoriesAndDescription.json"), ProductRepository.GetSearchInCategoryAndDescriptionProducts() }
        };

        [Test, TestCaseSource(nameof(ProductCategoryAndDescriptionData))]
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
    }
}
