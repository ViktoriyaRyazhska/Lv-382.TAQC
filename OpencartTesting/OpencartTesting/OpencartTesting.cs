using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace OpencartTesting
{
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class OpencartTesting
    {
        private static readonly object[] SearchData_Positive =
        {
           "a",
           "i",
           "mac",
           "TestProductWith255SymbolsTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTe"
        };
        [Test, TestCaseSource("SearchData_Positive")]
        public void SearchTest_Positive(string searchText)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl("http://192.168.204.128/opencart/upload");
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            int actual = int.Parse(driver.FindElement(By.CssSelector("#content > div:nth-child(9) > div.col-sm-6.text-right")).Text.Split(' ')[5]);

            driver.Navigate().GoToUrl("http://192.168.204.128/opencart/upload/admin");
            driver.FindElement(By.Id("input-username")).SendKeys("admin");
            driver.FindElement(By.Id("input-password")).SendKeys("Lv382_Taqc");
            driver.FindElement(By.CssSelector("#content > div > div > div > div > div.panel-body > form > div.text-right > button")).Click();
            driver.FindElement(By.Id("menu-catalog")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog > ul > li:nth-child(2) > a")).Click();
            driver.FindElement(By.Id("input-name")).SendKeys("%" + searchText);
            driver.FindElement(By.Id("button-filter")).Click();
            int expected = int.Parse(driver.FindElement(By.CssSelector("#content > div.container-fluid > div > div.panel-body > div.row > div.col-sm-6.text-right")).Text.Split(' ')[5]);
            Assert.AreEqual(expected, actual);
            driver.Quit();
        }

        private static string[] SearchData_Negative()
        {
            string path = @"D:\Projects\Soft\Lv-382.TAQC\OpencartTesting\OpencartTesting\bin\NegativeTestData.txt";
            return File.ReadAllLines(path).TakeWhile(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        }

        [Test, TestCaseSource("SearchData_Negative")]
        public void SearchTest_Negative(string searchText)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("http://192.168.204.128/opencart/upload");
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);
            Assert.AreEqual(true,driver.FindElements(By.CssSelector("#content > p:nth-child(7)")).Count > 0);
            driver.Quit();
        }

        private static readonly object[] SearchData_Case_DefaultPresentation =
       {
           "mac",
           "a",
           "i",
           "book"
        };
        [Test, TestCaseSource("SearchData_Case_DefaultPresentation")]
        public void SearchCaseInsensitive_Test(string searchText)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl("http://192.168.204.128/opencart/upload");
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText.ToLower() + OpenQA.Selenium.Keys.Enter);
            int lowerResult = int.Parse(driver.FindElement(By.CssSelector("#content > div:nth-child(9) > div.col-sm-6.text-right")).Text.Split(' ')[5]);

            driver.Navigate().GoToUrl("http://192.168.204.128/opencart/upload");
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText.ToUpper() + OpenQA.Selenium.Keys.Enter);
            int upperResult = int.Parse(driver.FindElement(By.CssSelector("#content > div:nth-child(9) > div.col-sm-6.text-right")).Text.Split(' ')[5]);
 
            Assert.AreEqual(lowerResult,upperResult);
            driver.Quit();
        }

        [Test, TestCaseSource("SearchData_Case_DefaultPresentation")]
        public void SearchDefaultPresentation_Test(string searchText)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            driver.Navigate().GoToUrl("http://192.168.204.128/opencart/upload");
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(searchText + OpenQA.Selenium.Keys.Enter);

            bool actual = hasClass(driver.FindElement(By.Id("grid-view")));
            Assert.AreEqual(true, actual);
            driver.Quit();
        }
        private bool hasClass(IWebElement element)
        {
            string[] classes = element.GetAttribute("class").Split(' ');
            foreach(string str in classes)
            { 
                if (str.Equals("active"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
