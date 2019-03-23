using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Tests.SimpleSearchTests
{
    [TestFixture]
    public class SearchViewTests : TestRunner
    {
        //[Test, TestCaseSource("SearchData_Case_DefaultView")]
        //public void SearchDefaultView_Test(string searchText)
        //{
        //    driver.FindElement(By.Name("search")).Clear();
        //    driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);

        //    bool actual = hasClass(driver.FindElement(By.Id("grid-view")), "active");
        //    Assert.AreEqual(true, actual);
        //}

        //[Test, TestCaseSource("SearchData_Case_DefaultView")]
        //public void SearchSavedView_Test(string searchText)
        //{
        //    driver.FindElement(By.Name("search")).Clear();
        //    driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
        //    bool wasGrid = false;

        //    Thread.Sleep(3000);//FOR PRESENTATION ONLY!

        //    if (hasClass(driver.FindElement(By.Id("grid-view")), "active"))
        //    {
        //        driver.FindElement(By.Id("list-view")).Click();
        //        wasGrid = true;
        //    }
        //    else
        //    {
        //        driver.FindElement(By.Id("grid-view")).Click();
        //    }

        //    Thread.Sleep(3000);//FOR PRESENTATION ONLY!

        //    driver.Navigate().GoToUrl(homePageUrl);
        //    driver.FindElement(By.Name("search")).Clear();
        //    driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);

        //    Thread.Sleep(3000);//FOR PRESENTATION ONLY!

        //    Assert.AreEqual(!wasGrid, hasClass(driver.FindElement(By.Id("grid-view")), "active"));
        //}

        //[Test, TestCaseSource("SearchData_Case_DefaultView")]
        //public void SearchChangeViewNumberOfElements_Test(string searchText)
        //{
        //    driver.FindElement(By.Name("search")).Clear();
        //    driver.FindElement(By.Name("search")).SendKeys(searchText + Keys.Enter);
        //    int beforeChange = int.Parse(driver.FindElement(By.CssSelector(".col-sm-6.text-right")).Text.Split(' ')[5]);
        //    if (hasClass(driver.FindElement(By.Id("grid-view")), "active"))
        //    {
        //        driver.FindElement(By.Id("list-view")).Click();
        //    }
        //    else
        //    {
        //        driver.FindElement(By.Id("grid-view")).Click();
        //    }
        //    int afterChange = int.Parse(driver.FindElement(By.CssSelector(".col-sm-6.text-right")).Text.Split(' ')[5]);

        //    Assert.AreEqual(beforeChange, afterChange);
        //}
    }
}
