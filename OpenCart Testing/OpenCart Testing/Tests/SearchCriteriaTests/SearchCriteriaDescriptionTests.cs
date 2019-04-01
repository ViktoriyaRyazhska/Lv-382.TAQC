using NUnit.Framework;
using OpenCart_Testing.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCart_Testing.TestData;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchTest : TestRunner
    {
       
        private static readonly object[] ProductData2 =
        {
            new object[] {SearchCriteriasRepository.Get().Mac(), ProductRepository.GetMacListProducts() }
        };

        [Test, TestCaseSource(nameof(ProductData2))]
        public void CheckSearchCriteria2(ISearchCriteria searchCriteria, IList<Product> expectedList)
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

        private static readonly object[] ProductData3 =
       {
            new object[] {SearchCriteriasRepository.Get().Qwerty(), ProductRepository.Get().GetProductEmptyListMessage() }
        };

        [Test, TestCaseSource(nameof(ProductData3))]
        public void CheckSearchCriteria3(ISearchCriteria searchCriteria, string expectedMessage)
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

        private static readonly object[] ProductData4 =
       {
            new object[] {SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchCriteria_Description_AllCategories.json"), ProductRepository.GetMacListProducts() }
        };

        [Test, TestCaseSource(nameof(ProductData4))]
        public void CheckSearchCriteria4(ISearchCriteria searchCriteria, IList<Product> expectedList)
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
