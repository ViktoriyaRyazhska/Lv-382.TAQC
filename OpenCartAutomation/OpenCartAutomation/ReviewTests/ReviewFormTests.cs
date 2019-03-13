using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Linq;

namespace OpenCartAutomation
{
    [TestFixture]
    public partial class ReviewFormTests : ReviewTestRunner
    {
        static readonly object[] TestDataCreateReviewValid =
{
              new object[] { "iPhone", "3ch", "1", "Disabled", currentDate, "Sometext25charactersherel" },
              new object[] { "iPhone", "12characters", "3", "Disabled", currentDate, "Sometext50charactersherelSometext50charactersherel" },
              new object[] { "iPhone", "Somename25charactersherel", "5", "Disabled", currentDate, TooLongTextReview1001char.Substring(0,1000) }
        };
        [Test(Description = "Positive Test"), TestCaseSource("TestDataCreateReviewValid")]
        public void ReviewTest_CreateWithValidData(object[] data)
        {
            CreateReview(data[1].ToString(), data[5].ToString(), byte.Parse(data[2].ToString()));
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement validAlert = this.driver.FindElement(By.CssSelector("div[class='alert alert-success']"));
            Assert.AreEqual("Thank you for your review. It has been submitted to the webmaster for approval.", validAlert.Text);
            GoToAdminPanelReview();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement[] review = this.driver.FindElements(By.CssSelector(".table.table-bordered.table-hover>tbody>tr:nth-child(1)>td")).ToArray();
            for (int i = 1; i <= 5; i++)
            {
                Assert.AreEqual(data[i - 1], review[i].Text);
            }
        }
        static object[] DataForCreateWithEmptyList =
        {
            new object[] { "", validReviewText, reviewErrorMess[0] },
            new object[] { ValidReviewName, "", reviewErrorMess[1] },
        };
        [Test(Description = "Negative Test"), TestCaseSource("DataForCreateWithEmptyList")]
        public void ReviewsTest_CreateWithEmpryFields(string yourName, string yourReview, string ErrorMess)
        {
            CreateReview(yourName, yourReview);
            IWebElement error = driver.FindElement(By.CssSelector("div[class='alert alert-danger']"));
            Assert.AreEqual(ErrorMess, error.Text);
            GoToAdminPanelReview();
            IWebElement reviewAdmList = driver.FindElement(By.CssSelector("td.text-center[colspan = '7']"));
            Assert.AreEqual("No results!", reviewAdmList.Text);
        }
        [Test(Description = "Negative Test")]
        public void ReviewTest_CreateWithNotSelectedRating()
        {
            CreateReview(ValidReviewName, validReviewText, 0); // 0 = Not selected
            IWebElement error = this.driver.FindElement(By.CssSelector("div[class='alert alert-danger']"));
            Assert.AreEqual(reviewErrorMess[2], error.Text);
            GoToAdminPanelReview();
            IWebElement reviewAdmList = driver.FindElement(By.CssSelector("td.text-center[colspan = '7']"));
            Assert.AreEqual("No results!", reviewAdmList.Text);
        }
        [Test(Description = "Negative Test")]
        [TestCase("2c", TestName = "ReviewTest_CreateWithTooShortName")]
        [TestCase("Too long name 26  characts", TestName = "ReviewTest_CreateWithTooLongtName")]
        public void ReviewTest_CreateWithTooShortLongName(string reviewName)
        {
            CreateReview(reviewName, validReviewText);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement error = this.driver.FindElement(By.CssSelector("div[class='alert alert-danger']"));
            Assert.AreEqual(reviewErrorMess[0], error.Text);
            GoToAdminPanelReview();
            IWebElement reviewAdmList = this.driver.FindElement(By.CssSelector("td.text-center[colspan = '7']"));
            Assert.AreEqual("No results!", reviewAdmList.Text);
        }
        [Test(Description = "Negative Test")]
        [TestCase(TooLongTextReview1001char, TestName = "ReviewTest_CreateWithTooLongText")]
        [TestCase("TooShortText24characters", TestName = "ReviewTest_CreateWithTooShortText")]
        public void ReviewTest_CreateWithTooShortLongText(string reviewText)
        {
            CreateReview(ValidReviewName, reviewText);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            IWebElement error = this.driver.FindElement(By.CssSelector("div[class='alert alert-danger']"));
            Assert.AreEqual(reviewErrorMess[1], error.Text);
            GoToAdminPanelReview();
            IWebElement reviewAdmList = this.driver.FindElement(By.CssSelector("td.text-center[colspan = '7']"));
            Assert.AreEqual("No results!", reviewAdmList.Text);
        }

        const string TooLongTextReview1001char = "TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMore" +
           "Than1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDat" +
           "aMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000Test" +
           "DataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan1000TestDataMoreThan10001";
    }
}
