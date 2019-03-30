using NUnit.Framework;
using OpenCart_Testing.Pages;
using OpenCart_Testing.Pages.UIMapping;
using OpenCart_Testing.TestData;
using OpenCart_Testing.TestData.SimpleSearchData;
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

        private static readonly object[] SearchData_Positive1 =
        {
             new object[] {ProductRepository.GetMacBook(), ProductRepository.GetMacListProducts()}
             //new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Positive.json"))
        };

        [Test, TestCaseSource("SearchData_Positive1")]
        public void SearchTest_Positive1(Product product, IList<Product> expectedList)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems1(product);


            Assert.AreEqual(Product.GetProductListNames(expectedList), searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());


        }


        //private static readonly object[] SearchData_Positive =
        //{
        //    new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Positive.json"))
        //};

        //[Test, TestCaseSource("SearchData_Positive")]
        //public void SearchTest_Positive(SimpleSearch searchText)
        //{
        //    SearchCriteriaPage searchCriteriaPage = LoadApplication()
        //        .SearchItems(searchText.SearchData);

        //    int actual = searchCriteriaPage.FindActualCount();
        //    //int actual = int.Parse(driver.FindElement(MSearchCriteriaPage.locatorSearchItemsCount).Text.Split(' ')[5]);
        //    //List<string> searchResults = driver.FindElements(MSearchCriteriaPage.locatorSearchItemCaption)
        //    //.ToList<IWebElement>().Select(x => x.Text).ToList<string>();
        //    List<string> searchResults = driver.FindElements(MSearchCriteriaPage.locatorSearchItemCaption)
        //    .ToList<IWebElement>().Select(x => x.Text).ToList<string>();

        //    driver.Navigate().GoToUrl("http://192.168.85.129/opencart/upload/admin");
        //    driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("adminLogin"));
        //    driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("adminPassword"));
        //    driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
        //    driver.FindElement(By.Id("menu-catalog")).Click();
        //    driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
        //    driver.FindElement(By.Id("input-name")).SendKeys("%" + searchText.SearchData);
        //    driver.FindElement(By.Id("button-filter")).Click();
        //    int expected = int.Parse(driver.FindElement(By.CssSelector("div.col-sm-6.text-right")).Text.Split(' ')[5]);

        //    //Thread.Sleep(3000);//FOR PRESENTATION ONLY!

        //    Assert.AreEqual(expected, actual);

        //    for (int i = 0; i < searchResults.Count; i++)
        //    {
        //        Assert.AreEqual(true, searchResults[i].ToLower().Contains(searchText.SearchData.ToLower()));
        //    }
        //}


        private static readonly object[] SearchData_Negative =
        {
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Negative.json"),
                ActionMessageRepository.Get().ActionMessageFromJson("SimpleSearchNoProduct.json"))
        };

        [Test, TestCaseSource("SearchData_Negative")]
        public void SearchTest_Negative(SimpleSearch searchText, ActionMessage actionMessages)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            Assert.AreEqual(actionMessages.Message,
                searchCriteriaPage.GetItemNotMatchesMessage());
        }


        private static readonly object[] SearchData_InvalidLength =
        {
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_InvalidLength.json"),
                ActionMessageRepository.Get().ActionMessageFromJson("SimpleSearchMaxLength.json"))

        };

        [Test, TestCaseSource("SearchData_InvalidLength")]
        public void SearchTest_InvalidLength(SimpleSearch searchText, ActionMessage actionMessages)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            Assert.AreEqual(actionMessages.Message,
                searchCriteriaPage.GetSearchAlertMessage());
        }


        private static readonly object[] SearchData_SpecialCharacters =
        {
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_SpecialCharacters.json"),
                ActionMessageRepository.Get().ActionMessageFromJson("SimpleSearchNoProduct.json"))
        };

        [Test, TestCaseSource("SearchData_SpecialCharacters")]
        public void SearchTest_SpecialCharacters(SimpleSearch searchText, ActionMessage actionMessages)
        {
            SearchCriteriaPage searchCriteriaPage = LoadApplication()
                .SearchItems(searchText.SearchData);
            Assert.AreEqual(actionMessages.Message,
                searchCriteriaPage.GetItemNotMatchesMessage());
        }


        private static readonly object[] SearchData_Case_DefaultView =
        {
            new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Case_DefaultView.json"))
        };

        [Test, TestCaseSource("SearchData_Case_DefaultView")]
        public void SearchCaseInsensitive_Test(SimpleSearch searchText)
        {
            SearchCriteriaPage searchCriteriaPageLower = LoadApplication()
                .SearchItems(searchText.SearchData.ToLower());
            int lowerResult = searchCriteriaPageLower.FindActualCount();

            SearchCriteriaPage searchCriteriaPageUpper = LoadApplication()
                .SearchItems(searchText.SearchData.ToUpper());
            int upperResult = searchCriteriaPageUpper.FindActualCount();

            Assert.AreEqual(lowerResult, upperResult);
        }


        private static readonly object[] SearchData_Case_DefaultView1 =
        {
            new object[] {ProductRepository.GetMacBook(), ProductRepository.GetMacListProducts()}
            //new TestCaseData(SimpleSearchRepository.NewSearchDataFromJson("SearchData_Case_DefaultView.json"))
        };

        [Test, TestCaseSource("SearchData_Case_DefaultView1")]
        public void SearchCaseInsensitive_Test1(Product product, IList<Product> expectedList)
        {
            //SearchCriteriaPage searchCriteriaPage = LoadApplication()
            //    .SearchItems1(product);

            SearchCriteriaPage searchCriteriaPageLower = LoadApplication()
                .SearchItems(product.SearchKeyword.ToLower())
                 ;
            int lowerResult = searchCriteriaPageLower.FindActualCount();

            SearchCriteriaPage searchCriteriaPageUpper = LoadApplication()
                .SearchItems(product.SearchKeyword.ToUpper())
                 ;
            int upperResult = searchCriteriaPageUpper.FindActualCount();

            Assert.AreEqual(lowerResult, upperResult);
            //Assert.AreEqual(Product.GetProductListNames(expectedList), 
            //searchCriteriaPage.GetProductComponentsContainer().GetProductComponentNames());
            Assert.AreEqual(searchCriteriaPageUpper.GetProductComponentsContainer().GetProductComponentNames(),
            searchCriteriaPageLower.GetProductComponentsContainer().GetProductComponentNames());
        }

    }
}
