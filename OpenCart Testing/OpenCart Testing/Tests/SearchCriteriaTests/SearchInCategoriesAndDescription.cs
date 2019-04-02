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
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoriesAndDescription.json"), ProductRepository.GetSearchInCategoryAndDescriptionProducts() )
        };

        [Test, TestCaseSource(nameof(ProductCategoryAndDescriptionData))]
        public void CheckSearchInCategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());

         //   HomePage homePage = searchCriteriaPage.GotoHomePage();

         //   Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }
    }
}
