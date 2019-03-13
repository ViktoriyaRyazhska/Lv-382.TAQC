using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace OpenCartTesting
{
    [TestFixture]
    public partial class OpenCartAddressBookTest : TestRunner
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
            driver.FindElement(By.XPath("//*[@data-original-title='Edit']")).Click();
            Thread.Sleep(2000); //For presentation ONLY
            countAddressOnAdminPage = driver.FindElements(By.ClassName("fa-minus-circle")).Count;
            LogoutAdmin();

            NUnit.Framework.Assert.AreEqual(countAddressOnAdminPage, countAddressOnUserPage);
        }



        private static readonly object[] validFirstname =
        {
           "Sasha",
           "Oleksandra"
        };
        [Test, TestCaseSource("validFirstname")]
        public void CheckAddressBookEditFunctionality(string firstname)
        {
            LoginUser();
            GoToAddressBook();
            Thread.Sleep(2000); //For presentation ONLY

            driver.FindElement(By.ClassName("btn-info")).Click();
            Thread.Sleep(2000); //For presentation ONLY
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(firstname + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(2000); //For presentation ONLY

            NUnit.Framework.Assert.AreEqual(true, driver.FindElement(By.ClassName("text-left")).Text.Contains(firstname));

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
            string path = @"C:\Users\sasha\Desktop\Lv-382.TAQC\Sasha_OpenCartTesting\OpenCartTesting\ValidAddressData.txt";
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
            LogoutUser();

            NUnit.Framework.Assert.AreEqual(countAddressAfterAdding, countAddressBeforeAdding + 1);
        }




        private static List<string[]> InvalidAddressData()
        {
            string path = @"C:\Users\sasha\Desktop\Lv-382.TAQC\Sasha_OpenCartTesting\OpenCartTesting\InvalidAddressData.txt";
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
                IWebElement body = driver.FindElement(By.XPath("//div[@id='content']//div[contains(@class, 'has-error')]"));
                LogoutUser();
                NUnit.Framework.Assert.IsTrue(body.Text.Contains(values[10]));
            }
            else
            {
                LogoutUser();
                NUnit.Framework.Assert.IsTrue(false);
            }


            //Console.WriteLine(values[10]);
            //NUnit.Framework.Assert.IsTrue(body.Text.Contains(values[10]));
        }


    }
}
