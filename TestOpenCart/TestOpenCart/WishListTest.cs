using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UnitTestProjectLv382a
{
    [TestFixture]
    public class WishListRegisterUserTest
    {
        private IWebDriver driver;
        static readonly string adminName = Environment.GetEnvironmentVariable("adminName", EnvironmentVariableTarget.User).ToString();
        static readonly string adminPass = Environment.GetEnvironmentVariable("adminPass", EnvironmentVariableTarget.User).ToString();

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://192.168.79.128/opencart/upload/");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#top-links > ul > li.dropdown > a")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Name("email")).SendKeys(adminName);
            driver.FindElement(By.Name("password")).SendKeys(adminPass + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(2000);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }       
        //DataProvider
        private static readonly object[] Choose =
        {  new object[] { "//div[contains(@class, 'product-layout')]//a[contains(text(), 'iPhone')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']", "iPhone", "table.table.table-bordered.table-hover td.text-left a[href*='/product&product_id=40']"},
           new object[] { "//div[contains(@class, 'product-layout')]//a[contains(text(), 'MacBook')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']", "MacBook", "table.table.table-bordered.table-hover td.text-left a[href*='/product&product_id=43']"},
           new object[] { "//div[contains(@class, 'product-layout')]//a[contains(text(), 'Canon EOS 5D')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']", "Canon EOS 5D", "table.table.table-bordered.table-hover td.text-left a[href*='/product&product_id=30']"},
        };

        //[Test, TestCaseSource("Choose")]
        public void CheckRegisteredUserAddFromFeaturedTab(string itemAddToWish, string nameInWish, string itemInWish)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);           
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();            
            driver.FindElement(By.XPath(itemAddToWish)).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000);
            string actual = driver.FindElement(By.CssSelector(itemInWish)).Text;
            string expected = nameInWish;
            NUnit.Framework.Assert.AreEqual(expected, actual, $"In Wish List are no expected item: {expected}");
            Thread.Sleep(2000);
        }

        [Test]
        public void CheckRemovingAllFromWishList()
        {
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'iPhone')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'MacBook')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'Canon EOS 5D')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=40']")).Click();
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=30']")).Click();
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=43']")).Click();
            Thread.Sleep(2000);
            string actual = driver.FindElement(By.CssSelector("div[class = 'col-sm-9']>p")).Text;
            string expected = "Your wish list is empty.";
            NUnit.Framework.Assert.AreEqual(expected, actual, "There was no Message with confirmation that wish list is empty.");
            Thread.Sleep(2000);
        }     
        [Test]
        public void CheckRegisteredUserAddFromPhonesPDAsTab()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.CssSelector("a[href*='product/category&path=24']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout product-grid')]//a[contains(text(), 'HTC Touch HD')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000);
            string actual = driver.FindElement(By.CssSelector("table.table.table-bordered.table-hover td.text-left a[href*='/product&product_id=28']")).Text;
            string expected = "HTC Touch HD";
            NUnit.Framework.Assert.AreEqual(expected, actual, $"In Wish List are no expected item: {expected}");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=28']")).Click();
        }

        [Test]
        public void CheckModification()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.CssSelector("a[href*='product/category&path=24']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout product-grid')]//a[contains(text(), 'HTC Touch HD')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout product-grid')]//a[contains(text(), 'Palm Treo Pro')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=28']")).Click();
            string actual = driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;
            string expected = "Success: You have modified your wish list!\r\n×";
            NUnit.Framework.Assert.AreEqual(expected, actual, $"In Wish List are no expected item: {expected}");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=29']")).Click();

        }
    }

    [TestFixture]
    public class WishListNotRegisterUserTest
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("http://192.168.79.128/opencart/upload/");
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }
       
        [Test]
        public void CheckNotRegisteredUser()
        {
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'iPhone')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            Thread.Sleep(2000);
            string actual = driver.FindElement(By.CssSelector("div.alert.alert-success a[href*='route=account/login']")).Text;
            string expected = "login";
            NUnit.Framework.Assert.AreEqual(expected, actual, "There was no Message with offer to login or create an account");
            Thread.Sleep(2000);
        }      
    }
}