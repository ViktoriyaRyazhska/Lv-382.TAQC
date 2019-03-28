using OpenCart_Testing.Pages.StaticParts;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class AddressBookPage : ARightLoginPart
    {
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

        public AddressComponentsContainer GetAddressComponentsContainer()
        {
            return addressComponentsContainer;
        }

        public EditAddressPage EditAddressByName(string name)
        {
            addressComponentsContainer.EditByName(name);
            return new EditAddressPage(driver);
        }

        public EditAddressPage EditFirstAddress()
        {
            addressComponentsContainer.ClickEditFirst();
            return new EditAddressPage(driver);
        }

        public SuccessfullyDeletedAddressPage DeleteFirstAddress()
        {
            addressComponentsContainer.ClickDeleteFirst();
            return new SuccessfullyDeletedAddressPage(driver);
        }

        public SuccessfullyDeletedAddressPage DeleteSecondAddress()
        {
            addressComponentsContainer.ClickDeleteSecond();
            return new SuccessfullyDeletedAddressPage(driver);
        }

        public AddressBookPage SetFirstDefault()
        {
            addressComponentsContainer.ClickEditFirst();
            EditAddressPage page = new EditAddressPage(driver);
            page.SetAsDefault();
            page.ClickContinue();
            return new AddressBookPage(driver);
        }

        public void LogoutUser()
        {
            ClickLogoutUserButton();
        }
        

        //public AddNewAddressPage AddNewAddress(AddressComponent address)
        //{
        //    return new AddNewAddressPage(driver);
        //}
    }
}
