﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace OpenCartAutomation
{
    [TestFixture]
    public abstract class ReviewTestRunner : TestRunner
    {
        protected static readonly string currentDate = DateTime.Now.ToString("dd/MM/yyyy");
        protected const string testProductPageAddress = "http://192.168.244.134/opencart/upload/index.php?route=product/product&product_id=40";
        protected const string ValidReviewName = "TestName";
        protected const string validReviewText = "Some test text for valid input Review text(>25 count)";
        protected const byte validRating = 5;
        protected static readonly string[] reviewErrorMess = {
            "Warning: Review Name must be between 3 and 25 characters!",
            "Warning: Review Text must be between 25 and 1000 characters!",
            "Warning: Please select a review rating!",
            "Warning: Review Name cant containe forbited characters",
            "Warning: Review Text cant containe forbited characters"
        };
        protected static readonly string adminName = Environment.GetEnvironmentVariable("adminName", EnvironmentVariableTarget.User).ToString();
        protected static readonly string adminPass = Environment.GetEnvironmentVariable("adminPass", EnvironmentVariableTarget.User).ToString();
        protected const string adminPage = "http://192.168.244.134/opencart/upload/admin/";
        protected string adminURL;
        protected const string TooLongTextReview1001char = "TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMore" +
           "Than1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDat" +
           "aMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000Test" +
           "DataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan10001";

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
            driver.FindElement(By.CssSelector("#button-review")).Click();
        }

        protected void GoToAdminPanelReview()
        {
            driver.Navigate().GoToUrl(adminURL);
            driver.FindElement(By.CssSelector(".fa.fa-tags.fw")).Click();
            driver.FindElement(By.CssSelector("#menu-catalog a[href*='catalog/review']")).Click();
        }
    }
}
