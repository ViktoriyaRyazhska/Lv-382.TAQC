using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.UIMapping;
using OpenCart_Testing.TestData;
using OpenCart_Testing.TestData.SimpleSearchData;
using OpenCart_Testing.Tools;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests.SimpleSearchTests
{
    [TestFixture]
    public class SearchFieldTests : TestRunner
    {

        private static readonly object[] SearchData_Positive =
        {
             new object[] { SimpleSearchRepository.NewSearchDataFromJson("SearchData_Case_DefaultView.json"), ProductRepository.GetMacListProducts()}
        };

        [Test, TestCaseSource("SearchData_Positive")]
        public void SearchTest_Positive(SimpleSearch searchText, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }


        //private static readonly object[] SearchData_Positive =
        //{
        //     new object[] {ProductRepository.GetMacBook(), ProductRepository.GetMacListProducts()}
        //};

        //[Test, TestCaseSource("SearchData_Positive")]
        //public void SearchTest_Positive(Product product, IList<Product> expectedList)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems1(product);
        //    Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        //}


        private static readonly object[] SearchData_Negative =
            ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Negative.json"));

        [Test, TestCaseSource("SearchData_Negative")]
        public void SearchTest_Negative(SimpleSearchView searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(),
                searchCriteriaPage.GetItemNotMatchesMessage());
        }


        //private static readonly object[] SearchData_Negative =
        //{
        //    new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Negative.json"),
        //        ProductRepository.Get().GetProductEmptyListMessage())
        //};

        //[Test, TestCaseSource("SearchData_Negative")]
        //public void SearchTest_Negative(SimpleSearch searchText, string noexistTextMessage)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(searchText.SearchData);
        //    Assert.AreEqual(noexistTextMessage,
        //        searchCriteriaPage.GetItemNotMatchesMessage());
        //}


        
        private static readonly object[] SearchData_InvalidLength =
            ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_InvalidLength.json"));

        [Test, TestCaseSource("SearchData_InvalidLength")]
        public void SearchTest_InvalidLength(SimpleSearchView searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(ProductRepository.Get().GetProductMaxLengthMessage(),
                searchCriteriaPage.GetSearchAlertMessage());
        }


        private static readonly object[] SearchData_SpecialCharacters =
        {
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_SpecialCharacters.json"),
                ProductRepository.Get().GetProductEmptyListMessage())
        };

        [Test, TestCaseSource("SearchData_SpecialCharacters")]
        public void SearchTest_SpecialCharacters(SimpleSearch searchText, string noneexistTextMessage)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            Assert.AreEqual(noneexistTextMessage,
                searchCriteriaPage.GetItemNotMatchesMessage());
        }


        private static readonly object[] SearchData_Case_DefaultView =
        {
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Case_DefaultView.json"))
            //SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json")[0],
            //SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json")[1],
            //SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json")[2],
            //SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json")[3]
        };

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchCaseInsensitive_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPageLower = LoadApplication()
                .SearchItems(searchText.SearchData.ToLower());
            IList<string> lowerSearchItems = searchCriteriaPageLower.GetProductComponentsContainer().GetProductComponentNames();

            SearchCriteriaPage searchCriteriaPageUpper = LoadApplication()
                .SearchItems(searchText.SearchData.ToUpper());
            IList<string> upperSearchItems = searchCriteriaPageUpper.GetProductComponentsContainer().GetProductComponentNames();

            Assert.AreEqual(lowerSearchItems, upperSearchItems);
        }
    }
}
