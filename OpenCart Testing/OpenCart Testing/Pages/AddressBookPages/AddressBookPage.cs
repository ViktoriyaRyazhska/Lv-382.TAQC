using OpenCart_Testing.Pages.StaticParts;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class AddressBookPage : ARightLoginPart
    {
        public const string addressBookEntries = "Address Book Entries";

        public IWebElement addressPageHeader => driver.FindElement(MAddressBookPage.locatorAddressPageHeader); 

        private AddressComponentsContainer addressComponentsContainer;

        public AddressBookPage(IWebDriver driver) : base(driver)
        {
            addressComponentsContainer = new AddressComponentsContainer(driver);
        }

        private IWebElement NewAddressButton => driver.FindElement(MAddressBookPage.locatorNewAddressButton);

        public void ClickNewAddressButton()
        {
            NewAddressButton.Click();
        }

        public string GetAddressPageHeaderText()
        {
            return addressPageHeader.Text;
        }

        public AddressComponentsContainer getAddressComponentsContainer()
        {
            return addressComponentsContainer;
        }

        public EditAddressPage EditAddressByName(string name)
        {
            addressComponentsContainer.AddressComponentByNameEdit(name);
            return new EditAddressPage(driver);
        }

        public EditAddressPage EditFirstAddress()
        {
            addressComponentsContainer.AddressComponentEditFirst();
            return new EditAddressPage(driver);
        }

        //public DeleteAddressPage DeleteAddressByName(string name)
        //{
        //    addressComponentsContainer.AddressComponentByNameDelete(name);
        //    return new DeleteAddressPage(driver);
        //}

        //public AddNewAddressPage AddNewAddress(AddressComponent address)
        //{
        //    return new AddNewAddressPage(driver);
        //}
    }
}
