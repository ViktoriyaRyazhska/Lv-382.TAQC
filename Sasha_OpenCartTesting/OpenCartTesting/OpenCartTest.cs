using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace OpenCartTesting
{
    [TestFixture]
    public class OpenCartAddressBookTest : TestRunner
    {
        [Test]
        public void VerifyCorectnessOfAddressList()
        {
            int countAddressOnUserPage = 1;
            int countAddressOnAdminPage = 1;

            LoginUser();
            GoToAddressBook();
            countAddressOnUserPage = driver.FindElements(By.ClassName("text-left")).Count;
            LogoutUser();

            LoginAdmin();
            IWebElement menuCustomers = driver.FindElement(By.ClassName("fa-user"));
            new Actions(driver).MoveToElement(menuCustomers).Perform();
            Thread.Sleep(2000); //For presentation ONLY
            driver.FindElement(By.PartialLinkText("Customers")).Click();
            Thread.Sleep(2000); //For presentation ONLY

            driver.FindElement(By.XPath("//div[@class='table-responsive']//td[contains(text(), '" + 
                Environment.GetEnvironmentVariable("OPENCART_USER_EMAIL") + "')]/..//a[@data-original-title='Edit']")).Click();
            Thread.Sleep(2000); //For presentation ONLY
            countAddressOnAdminPage = driver.FindElements(By.ClassName("fa-minus-circle")).Count;
            LogoutAdmin();

            NUnit.Framework.Assert.AreEqual(countAddressOnAdminPage, countAddressOnUserPage);
        }




        internal class CheckingAddressBookEditFunctionalityForTextboxes : IEnumerable<ITestCaseData>
        {

            public IEnumerator<ITestCaseData> GetEnumerator()
            {
                yield return new TestCaseData("Sasha", "input-firstname").SetName("CheckAddressBookEditFunctionalityWithValidFirstname");
                yield return new TestCaseData("Yarmoliuk", "input-lastname").SetName("CheckAddressBookEditFunctionalityWithValidLastname");
                yield return new TestCaseData("5th Avenue", "input-address-1").SetName("CheckAddressBookEditFunctionalityWithValidAddress1");
                yield return new TestCaseData("New York", "input-city").SetName("CheckAddressBookEditFunctionalityWithValidCity");
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        [Test, TestCaseSource(typeof(CheckingAddressBookEditFunctionalityForTextboxes))]
        public void CheckAddressBookEditFunctionalityWithValidFirstname(string data, string locator)
        {
            string initialData;

            LoginUser();
            GoToAddressBook();
            Thread.Sleep(2000); //For presentation ONLY

            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[1]/td[@class='text-right']/a[contains(@href, 'edit')]")).Click();
            Thread.Sleep(2000); //For presentation ONLY

            initialData = driver.FindElement(By.Id(locator)).GetAttribute("value");

            driver.FindElement(By.Id(locator)).Clear();
            driver.FindElement(By.Id(locator)).SendKeys(data + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(2000); //For presentation ONLY

            NUnit.Framework.Assert.AreEqual(true, driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[1]/td[@class='text-left']")).Text.Contains(data));

            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[1]/td[@class='text-right']/a[contains(@href, 'edit')]")).Click();
            driver.FindElement(By.Id(locator)).Clear();
            driver.FindElement(By.Id(locator)).SendKeys(initialData + OpenQA.Selenium.Keys.Enter);

            LogoutUser();
        }




        public static string [] Country()
        {
            string [] country = new  string []
            {
                "Ukraine",
                "United States"
            };

            return country;
        }
        [Test, TestCaseSource("Country")]
        public void CheckAddressBookEditFunctionalityWithCountryAndNoRegion(string country)
        {
            LoginUser();
            GoToAddressBook();
            Thread.Sleep(2000); //For presentation ONLY

            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[1]/td[@class='text-right']/a[contains(@href, 'edit')]")).Click();
            Thread.Sleep(2000); //For presentation ONLY

            SelectElement countryDropdown = new SelectElement(driver.FindElement(By.Id("input-country")));
            countryDropdown.SelectByText(country);

            driver.FindElement(By.ClassName("btn-primary")).Click();
            Thread.Sleep(2000); //For presentation ONLY

            NUnit.Framework.Assert.IsTrue(driver.Url.Contains("address/edit"));
            
            LogoutUser();
        }





        [Test]
        public void CheckDeletingOfNotDefaultAddress()
        {
            int countAddressBeforeDeletinge = 0;
            int countAddressAfterDeleting = 0;

            LoginUser();
            GoToAddressBook();
            Thread.Sleep(2000); //For presentation ONLY
            countAddressBeforeDeletinge = driver.FindElements(By.ClassName("text-left")).Count;

            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[1]/td[@class='text-right']/a[contains(@href, 'edit')]")).Click();
            Thread.Sleep(2000); //For presentation ONLY
            driver.FindElement(By.XPath("//input[@value='1']")).Click();
            Thread.Sleep(2000); //For presentation ONLY
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Thread.Sleep(2000); //For presentation ONLY

            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[2]/td[@class='text-right']/a[contains(@href, 'delete')]")).Click();
            Thread.Sleep(2000); //For presentation ONLY

            countAddressAfterDeleting = driver.FindElements(By.ClassName("text-left")).Count;
            countAddressAfterDeleting += 1;
            LogoutUser();

            NUnit.Framework.Assert.AreEqual(countAddressAfterDeleting, countAddressBeforeDeletinge);
        }



        [Test]
        public void CheckDeletingOfDefaultAddress()
        {
            LoginUser();
            GoToAddressBook();
            Thread.Sleep(2000); //For presentation ONLY

            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[1]/td[@class='text-right']/a[contains(@href, 'edit')]")).Click();
            Thread.Sleep(2000); //For presentation ONLY
            driver.FindElement(By.XPath("//input[@value='1']")).Click();
            Thread.Sleep(2000); //For presentation ONLY
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Thread.Sleep(2000); //For presentation ONLY

            driver.FindElement(By.XPath("//div[@class='table-responsive']/table/tbody/tr[1]/td[@class='text-right']/a[contains(@href, 'delete')]")).Click();

            string expectedMessage = "Warning: You can not delete your default address!";
            string actualMessage = driver.FindElement(By.ClassName("alert-warning")).Text;

            LogoutUser();
            NUnit.Framework.Assert.AreEqual(actualMessage, expectedMessage);
        }



        private static List<string[]> ValidAddressData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "../../ValidAddressData.txt";
            return FileReaderToListArray(path);
        }
        [Test, TestCaseSource("ValidAddressData")]
        public void CheckCreatingNewAddressWithValidData(string[] values)
        {
            int countAddressBeforeAdding = 0;
            int countAddressAfterAdding = 0;

            LoginUser();
            GoToAddressBook();
            countAddressBeforeAdding = driver.FindElements(By.ClassName("text-left")).Count;

            FillAddressPage(values);
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Thread.Sleep(1000);

            countAddressAfterAdding = driver.FindElements(By.ClassName("text-left")).Count;
            DeleteLastAddedAddress();
            LogoutUser();

            NUnit.Framework.Assert.AreEqual(countAddressAfterAdding, countAddressBeforeAdding + 1);
        }




        private static List<string[]> InvalidAddressData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "../../InvalidAddressData.txt";
            return FileReaderToListArray(path);
        }
        [Test, TestCaseSource("InvalidAddressData")]
        public void CheckCreatingNewAddressWithInvalidData(string[] values)
        {
            LoginUser();
            GoToAddressBook();

            FillAddressPage(values);
            driver.FindElement(By.ClassName("btn-primary")).Click();
            Thread.Sleep(1000);

            if (driver.Url.Contains("address/add"))
            {
                string body = driver.FindElement(By.XPath("//div[@id='content']//div[contains(@class, 'has-error')]")).Text;                LogoutUser();
                NUnit.Framework.Assert.IsTrue(body.Contains(values[10]));
            }
            else
            {
                DeleteLastAddedAddress();
                LogoutUser();
                NUnit.Framework.Assert.IsTrue(false);
            }
            
        }
        
    }
}

