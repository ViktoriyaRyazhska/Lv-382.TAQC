using System;
using System.Threading;
//using System.Windows.Forms;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace UnitTestProjectLv382a
{
    //[TestClass]
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class SeleniumTest
    {
        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //Console.WriteLine("[OneTimeSetUp] BeforeAllMethods()");
            //MessageBox.Show("[OneTimeSetUp] BeforeAllMethods()", "info",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            //Console.WriteLine("[OneTimeTearDown] AfterAllMethods()");
            //MessageBox.Show("[OneTimeTearDown] AfterAllMethods()", "info",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

        // DataProvider
        private static readonly object[] ConverterData =
        {  new object[] { 65, 'A' },
           new object[] { 97, 'a' },
           new object[] { 98, 'b' }
        };

        //[TestMethod]
        //[Test, TestCaseSource(nameof(ConverterData))]
        //[Test, TestCaseSource("ConverterData")]
        [Test]
        public void CheckSeleniumIDE()
        {
            // Precondition
            //IWebDriver driver = new ChromeDriver();
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            Thread.Sleep(2000);  // Not Use. Only for Presentation.
            //
            // Steps
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).SendKeys("seleniumhq docs" + OpenQA.Selenium.Keys.Enter); // Submit the form
            Thread.Sleep(2000);  // Not Use. Only for Presentation.
            //
            driver.FindElement(By.PartialLinkText("Selenium Documentation")).Click();
            Thread.Sleep(2000);  // Not Use. Only for Presentation.
            //
            driver.FindElement(By.LinkText("Download")).Click();
            Thread.Sleep(2000);  // Not Use. Only for Presentation.
            //
            // Check
            string actual = driver.FindElement(By.XPath("//a[@name='selenium_ide']/p")).Text;
            string expected = "Selenium IDE is a Chrome and Firefox plugin which records and plays back user interactions with the browser. Use this to either create simple scripts or assist in exploratory testing.";
            Assert.AreEqual(expected, actual, "Error Message");
            Thread.Sleep(2000);  // Not Use. Only for Presentation.
            //
            // Return to previous State
            // Close the browser + Stop Server
            driver.Quit();
        }
    }
}
