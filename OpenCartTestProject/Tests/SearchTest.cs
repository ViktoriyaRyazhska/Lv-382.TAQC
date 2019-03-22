using NUnit.Framework;
using OpenCartTestProject.Data;
using OpenCartTestProject.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartTestProject.Tests
{
    [TestFixture]
    public class SearchTest : TestRunner
    {
        // DataProvider
        private static readonly object[] ProductData =
        {
            //new object[] { "mac", new List<string>() { "iMac", "MacBook", "MacBook Air", "MacBook Pro" } },
            new object[] { ProductRepository.GetMacBook(), ProductRepository.GetMacListProducts() },
        };


        //[Test, TestCaseSource(nameof(ProductData))]
        public void CheckSearch(Product product, IList<Product> expectedList)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(product);
            //
            // Check
            CollectionAssert.AreEqual(Product.GetProductListNames(expectedList),
                searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
            //
            // Return to Previous State
            HomePage homePage = searchCriteriaPage.GotoHomePage();
            //
            // Check
            Assert.IsTrue(homePage.GetSlideshow0FirstImageAttributeSrcText().Contains(HomePage.IPHONE6));
        }
    }
}
