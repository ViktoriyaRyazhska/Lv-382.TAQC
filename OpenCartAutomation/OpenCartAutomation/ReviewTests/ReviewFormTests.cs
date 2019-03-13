using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OpenCartAutomation
{
    [TestFixture]
    public partial class ReviewFormTests : ReviewTestRunner
    {

        static readonly object[] ReviewFormTestsPosistiveData =
{
              new object[] { "iPhone", "3ch", "1", "Disabled", currentDate, "Sometext25charactersherel" },
              new object[] { "iPhone", "12characters", "3", "Disabled", currentDate, "Sometext50charactersherelSometext50charactersherel" },
              new object[] { "iPhone", "Somename25charactersherel", "5", "Disabled", currentDate, TooLongTextReview1001char.Substring(0,1000) }
        };
        [Test(Description = "Positive Tests"), TestCaseSource("ReviewFormTestsPosistiveData")]
        public void ReviewTest_CreateWithValidData(object[] data)
        {
            CreateReview(data[1].ToString(), data[5].ToString(), byte.Parse(data[2].ToString()));
            IWebElement validAlert = this.driver.FindElement(By.CssSelector("div[class='alert alert-success']"));
            Assert.AreEqual("Thank you for your review. It has been submitted to the webmaster for approval.", validAlert.Text);
            GoToAdminPanelReview();
            IWebElement[] review = this.driver.FindElements(By.CssSelector(".table.table-bordered.table-hover>tbody>tr:nth-child(1)>td")).ToArray();
            for (int i = 1; i <= 5; i++)
            {
                Assert.AreEqual(data[i - 1], review[i].Text);
            }
        }
        internal class ReviewTestNegativeData : IEnumerable<ITestCaseData>
        {

            public IEnumerator<ITestCaseData> GetEnumerator()
            {
                yield return new TestCaseData("", validReviewText, 1, reviewErrorMess[0]).SetName("ReviewsTest_CreateWithEmpryFieldName").SetDescription($"Error massage {reviewErrorMess[0]}  and not created review are expected");
                yield return new TestCaseData(ValidReviewName, "", 2, reviewErrorMess[1]).SetName("ReviewsTest_CreateWithEmpryFielText").SetDescription($"Error massage {reviewErrorMess[0]}  and not created review are expected");
                yield return new TestCaseData(ValidReviewName, validReviewText, 0, reviewErrorMess[2]).SetName("ReviewTest_CreateWithNotSelectedRating").SetDescription($"Error massage {reviewErrorMess[2]}  and not created review are expected");
                yield return new TestCaseData("2c", validReviewText, 3, reviewErrorMess[0]).SetName("ReviewTest_CreateWithTooShortName").SetDescription($"Error massage {reviewErrorMess[0]}  and not created review are expected");
                yield return new TestCaseData("Too long name 26  characts", validReviewText, 4, reviewErrorMess[0]).SetName("ReviewTest_CreateWithTooLongtName").SetDescription($"Error massage {reviewErrorMess[0]} and not created review are expected");
                yield return new TestCaseData(ValidReviewName, "TooShortText24characters", 5, reviewErrorMess[1]).SetName("ReviewTest_CreateWithTooShortText").SetDescription($"Error massage {reviewErrorMess[1]} and not created review are expected");
                yield return new TestCaseData(ValidReviewName, TooLongTextReview1001char, 1, reviewErrorMess[1]).SetName("ReviewTest_CreateWithTooLongText").SetDescription($"Error massage {reviewErrorMess[1]} and not created review are expected");
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        [TestCaseSource(typeof(ReviewTestNegativeData))]
        public void ReviewsFormTest_NegativeTests(string yourName, string yourText, int yourRating, string ErrorMess)
        {
            CreateReview(yourName, yourText, byte.Parse(yourRating.ToString()));
            Assert.AreEqual(1, driver.FindElements(By.CssSelector("div[class='alert alert-danger']")).Count, "No error messages when expected");
            Assert.AreEqual(ErrorMess,driver.FindElement(By.CssSelector("div[class='alert alert-danger']")).Text);
            GoToAdminPanelReview();
            IWebElement reviewAdmList = driver.FindElement(By.CssSelector("td.text-center[colspan = '7']"));
            Assert.AreEqual("No results!", reviewAdmList.Text, "Expected that review is not created but actual review is created");
        }
    }

}
