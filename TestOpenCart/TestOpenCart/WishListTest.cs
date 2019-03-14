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
            driver.FindElement(By.XPath("//i[@class ='fa fa-home']")).Click();            
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'iPhone')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'MacBook')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'Canon EOS 5D')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            List<string> actual = driver.FindElements(By.CssSelector("#content > div.table-responsive td.text-left > a")).ToList<IWebElement>().Select(x => x.Text).ToList();
            Assert.AreEqual(expected, actual, $"In Wish List are no expected item: {expected}");
            Thread.Sleep(2000); // For Presentation ONLY
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
            Thread.Sleep(2000); // For Presentation ONLY
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=40']")).Click();
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=30']")).Click();
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=43']")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            int actualForRemoving = driver.FindElements(By.CssSelector("#content > div.table-responsive td.text-left > a")).Count;
            Assert.AreEqual(0, actualForRemoving, "Not all elements was removed from Wish list");
            Thread.Sleep(2000); // For Presentation ONLY
        }

        [Test]
        public void CheckMessageAfterRemovingAll()
        {
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'MacBook')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'Canon EOS 5D')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000); // For Presentation ONLY          
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=30']")).Click();
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=43']")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            string actual = driver.FindElement(By.CssSelector("div[class = 'col-sm-9']>p")).Text;
            string expected = "Your wish list is empty.";
            Assert.AreEqual(actual, expected, $"After removing all elements was message{actual} instead of {expected}");
            Thread.Sleep(2000); // For Presentation ONLY
        }

        [Test]
        public void CheckMessageAfterRemovingOneItem()
        {
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.CssSelector("a[href*='product/category&path=24']")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout product-grid')]//a[contains(text(), 'HTC Touch HD')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout product-grid')]//a[contains(text(), 'Palm Treo Pro')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=28']")).Click();
            string actual = driver.FindElement(By.CssSelector("div.alert.alert-success")).Text;
            string expected = "Success: You have modified your wish list!\r\n×";
            Assert.AreEqual(actual,expected, $"After removing one element was message{actual} instead of {expected}");
            Thread.Sleep(2000); // For Presentation ONLY
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=29']")).Click();
        }

        [Test]
        public void CheckRegisteredUserAddFromPhonesPDAsTab()
        {
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.CssSelector("a[href*='product/category&path=24']")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout product-grid')]//a[contains(text(), 'HTC Touch HD')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            driver.FindElement(By.CssSelector("#wishlist-total > i")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            string actual = driver.FindElement(By.CssSelector("table.table.table-bordered.table-hover td.text-left a[href*='/product&product_id=28']")).Text;
            string expected = "HTC Touch HD";
            Assert.AreEqual(expected, actual, $"In Wish List are no expected item: {expected}");
            Thread.Sleep(2000); // For Presentation ONLY
            driver.FindElement(By.CssSelector("td[class = 'text-right']>a[href*= '/wishlist&remove=28']")).Click();
        }

        [Test]
        public void CheckNotRegisteredUser()
        {
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.CssSelector("#top-links .dropdown-toggle")).Click();
            driver.FindElement(By.CssSelector(("#top-links a[href*='account/logout']"))).Click();
            driver.FindElement(By.XPath("//i[@class = 'fa fa-home']")).Click();
            driver.FindElement(By.XPath("//div[contains(@class, 'product-layout')]//a[contains(text(), 'iPhone')]/../../following-sibling::div/button[@data-original-title='Add to Wish List']")).Click();
            Thread.Sleep(2000); // For Presentation ONLY
            string actual = driver.FindElement(By.CssSelector("div.alert.alert-success a[href*='route=account/login']")).Text;
            string expected = "login";
            Assert.AreEqual(expected, actual, "There was no Message with offer to login or create an account");
            Thread.Sleep(2000); // For Presentation ONLY
        }
    }
}