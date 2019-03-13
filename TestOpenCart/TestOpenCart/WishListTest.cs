using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Linq;

namespace TestOpenCart
{
    [TestFixture]
    public class WishListRegisterUserTest : TestRunner
    {
      
        //DataProvider
        private static readonly object[] Choose =
        {
           new List<string>() { "Canon EOS 5D", "iPhone", "MacBook" }
        };
        [Test, TestCaseSource("Choose")]
        public void CheckRegisteredUserAddFromFeaturedTab(List<string> expected)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);           
            driver.FindElement(By.XPath("//i[@class ='fa fa-home']")).Click();            
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'iPhone')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'MacBook')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'Canon EOS 5D')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000);
            List<string> actual = driver.FindElements(By.CssSelector("#content > div.table-responsive td.text-left > a")).ToList<IWebElement>().Select(x => x.Text).ToList();
            Assert.AreEqual(expected, actual, $"In Wish List are no expected item: {expected}");
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=40']")).Click();
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=30']")).Click();
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=43']")).Click();

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
    public class WishListNotRegisterUserTest : TestRunner
    {

        [Test]
        public void CheckNotRegisteredUser()
        {
            driver.FindElement(By.CssSelector("#top-links .dropdown-toggle")).Click();
            driver.FindElement(By.CssSelector(("#top-links a[href*='account/logout']"))).Click();
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'iPhone')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            Thread.Sleep(2000);
            string actual = driver.FindElement(By.CssSelector("div.alert.alert-success a[href*='route=account/login']")).Text;
            string expected = "login";
            NUnit.Framework.Assert.AreEqual(expected, actual, "There was no Message with offer to login or create an account");
            Thread.Sleep(2000);
        }      
    }
}