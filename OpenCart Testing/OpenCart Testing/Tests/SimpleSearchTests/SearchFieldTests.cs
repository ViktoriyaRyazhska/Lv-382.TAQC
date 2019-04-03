using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using OpenCart_Testing.TestData.SimpleSearchData;
using OpenCart_Testing.Tools;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.SimpleSearchTests
{
    [TestFixture]
    public class SearchFieldTests : TestRunner
    {
        private static readonly object[] SearchData_Positive =
        {
             new object[] { SimpleSearchRepository.NewSearchDataFromJson("SearchData_Positive.json"),
                ProductRepository.NewProductArrayFromJson("MacListProducts.json")}
        };

        [Test, TestCaseSource("SearchData_Positive")]
        public void SearchTest_Positive(SimpleSearch searchText, List<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(Product.GetProductListNames(expectedList),
                searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }


        private static readonly object[] SearchData_Negative =
            ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Negative.json"));

        [Test, TestCaseSource("SearchData_Negative")]
        public void SearchTest_Negative(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(),
                searchCriteriaPage.GetItemNotMatchesMessage());
        }


        private static readonly object[] SearchData_InvalidLength =
            ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_InvalidLength.json"));

        [Test, TestCaseSource("SearchData_InvalidLength")]
        public void SearchTest_InvalidLength(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(ProductRepository.Get().GetProductMaxLengthMessage(),
                searchCriteriaPage.GetSearchAlertMessage());
        }


        private static readonly object[] SearchData_SpecialCharacters =
           ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_SpecialCharacters.json"));

        [Test, TestCaseSource("SearchData_SpecialCharacters")]
        public void SearchTest_SpecialCharacters(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.Name);
            Assert.AreEqual(ProductRepository.Get().GetProductEmptyListMessage(),
                searchCriteriaPage.GetItemNotMatchesMessage());
        }


        private static readonly object[] SearchData_Case_DefaultView =
            ListUtils.ToMultiArray(SimpleSearchRepository.NewDataListFromJson("SearchData_Case_DefaultView.json"));

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchCaseInsensitive_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPageLower = LoadApplication()
                .SearchItems(searchText.Name.ToLower());
            IList<string> lowerSearchItems = searchCriteriaPageLower.GetProductComponentsContainer().GetProductComponentNames();

            SearchCriteriaPage searchCriteriaPageUpper = LoadApplication()
                .SearchItems(searchText.Name.ToUpper());
            IList<string> upperSearchItems = searchCriteriaPageUpper.GetProductComponentsContainer().GetProductComponentNames();

            Assert.AreEqual(lowerSearchItems, upperSearchItems);
        }
    }
}
