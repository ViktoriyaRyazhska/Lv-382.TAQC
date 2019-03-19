using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenCartTesting
{
    public abstract class TestRunner
    {
        protected IWebDriver driver;
        const int implicitValueInSec = 10;
        protected string mainAdminUrl = "http://192.168.183.129/opencart/upload/admin";
        protected string mainUrl = "http://192.168.183.129/opencart/upload";
        protected string userEmail = Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL");
        protected string userPassword = Environment.GetEnvironmentVariable("OPENCART_USER_PASSWORD");
        protected string adminUsername = Environment.GetEnvironmentVariable("OPENCART_ADMIN_USERNAME");
        protected string adminPassword = Environment.GetEnvironmentVariable("OPENCART_ADMIN_PASSWORD");

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitValueInSec);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(mainUrl);
        }

        public void LoginUser()
        {
            driver.FindElement(By.XPath("//div[@id='top-links']//a[@data-toggle='dropdown']")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'login')]")).Click();
            driver.FindElement(By.Id("input-email")).SendKeys(userEmail);
            driver.FindElement(By.Id("input-password")).SendKeys(userPassword);
            driver.FindElement(By.XPath("//input[@class='btn btn-primary']")).Click();
        }

        public void LogoutUser()
        {
            driver.FindElement(By.ClassName("dropdown")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']//a[contains(@href, 'logout')]")).Click();
        }
        
        public void GoToAddressBook()
        {
            driver.FindElement(By.Id("column-right")).FindElement(By.XPath("//aside[@id='column-right']//a[contains(@href,'address')]")).Click();
        }
        
        public void LoginAdmin()
        {
            driver.Navigate().GoToUrl(mainAdminUrl);
            driver.FindElement(By.Id("input-username")).SendKeys(adminUsername);
            driver.FindElement(By.Id("input-password")).SendKeys(adminPassword);
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

        public void DeleteLastAddedAddress()
        {
            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[last()]/td[@class='text-right']/a[@class='btn btn-danger']")).Click();
        }
    }
}