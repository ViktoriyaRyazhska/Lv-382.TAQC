using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace OpenCartTesting
{

    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class OpenCartTesting : TestRunner
    {

        private static readonly object[] SearchData_WithoutСlickingDescription =
        {
           "video",
           "19",
           "HS"
        };

        [Test, TestCaseSource("SearchData_WithoutСlickingDescription")]
        public void SearchCase_WithoutClickingDescription_Test(string searchText)
        {
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys(searchText);
            driver.FindElement(By.Id("button-search")).Click();

            string ExpectedResult = "There is no product that matches the search criteria.";
            string ActualResult = driver.FindElement(By.XPath("//*[@id='content']/p[2]")).Text;
            int ActualNumber = int.MinValue;
            if (ActualResult == ExpectedResult)
                ActualNumber = 0;

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("Admin_Login"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("Admin_Password"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-name")).SendKeys("%" + searchText);
            driver.FindElement(By.Id("button-filter")).Click();

            int ExpectedNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);
            Assert.AreEqual(ActualNumber, ExpectedNumber);
        }

        private static readonly object[] SearchData_WithСlickingDescription =
        {
          new string[]{"video", "HTC"},
          new string[]{"19", "Palm"},
          new string[]{"HS", "Samsung Galaxy"},
        };

        [Test, TestCaseSource("SearchData_WithСlickingDescription")]
        public void SearchCase_WithClickingDescription_Test(string[] searchText)
        {
            driver.FindElement(By.Id("description")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys(searchText[0]);
            driver.FindElement(By.Id("button-search")).Click();

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("Admin_Login"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("Admin_Password"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-name")).SendKeys(searchText[1]);
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.XPath("//table[@class='table table-bordered table-hover']/tbody/tr/td[8]/a")).Click();

            string description = driver.FindElement(By.XPath("//div[@class='note-editable panel-body']/p[1]")).Text;
            Assert.AreEqual(true, description.ToLower().Contains(searchText[0].ToLower()));
        }


        [Test]
        public void SearchCase_AllCategories_Test()
        {
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac");
            driver.FindElement(By.Id("button-search")).Click();

            int ActualNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("Admin_Login"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("Admin_Password"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-name")).SendKeys("%" + "mac");
            driver.FindElement(By.Id("button-filter")).Click();

            int ExpectedNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);
            Assert.AreEqual(ExpectedNumber, ActualNumber);
        }

        [Test]
        public void SearchCase_Category_Test()
        {
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//select[@class='form-control']/option[5]")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("lenovo");
            driver.FindElement(By.Id("button-search")).Click();

            string ActualCategory = driver.FindElement(By.XPath("//select[@class='form-control']/option[5]")).Text;

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("Admin_Login"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("Admin_Password"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            Thread.Sleep(2000); // only for presenatation
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("lenovo");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.XPath("//table[@class='table table-bordered table-hover']/tbody/tr/td[8]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='form-product']/ul/li[3]/a")).Click();

            string ExpectedCategory = driver.FindElement(By.CssSelector("#product-category18")).Text;
            Assert.AreEqual(ExpectedCategory, ActualCategory);
        }

        [Test]
        public void SearchCase_WithSubcategory_Test()
        {
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//select[@class='form-control']/option[2]")).Click();
            driver.FindElement(By.XPath("//input[@name='sub_category']")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac");
            driver.FindElement(By.Id("button-search")).Click();
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//select[@class='form-control']/option[4]")).Click();
            driver.FindElement(By.Id("button-search")).Click();
            
            string ActualCategory = driver.FindElement(By.XPath("//select[@class='form-control']/option[4]")).Text.Trim();

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("Admin_Login"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("Admin_Password"));
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/product']")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("%mac");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.XPath("//table[@class='table table-bordered table-hover']/tbody/tr/td[8]/a")).Click();
            driver.FindElement(By.XPath("//ul[@class='nav nav-tabs']/li[3]/a")).Click();
           
            string ExpectedCategory = driver.FindElement(By.CssSelector("#product-category27")).Text;
            Assert.AreEqual(true, ExpectedCategory.ToLower().Contains(ActualCategory.ToLower()));
            
        }
    }
}
