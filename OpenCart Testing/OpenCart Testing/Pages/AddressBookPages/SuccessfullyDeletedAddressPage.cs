using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class SuccessfullyDeletedAddressPage: AddressBookPage
    {
        public const string DELETINGNOTDEFAULT = "Your address has been successfully deleted";
        public const string DELETINGDEFAULT = "Warning: You can not delete your default address!";

        private AddressComponentsContainer addressComponentsContainer;
        public IWebElement deletedAddressMessage => driver.FindElement(MSuccessfullyDeletedAddressPage.locatorDeletedAddressMessage);
        public IWebElement notDeletedAddressMessage => driver.FindElement(MSuccessfullyDeletedAddressPage.locatorNotDeletedAddressMessage);

        public SuccessfullyDeletedAddressPage(IWebDriver driver) : base(driver)
        {
            addressComponentsContainer = new AddressComponentsContainer(driver);
        }

        public string GetDeletedAddressMessageText()
        {
            return deletedAddressMessage.Text;
        }

        public string GetNotDeletedAddressMessageText()
        {
            return notDeletedAddressMessage.Text;
        }
    }
}
