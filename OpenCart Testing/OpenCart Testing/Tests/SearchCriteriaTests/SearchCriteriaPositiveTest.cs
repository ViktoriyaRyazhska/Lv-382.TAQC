using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.TestData;
using System.Collections.Generic;

namespace OpenCart_Testing.Tests.SearchCriteriaTests
{
    [TestFixture]
    public class SearchCriteriaPositiveTest : TestRunner
    {
        private static readonly object[] SearchInCategoriesAndSubcategoriesData_Positive =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInAllCategories.json"), ProductRepository.NewProductArrayFromJson("MacListProducts.json")),
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategory.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInCategory.json")),
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoryAndSubcategories.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInCategoryAndSubcategory.json"))
        };

        [Test, TestCaseSource(nameof(SearchInCategoriesAndSubcategoriesData_Positive))]
        public void CheckSearchInCategoryAndSubcategories(SearchCriteria searchCriteria, List<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }


        private static readonly object[] SearchInDescriptionData_Positive =
        {
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInDescriptionNumber.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInDescriptionNumber.json")),
            new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInDescriptionWord.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInDescriptionWord.json"))           
        };

        [Test, TestCaseSource(nameof(SearchInDescriptionData_Positive))]
        public void CheckSearchInDescription(SearchCriteria searchCriteria, List<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }

        private static readonly object[] SearchInDescriptionAndCategoriesData_Positive =
        {
             new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInCategoryAndDescription.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInCategoryAndDescription.json")),
             new TestCaseData(SearchCriteriasRepository.Get().NewSearchCriteriaFromJson("SearchInSubcategoriesAndDescription.json"), ProductRepository.NewProductArrayFromJson("ProductsSearchInSubcategoryAndDescription.json"))
        };

        [Test, TestCaseSource(nameof(SearchInDescriptionAndCategoriesData_Positive))]
        public void CheckSearchInDescriptionAndCategories(SearchCriteria searchCriteria, List<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .GoToSearchCriteriaPage().SearchCriteriaItems(searchCriteria);
            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
        }
    }
}
