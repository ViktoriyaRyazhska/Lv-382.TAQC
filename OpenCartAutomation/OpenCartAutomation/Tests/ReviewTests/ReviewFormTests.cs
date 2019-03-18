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
              new ReviewTestData("iPhone", "3ch", "Sometext25charactersherel","1", "Disabled"),
              new ReviewTestData("iPhone", "12characters","Sometext50charactersherelSometext50charactersherel", "3", "Disabled"),
              new ReviewTestData( "iPhone", "Somename25charactersherel", TooLongTextReview1001char.Substring(0, 1000), "5", "Disabled")
        };

        [Test(Description = "Positive Tests"), TestCaseSource("ReviewFormTestsPositiveData")]
        public void ReviewTest_CreateWithValidData(ReviewTestData validData)
        {
            CreateReview(validData.revName, validData.revText, validData.revRating);
            Thread.Sleep(2000); // Only for presentation
            Assert.AreEqual("Thank you for your review. It has been submitted to the webmaster for approval.", driver.FindElement(By.CssSelector("div[class='alert alert-success']")).Text);
            GoToAdminPanelReview();
            Thread.Sleep(2000); // Only for presentation
            IWebElement[] review = driver.FindElements(By.CssSelector(".table.table-bordered.table-hover>tbody>tr:nth-child(1)>td")).ToArray();
            Assert.AreEqual(review[1].Text,validData.revProduct,"Wrong product, meaby review is not created");
            Assert.AreEqual(review[2].Text, validData.revName, "Wrong name, meaby review is not created");
            Assert.AreEqual(review[3].Text, validData.revRating.ToString(), "Wrong rating, meaby review is not created");
            Assert.AreEqual(review[4].Text, validData.status, "Wrong status, meaby review is not created or it's posted");
            Assert.AreEqual(review[5].Text, validData.date, "Wrong date, meaby review is not created");
        }

        internal class ReviewTestNegativeData : IEnumerable<ITestCaseData>
        {
            public IEnumerator<ITestCaseData> GetEnumerator()
            {
                yield return new TestCaseData(new ReviewTestData("", validReviewText, validRating, reviewErrorMess[0])).SetName("ReviewsTest_CreateWithEmptyFieldName");
                yield return new TestCaseData(new ReviewTestData(ValidReviewName, "", validRating, reviewErrorMess[1])).SetName("ReviewsTest_CreateWithEmptyFieldText");
                yield return new TestCaseData(new ReviewTestData(ValidReviewName, validReviewText, "0", reviewErrorMess[2])).SetName("ReviewTest_CreateWithNotSelectedRating");
                yield return new TestCaseData(new ReviewTestData("2c", validReviewText, validRating, reviewErrorMess[0])).SetName("ReviewTest_CreateWithTooShortName");
                yield return new TestCaseData(new ReviewTestData("Too long name 26  characts", validReviewText, validRating, reviewErrorMess[0])).SetName("ReviewTest_CreateWithTooLongtName");
                yield return new TestCaseData(new ReviewTestData(ValidReviewName, "TooShortText24characters", validRating, reviewErrorMess[1])).SetName("ReviewTest_CreateWithTooShortText");
                yield return new TestCaseData(new ReviewTestData(ValidReviewName, TooLongTextReview1001char, validRating, reviewErrorMess[1])).SetName("ReviewTest_CreateWithTooLongText");
                yield return new TestCaseData(new ReviewTestData($"{ValidReviewName}%*&@#<>", validReviewText, validRating, reviewErrorMess[3])).SetName("ReviewTest_CreateWithForbiddenCharactersName");
                yield return new TestCaseData(new ReviewTestData(ValidReviewName, $"{validReviewText}%*&@#<>", validRating, reviewErrorMess[4])).SetName("ReviewTest_CreateWithForbiddenCharactersText");
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        [TestCaseSource(typeof(ReviewTestNegativeData))]
        public void ReviewsTest_CreateWithEmptyFieldName(ReviewTestData negativeData)
        {
            CreateReview(negativeData.revName, negativeData.revText, negativeData.revRating);
            Thread.Sleep(2000); // Only for presentation
            Assert.AreEqual(1,driver.FindElements(By.CssSelector(".alert.alert-danger")).Count,"No error message when expected!Review is created!");
            if (negativeData.revError != driver.FindElement(By.CssSelector(".alert.alert-danger")).Text)
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
