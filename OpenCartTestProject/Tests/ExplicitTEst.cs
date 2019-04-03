using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTestProject.Tests
{
    [TestFixture]
    class ExplicitTest
    {
        public static Func<IWebDriver, bool> StalenessOf(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    Console.WriteLine("element == null || !element.Enabled || !element.Displayed " + (element == null || !element.Enabled || !element.Displayed));
                    // Calling any method forces a staleness check
                    return element == null || !element.Enabled || !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> InvisibilityOfElementLocated(By locator)
        {
            return (driver) =>
            {
                try
                {
                    Console.WriteLine("InvisibilityOfElementLocated ...");
                    var element = driver.FindElement(locator);
                    //return (element == null) || (!element.Displayed);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    // Returns true because the element is not present in DOM. The
                    // try block checks if the element is present but is invisible.
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    // Returns true because stale element reference implies that element
                    // is no longer visible.
                    return true;
                }
            };
        }

        //[TestMethod]
        [Test]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new FirefoxDriver();
            //
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://devexpress.github.io/devextreme-reactive/react/grid/docs/guides/paging/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(4000);
            //
            // Move to Element by JavaScript Injection
            //IJavaScriptExecutor javaScript = (IJavaScriptExecutor)driver;
            IJavaScriptExecutor javaScript = driver as IJavaScriptExecutor;
            IWebElement position = driver.FindElement(By.CssSelector("#use-paging-with-other-data-processing-plugins"));
            javaScript.ExecuteScript("arguments[0].scrollIntoView(true);", position);
            Thread.Sleep(2000);
            //
            javaScript.ExecuteScript("alert('scroll done');");
            Thread.Sleep(4000);
            driver.SwitchTo().Alert().Accept();
            //
            // Switch To IFrame
            //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//div[@id='grid-paging-remote-paging-demo-pane-preview']//iframe")));
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("#grid-paging-remote-paging-demo-pane-preview iframe")));
            Thread.Sleep(2000);
            //
            IWebElement tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[contains(text(), '/')]"));
            string firstDate = tdNevadaFirstData.Text;
            string orderNumber = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[3]")).Text;
            Console.WriteLine("1. tdNevadaFirstData = " + tdNevadaFirstData.Text);
            //
            // Goto to Page 2
            //driver.FindElement(By.XPath("//span[text()='2']")).Click();
            driver.FindElement(By.CssSelector("button[aria-label='Next'] span:first-child")).Click();
            //Thread.Sleep(2000);
            //
            // Turn off Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(InvisibilityOfElementLocated(By.XPath("//td[text()='" + firstDate + "']")));
            wait.Until(InvisibilityOfElementLocated(By.XPath("//td[text()='" + orderNumber + "']")));
            //
            // Turn on Implicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // 
            // Get WebElement
            //IWebElement tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[2]"));
            //tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[2]"));
            tdNevadaFirstData = driver.FindElement(By.XPath("//td[text()='Nevada']/preceding-sibling::td[contains(text(), '/')]"));
            Console.WriteLine("2. tdNevadaFirstData2= " + tdNevadaFirstData.Text);
            //
            Thread.Sleep(4000);
            driver.Quit();
        }
    }
}
