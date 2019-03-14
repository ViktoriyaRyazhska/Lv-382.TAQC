using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OpenCartAutomation
{
    [TestFixture]
    public partial class ReviewFormTests : ReviewTestRunner
    {
        static readonly object[] ReviewFormTestsPositiveData =
        {
              new object[] { "iPhone", "3ch", "1", "Disabled", currentDate, "Sometext25charactersherel" },
              new object[] { "iPhone", "12characters", "3", "Disabled", currentDate, "Sometext50charactersherelSometext50charactersherel" },
              new object[] { "iPhone", "Somename25charactersherel", "5", "Disabled", currentDate, TooLongTextReview1001char.Substring(0,1000) }
        };

        [Test(Description = "Positive Tests"), TestCaseSource("ReviewFormTestsPositiveData")]
        public void ReviewTest_CreateWithValidData(object[] validData)
        {
            CreateReview(validData[1].ToString(), validData[5].ToString(), byte.Parse(validData[2].ToString()));
            IWebElement validAlert = driver.FindElement(By.CssSelector("div[class='alert alert-success']"));
            Thread.Sleep(2000); // Only for presentation
            Assert.AreEqual("Thank you for your review. It has been submitted to the webmaster for approval.", validAlert.Text);
            GoToAdminPanelReview();
            Thread.Sleep(2000); // Only for presentation
            IWebElement[] review = driver.FindElements(By.CssSelector(".table.table-bordered.table-hover>tbody>tr:nth-child(1)>td")).ToArray();
            for (int i = 1; i <= 5; i++)
            {
                Assert.AreEqual(validData[i - 1], review[i].Text);
            }
        }

        internal class ReviewTestNegativeData : IEnumerable<ITestCaseData>
        {
            public IEnumerator<ITestCaseData> GetEnumerator()
            {
                yield return new TestCaseData("", validReviewText, validRating, reviewErrorMess[0]).SetName("ReviewsTest_CreateWithEmptyFieldName");
                yield return new TestCaseData(ValidReviewName, "", validRating, reviewErrorMess[1]).SetName("ReviewsTest_CreateWithEmptyFieldText");
                yield return new TestCaseData(ValidReviewName, validReviewText, (byte)0, reviewErrorMess[2]).SetName("ReviewTest_CreateWithNotSelectedRating");
                yield return new TestCaseData("2c", validReviewText, validRating, reviewErrorMess[0]).SetName("ReviewTest_CreateWithTooShortName");
                yield return new TestCaseData("Too long name 26  characts", validReviewText, validRating, reviewErrorMess[0]).SetName("ReviewTest_CreateWithTooLongtName");
                yield return new TestCaseData(ValidReviewName, "TooShortText24characters", validRating, reviewErrorMess[1]).SetName("ReviewTest_CreateWithTooShortText");
                yield return new TestCaseData(ValidReviewName, TooLongTextReview1001char, validRating, reviewErrorMess[1]).SetName("ReviewTest_CreateWithTooLongText");
                yield return new TestCaseData($"{ValidReviewName} + %*&@#<>", validReviewText, validRating, reviewErrorMess[3]).SetName("ReviewTest_CreateWithForbiddenCharactersName");
                yield return new TestCaseData(ValidReviewName, $"{validReviewText} + %*&@#<>", validRating, reviewErrorMess[4]).SetName("ReviewTest_CreateWithForbiddenCharactersText");
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        [TestCaseSource(typeof(ReviewTestNegativeData))]
        public void ReviewsTest_CreateWithEmptyFieldName(string name, string text, byte rating, string errorMess)
        {
            CreateReview(name, text, rating);
            Thread.Sleep(2000); // Only for presentation
            Assert.AreEqual(1,driver.FindElements(By.CssSelector("div[class='alert alert-danger']")).Count,"No error message when expected!");
            if (errorMess != driver.FindElement(By.CssSelector("div[class='alert alert-danger']")).Text)
            {
                Assert.Warn("Error messages are different!");
            }
            GoToAdminPanelReview();
            Thread.Sleep(2000); // Only for presentation
            IWebElement reviewAdmList = driver.FindElement(By.CssSelector("td.text-center[colspan = '7']"));
            Assert.AreEqual("No results!", reviewAdmList.Text, "Expected that review is not created but actual review is created");
        }
    }

}
