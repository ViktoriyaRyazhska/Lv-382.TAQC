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
        //// DataProvider
        //private static readonly object[] ProductDataCriteria =
        //{
        //    //new object[] { "mac", new List<string>() { "iMac", "MacBook", "MacBook Air", "MacBook Pro" } },
        //    new object[] { ProductRepository.GetMacBook(), ProductRepository.GetMacListProducts() },
        //};


        //[Test, TestCaseSource(nameof(ProductDataCriteria))]
        //public void CheckSearch(Product product, IList<Product> expectedList)
        //{
        //    // Steps
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(product);
        //    //
        //    // Check
        //    CollectionAssert.AreEqual(Product.GetProductListNames(expectedList),
        //        searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        //    //
        //    // Return to Previous State
        //    HomePage homePage = searchCriteriaPage.GotoHomePage();
        //    //
        //    // Check
        //    Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        //}

        // DataProvider
        private static readonly object[] ProductData =
        {
            //new object[] { "mac", new List<string>() { "iMac", "MacBook", "MacBook Air", "MacBook Pro" } },
            new object[] { "mac", false, "Desktops", true },
        };

        [Test, TestCaseSource(nameof(ProductData))]
        public void CheckSearchCriteria(string data, bool description, string caregory, bool subcategory)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(data, description, caregory, subcategory);

            //Check
            //Assert.IsTrue(searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames().Contains(data));

            for (int i = 0; i < searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames().Count; i++)
            {
                Assert.AreEqual(true, searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames()[i].Contains(data));
            }
            // Return to Previous State
            HomePage homePage = searchCriteriaPage.GotoHomePage();
            //
            // Check
        Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }

        private static readonly object[] ProductData1 =
        {
            //new object[] { "mac", new List<string>() { "iMac", "MacBook", "MacBook Air", "MacBook Pro" } },
            new object[] { "qwerty", false, "Desktops", true },
        };

        [Test, TestCaseSource(nameof(ProductData1))]
        public void CheckSearchCriteria1(string data, bool description, string caregory, bool subcategory)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(data, description, caregory, subcategory);

            //Check
            //Assert.IsTrue(searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames().Contains(data));

            Assert.AreEqual("There is no product that matches the search criteria.", searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());

            // Return to Previous State
            HomePage homePage = searchCriteriaPage.GotoHomePage();
            //
            // Check
            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }


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
            new object[] {SearchCriteriasRepository.Get().Qwerty(), ProductRepository.GetProductEmptyListMessage() }
        };

        [Test, TestCaseSource(nameof(ProductData3))]
        public void CheckSearchCriteria3(ISearchCriteria searchCriteria, string expectedMessage)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            //Check
            //Assert.IsTrue(searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames().Contains(data));

            Assert.AreEqual(ProductRepository.GetProductEmptyListMessage(), searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());

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
