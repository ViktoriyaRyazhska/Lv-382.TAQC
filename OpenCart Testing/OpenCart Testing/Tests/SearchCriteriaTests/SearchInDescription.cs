using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchInDescriptionTest : TestRunner
    {
        private static readonly object[] SearchNotInDescriptionData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchNotInDescription.json"), ProductRepository.Get().GetProductEmptyListMessage() )
        };

        [Test, TestCaseSource(nameof(SearchNotInDescriptionData))]
        public void CheckSearchNotInDescription(ISearchCriteria searchCriteria, string expectedMessage)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(), searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());
        }

        private static readonly object[] SearchInDescriptionData =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInDescription.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInDescription.json") )
        };

        [Test, TestCaseSource(nameof(SearchInDescriptionData))]
        public void CheckSearchInDescription(ISearchCriteria searchCriteria, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);

            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }

        //private static readonly object[] ProductDescriptionData =
        //{
        //    new TestCaseData(SearchCriteriasRepository.NewSearchCriteriaArrayFromJson("SearchByDescription.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInDescription.json") )
        //};

        //[Test, TestCaseSource(nameof(ProductDescriptionData))]
        //public void CheckSearchDescription(IList<SearchCriteria> searchCriteria, IList<Product> expectedList)
        //{

        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria[0]);
        //    Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(), searchCriteriaPage.GetProductComponentsContainer().GetEmptyListMessange());

        //    searchCriteriaPage.GotoHomePage().GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria[1]);           
        //    Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
            
        //}
    }
}
