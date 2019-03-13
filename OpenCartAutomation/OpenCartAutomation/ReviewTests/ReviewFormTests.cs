using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Collections;
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
            IWebElement validAlert = driver.FindElement(By.CssSelector("div[class='alert alert-success']"));
            Assert.AreEqual("Thank you for your review. It has been submitted to the webmaster for approval.", validAlert.Text);
            GoToAdminPanelReview();
            IWebElement[] review = driver.FindElements(By.CssSelector(".table.table-bordered.table-hover>tbody>tr:nth-child(1)>td")).ToArray();
            for (int i = 1; i <= 5; i++)
            {
                Assert.AreEqual(data[i - 1], review[i].Text);
            }
        }

        [TestCaseSource(typeof(ReviewTestNegativeData))]
        public void ReviewsTest_CreateWithEmptyFieldName(object[] InvalidData)
        {
            CreateReview(InvalidData[0].ToString(), InvalidData[1].ToString(), byte.Parse(InvalidData[2].ToString()));
            Assert.AreEqual(1, driver.FindElements(By.CssSelector("div[class='alert alert-danger']")).Count, "No error messages when expected");
            Assert.AreEqual(InvalidData[3],driver.FindElement(By.CssSelector("div[class='alert alert-danger']")).Text);
            GoToAdminPanelReview();
            IWebElement reviewAdmList = driver.FindElement(By.CssSelector("td.text-center[colspan = '7']"));
            Assert.AreEqual("No results!", reviewAdmList.Text, "Expected that review is not created but actual review is created");
        }
    }

}
