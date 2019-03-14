using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCartAutomation
{
    [TestFixture]
    public partial class RevieListTests : ReviewTestRunner
    {
        [Test(Description = "PositiveTest")]
        public void ReviewsTest_NumberOfRecords()
        {
            this.driver.Navigate().GoToUrl(testProductPageAddress);
            int countOfRewiews = int.Parse(driver.FindElement(By.CssSelector("a[href='#tab-review']")).Text.Split(new char[] { '(', ')' })[1]);
            Assert.AreEqual(0, countOfRewiews);
        }

        [Test(Description = "Positive Test")]
        public void ReviewsTest_EmptyListText()
        {
            this.driver.Navigate().GoToUrl(testProductPageAddress);
            this.driver.FindElement(By.CssSelector("a[href='#tab-review']")).Click();
            Assert.AreEqual("There are no reviews for this product.", driver.FindElement(By.CssSelector("#review>p")).Text);
        }
    }
}
