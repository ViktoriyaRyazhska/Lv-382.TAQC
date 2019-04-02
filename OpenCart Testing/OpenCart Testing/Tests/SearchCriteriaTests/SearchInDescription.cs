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
    public class SearchInDescriptionTest : TestRunner
    {
        private static readonly object[] ProductNoInDescriptionData =
       {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchNoInDescription.json"), ProductRepository.Get().GetProductEmptyListMessage() )
        };

        [Test, TestCaseSource(nameof(ProductNoInDescriptionData))]
        public void CheckSearchWithoutInDescription(ISearchCriteria searchCriteria, string expectedMessage)
        {

            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(), searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());
            
            HomePage homePage = searchCriteriaPage.GotoHomePage();

            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }

        private static readonly object[] ProductDescriptioData =
       {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInDescription.json"), ProductRepository.GetSearchInDescriptionProducts() )
        };

        [Test, TestCaseSource(nameof(ProductDescriptioData))]
        public void CheckSearchInDescription(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {

            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());

         //   HomePage homePage = searchCriteriaPage.GotoHomePage();

         //   Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }
    }
}
