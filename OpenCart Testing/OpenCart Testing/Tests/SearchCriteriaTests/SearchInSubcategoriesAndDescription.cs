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
    public class SearchInSubcategoriesAndDescriptionTest : TestRunner
    {
        private static readonly object[] ProductSubcategoriesAndDescriptionData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInSubcategoriesAndDescription.json"), ProductRepository.GetSearchInSubcategoryAndDescriptionProducts() )
        };

        [Test, TestCaseSource(nameof(ProductSubcategoriesAndDescriptionData))]
        public void CheckSearchInCategory(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());

            HomePage homePage = searchCriteriaPage.GotoHomePage();

            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }
    }
}
