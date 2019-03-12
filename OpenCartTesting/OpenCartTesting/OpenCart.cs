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
    public class OpenCartTesting
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
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/index.php?route=product/search");
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys(searchText + Keys.Enter);

            string ExpectedResult = "There is no product that matches the search criteria.";
            string ActualResult = driver.FindElement(By.XPath("//*[@id='content']/p[2]")).Text;

            Assert.AreEqual(ExpectedResult, ActualResult);
            driver.Quit();
        }

        private static readonly object[] SearchData_WithСlickingDescription =
       {
          "video",
          "19",
          "HS"
        };
        private object content;

        [Test, TestCaseSource("SearchData_WithСlickingDescription")]
        public void SearchCase_WithClickingDescription_Test(string searchText)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/index.php?route=product/search");
            driver.FindElement(By.Id("description")).Click();          
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys(searchText + Keys.Enter);

            int ActualNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);

            bool Bool()
            {
                if (ActualNumber > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            bool ActualResult = Bool();

            Assert.AreEqual(true, ActualResult);
            driver.Quit();
        }


        [Test]
        public void SearchCase_AllCategories_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/index.php?route=product/search");
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac" + Keys.Enter);

            int ActualNumber = int.Parse(driver.FindElement(By.CssSelector("#content div.col-sm-6.text-right")).Text.Split(' ')[5]);

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/admin");
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");           
            driver.FindElement(By.CssSelector("#content div.text-right button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("input-name")).SendKeys("%" + "mac");
            driver.FindElement(By.Id("button-filter")).Click();
            int ExpectedNumber = int.Parse(driver.FindElement(By.CssSelector("#content > div.container-fluid > div > div.panel-body > div.row > div.col-sm-6.text-right")).Text.Split(' ')[5]);

            Assert.AreEqual(ExpectedNumber, ActualNumber);
            driver.Quit();
                    
        }

        [Test]
        public void SearchCase_LaptopCategories_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/index.php?route=product/search");
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']//select[@name='category_id']/option[5]")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("lenovo" + Keys.Enter);

            string ActualCategorie = driver.FindElement(By.XPath("//*[@id='content']//select[@name='category_id']/option[5]")).Text;

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/admin");
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("lenovo");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategorie = driver.FindElement(By.CssSelector("#product-category18")).Text;

            Assert.AreEqual(ExpectedCategorie, ActualCategorie);
            driver.Quit();
        }

        [Test]
        public void SearchCase_DesktopCategorie_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/index.php?route=product/search");
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/select/option[2]")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac" + Keys.Enter);

            string ActualCategorie = driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/select/option[2]")).Text;

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/admin");
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("mac");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr:nth-child(1) > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategorieOne = driver.FindElement(By.CssSelector("#product-category20")).Text;

            driver.FindElement(By.CssSelector("#content > div.page-header > div > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr:nth-child(2) > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategorieTwo = driver.FindElement(By.CssSelector("#product-category20")).Text;

            bool EqualCategories()
            {
                if (ActualCategorie == ExpectedCategorieOne && ActualCategorie == ExpectedCategorieTwo)
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
            driver.Quit();
        }

        [Test]
        public void SearchCase_SubcaregorieMac_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/index.php?route=product/search");
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div/div[2]/select/option[2]")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div/div[3]/label/input")).Click();
            driver.FindElement(By.Id("input-search")).Click();
            driver.FindElement(By.Id("input-search")).Clear();
            driver.FindElement(By.Id("input-search")).SendKeys("mac" + Keys.Enter);
            driver.FindElement(By.Name("category_id")).Click();
            driver.FindElement(By.XPath("//*[@id='content']/div[1]/div[2]/select/option[4]")).Click();
            driver.FindElement(By.Id("button-search")).Click();

            string ActualCategorie = driver.FindElement(By.XPath("//*[@id='content']/div[1]/div[2]/select/option[4]")).Text.Split(' ')[6];

            driver.Navigate().GoToUrl("http://192.168.150.130/opencart/upload/admin");
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("%mac");
            driver.FindElement(By.Id("button-filter")).Click();
            driver.FindElement(By.CssSelector("#form-product > div > table > tbody > tr:nth-child(1) > td:nth-child(8) > a")).Click();
            driver.FindElement(By.CssSelector("#form-product > ul > li:nth-child(3) > a")).Click();

            string ExpectedCategorie = driver.FindElement(By.CssSelector("#product-category27")).Text.Split(' ')[2];

            Assert.AreEqual(ActualCategorie, ExpectedCategorie);
            driver.Quit();
        }
    }
}
