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
        public const string EXPECTEDMESSAGE = "Your address has been successfully deleted";

        private AddressComponentsContainer addressComponentsContainer;
        public IWebElement deletedAddressMessage => driver.FindElement(MSuccessfullyDeletedAddressPage.locatorDeletedAddressMessage);

        public SuccessfullyDeletedAddressPage(IWebDriver driver) : base(driver)
        {
            addressComponentsContainer = new AddressComponentsContainer(driver);
        }

        public string GetDeletedAddressMessageText()
        {
            return deletedAddressMessage.Text;
        }
    }
}
