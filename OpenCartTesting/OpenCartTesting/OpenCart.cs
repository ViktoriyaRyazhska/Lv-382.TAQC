using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace OpenCartTesting
{
    //[TestClass]
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
            driver.FindElement(By.Id("input-search")).SendKeys(searchText + Keys.Enter);

            string ExpectedResult = "There is no product that matches the search criteria.";
            string ActualResult = driver.FindElement(By.XPath("//*[@id='content']/p[2]")).Text;

            Assert.AreEqual(ExpectedResult, ActualResult);          
        }

        private static readonly object[] SearchData_WithСlickingDescription =
       {
          "video",
          "19",
          "HS"
        };
        
        [Test, TestCaseSource("SearchData_WithСlickingDescription")]
        public void SearchCase_WithClickingDescription_Test(string searchText)
        {                     
            driver.FindElement(By.Id("description")).Click();          
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys(searchText + Keys.Enter);

            int ActualNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);

            Assert.AreEqual(true, ActualNumber > 0);            
        }


        [Test]
        public void SearchCase_AllCategories_Test()
        {           
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac" + Keys.Enter);

            int ActualNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);                      
            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("Admin_Login"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("Admin_Password"));
            //driver.FindElement(By.Id("input-username")).SendKeys("admin");
            //driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content div.text-right button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-name")).SendKeys("%" + "mac");
            driver.FindElement(By.Id("button-filter")).Click();
            int ExpectedNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);

            Assert.AreEqual(ExpectedNumber, ActualNumber);                           
        }

        [Test]
        public void SearchCase_LaptopCategories_Test()
        {           
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']//select[@name='category_id']/option[5]")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("lenovo" + Keys.Enter);

            string ActualCategory = driver.FindElement(By.XPath("//*[@id='content']//select[@name='category_id']/option[5]")).Text;

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("lenovo");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategory = driver.FindElement(By.CssSelector("#product-category18")).Text;

            Assert.AreEqual(ExpectedCategory, ActualCategory);           
        }

        [Test]
        public void SearchCase_CaregoryWithoutSubcategory_Test()
        {         
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/select/option[2]")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac" + Keys.Enter);

            string ActualCategory = driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/select/option[2]")).Text;

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("mac");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr:nth-child(1) > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategoryOne = driver.FindElement(By.CssSelector("#product-category20")).Text;

            driver.FindElement(By.CssSelector("#content > div.page-header > div > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr:nth-child(2) > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategoryTwo = driver.FindElement(By.CssSelector("#product-category20")).Text;

            bool EqualCategories()
            {
                if (ActualCategory.Equals(ExpectedCategoryOne) && ActualCategory.Equals(ExpectedCategoryTwo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            bool ActualResult = EqualCategories();
            Assert.AreEqual(true, ActualResult);        
        }

        [Test]
        public void SearchCase_CaregoryWithSubcategory_Test()
        {            
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/select/option[2]")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/label/input")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac" + Keys.Enter);
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div[1]/div[2]/select/option[4]")).Click();
            driver.FindElement(By.Id("button-search")).Click();

            string ActualCategory = driver.FindElement(By.XPath("//*[@id='content']/div[1]/div[2]/select/option[4]")).Text.Split(' ')[6];

            driver.Navigate().GoToUrl(adminPageUrl);
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("%mac");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr:nth-child(1) > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategory = driver.FindElement(By.CssSelector("#product-category27")).Text.Split(' ')[2];

            Assert.AreEqual(ActualCategory, ExpectedCategory);            
        }
    }
}
