using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCartTesting
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://192.168.183.128/opencart/upload");
            //Console.WriteLine("[SetUp] SetUp()");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] TearDown()");
        }

        public void LoginUser()
        {
            driver.FindElement(By.ClassName("dropdown")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'login')]")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys(Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD"));
            driver.FindElement(By.CssSelector("form > input.btn.btn-primary")).Click();
        }

        public void GoToAddressBook()
        {
            driver.FindElement(By.Id("column-right")).FindElement(By.XPath("//aside[@id='column-right']//a[contains(@href,'address')]")).Click();
        }

        public void LogoutUser()
        {
            driver.FindElement(By.ClassName("dropdown")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
        }

        public void LoginAdmin()
        {
            driver.Navigate().GoToUrl("http://192.168.183.128/opencart/upload/admin");
            driver.FindElement(By.Id("input-username")).SendKeys(Environment.GetEnvironmentVariable("OPENCART_ADMIN_USERNAME"));
            driver.FindElement(By.Id("input-password")).SendKeys(Environment.GetEnvironmentVariable("OPENCART_ADMIN_PASSWORD"));
            driver.FindElement(By.ClassName("btn-primary")).Click();
        }

        public void LogoutAdmin()
        {
            driver.FindElement(By.ClassName("fa-sign-out")).Click();
        }

        public void FillAddressPage(string[] values)
        {
            driver.FindElement(By.ClassName("btn-primary")).Click();
            driver.FindElement(By.Id("input-firstname")).SendKeys(values[0]);
            driver.FindElement(By.Id("input-lastname")).SendKeys(values[1]);
            driver.FindElement(By.Id("input-company")).SendKeys(values[2]);
            driver.FindElement(By.Id("input-address-1")).SendKeys(values[3]);
            driver.FindElement(By.Id("input-address-2")).SendKeys(values[4]);
            driver.FindElement(By.Id("input-city")).SendKeys(values[5]);
            driver.FindElement(By.Id("input-postcode")).SendKeys(values[6]);
            SelectElement countryDropdown = new SelectElement(driver.FindElement(By.Id("input-country")));
            countryDropdown.SelectByText(values[7]);
            SelectElement zoneDropdown = new SelectElement(driver.FindElement(By.Id("input-zone")));
            zoneDropdown.SelectByText(values[8]);
        }

        public static List<string[]> FileReaderToListArray(string path)
        {
            string[] readText = File.ReadAllLines(path);
            List<string[]> validAddressData = new List<string[]>();
            foreach (var line in readText)
            {
                validAddressData.Add(line.Split(','));
            }
            return validAddressData;
        }
    }
}
