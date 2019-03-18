using NUnit.Framework;
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
        private static readonly object[] Products =
        {
            new object[] { "mac", new List<string>() { "iMac", "MacBook", "MacBook Air", "MacBook Pro" } },
        };


        [Test, TestCaseSource(nameof(Products))]
        public void CheckSearch(string productName, IList<string> expectedList)
        {
            // Steps
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(productName);
            //
            // Check
            CollectionAssert.AreEqual(expectedList,
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
