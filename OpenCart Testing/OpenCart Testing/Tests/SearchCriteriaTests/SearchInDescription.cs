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
        private static readonly object[] ProductWithoutInDescriptionData =
       {
            new object[] {SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchWithoutInDescription.json"), ProductRepository.Get().GetProductEmptyListMessage() }
        };

        [Test, TestCaseSource(nameof(ProductWithoutInDescriptionData))]
        public void CheckSearchWithoutInDescription(ISearchCriteria searchCriteria, string expectedMessage)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            //Check
            //Assert.IsTrue(searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames().Contains(data));

            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(), searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());

            // Return to Previous State
            HomePage homePage = searchCriteriaPage.GotoHomePage();
            //
            // Check
            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }

        private static readonly object[] ProductDescriptioData =
       {
            new object[] {SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInDescription.json"), ProductRepository.GetSearchInDescriptionProducts() }
        };

        [Test, TestCaseSource(nameof(ProductDescriptioData))]
        public void CheckSearchInDescription(ISearchCriteria searchCriteria, IList<Product> expectedList)
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
            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }
    }
}
