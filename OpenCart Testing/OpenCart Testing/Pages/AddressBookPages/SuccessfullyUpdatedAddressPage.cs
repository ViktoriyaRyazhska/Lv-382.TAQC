using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class SuccessfullyUpdatedAddressPage: AddressBookPage
    {
        public const string DELETINGNOTDEFAULT = "Your address has been successfully deleted";
        public const string DELETINGDEFAULT = "Warning: You can not delete your default address!";
        public const string NEWADDRESSADDED = "Your address has been successfully inserted";

        private AddressComponentsContainer addressComponentsContainer;
        public IWebElement deletedAddressMessage => driver.FindElement(MSuccessfullyUpdatedAddressPage.locatorDeletedAddressMessage);
        public IWebElement notDeletedAddressMessage => driver.FindElement(MSuccessfullyUpdatedAddressPage.locatorNotDeletedAddressMessage);
        public IWebElement newAddressAddedMessage => driver.FindElement(MSuccessfullyUpdatedAddressPage.locatorNewAddressAddedMessage);

        public SuccessfullyUpdatedAddressPage(IWebDriver driver) : base(driver)
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

        public string GetNewAddressAddedMessageText()
        {
            return newAddressAddedMessage.Text;
        }
    }
}
