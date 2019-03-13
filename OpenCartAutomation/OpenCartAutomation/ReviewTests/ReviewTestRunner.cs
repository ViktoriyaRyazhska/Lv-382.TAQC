using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartAutomation
{
    [TestFixture]
    public abstract class ReviewTestRunner : TestRunner
    {
        protected const string currentDate = "12/03/2019";
        protected const string testProductPageAddress = "http://192.168.244.133/opencart/upload/index.php?route=product/product&product_id=40";
        protected const string ValidReviewName = "TestName";
        protected const string validReviewText = "Some test text for valid input Review text(>25 count)";
        protected static readonly string[] reviewErrorMess = {
            "Warning: Review Name must be between 3 and 25 characters!",
            "Warning: Review Text must be between 25 and 1000 characters!",
             "Warning: Please select a review rating!"
        };
        protected static readonly string adminName = Environment.GetEnvironmentVariable("adminName", EnvironmentVariableTarget.User).ToString();
        protected static readonly string adminPass = Environment.GetEnvironmentVariable("adminPass", EnvironmentVariableTarget.User).ToString();
        protected const string adminPage = "http://192.168.244.133/opencart/upload/admin/";
        protected string adminURL;
        [OneTimeSetUp]
        protected override void BeforeAllTests()
        {
            base.BeforeAllTests();
            adminURL = AdminPageURL();
            ClearAfterTest();
        }
        [TearDown]
        protected override void AfterEachTest()
        {
            base.AfterEachTest();
            ClearAfterTest();
        }
        protected string AdminPageURL()
        {
            driver.Navigate().GoToUrl(adminPage);
            driver.FindElement(By.CssSelector("input[name='username']")).SendKeys(adminName);
            driver.FindElement(By.CssSelector("input[name='password']")).SendKeys(adminPass);
            driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            return driver.Url;
        }
        protected void ClearAfterTest()
        {
            GoToAdminPanelReview();
            this.driver.FindElement(By.CssSelector(".table.table-bordered.table-hover>thead>tr>td:nth-child(1)>input")).Click();
            this.driver.FindElement(By.CssSelector(".btn.btn-danger")).Click();
            this.driver.SwitchTo().Alert().Accept();
            Thread.Sleep(100);
        }
        protected void CreateAndConfirmReview(string yourName, string yourReview, byte rating)
        {
            CreateReview(yourName, yourReview, rating);
            GoToAdminPanelReview();
            this.driver.FindElement(By.CssSelector(".btn.btn-primary")).Click();
            this.driver.FindElement(By.CssSelector("#input-status>option[value='1']")).Click();
            this.driver.FindElement(By.CssSelector("button[type = 'submit']")).Click();
        }
        protected void CreateReview(string yourName, string yourReview, byte rating = 5)
        {
            this.driver.Navigate().GoToUrl(testProductPageAddress);
            this.driver.FindElement(By.CssSelector("a[href='#tab-review']")).Click();
            this.driver.FindElement(By.CssSelector("input[name='name']")).SendKeys(yourName);
            this.driver.FindElement(By.CssSelector("textarea[name='text']")).SendKeys(yourReview);
            if (rating >= 1 && rating <= 5)
            {
                driver.FindElement(By.CssSelector($"input[value='{rating}']")).Click();
            }
            this.driver.FindElement(By.CssSelector("#button-review")).Click();
        }
        protected void GoToAdminPanelReview()
        {
            this.driver.Navigate().GoToUrl(adminURL);
            driver.FindElement(By.CssSelector(".fa.fa-tags.fw")).Click();
            driver.FindElement(By.CssSelector("li[id='menu-catalog']>ul>li:nth-child(9)>a")).Click();
        }
    }
}
