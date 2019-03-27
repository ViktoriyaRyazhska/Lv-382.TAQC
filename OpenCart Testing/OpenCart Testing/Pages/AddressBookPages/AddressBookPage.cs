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
            addressComponentsContainer.EditFirst();
            return new EditAddressPage(driver);
        }

        public SuccessfullyDeletedAddressPage DeleteSecondAddress()
        {
            addressComponentsContainer.DeleteSecond();
            return new SuccessfullyDeletedAddressPage(driver);
        }

        public void SetFirstDefault()
        {
            EditAddressPage page = addressComponentsContainer.EditFirst();
            page.SetAsDefault();
            Thread.Sleep(2000);
            page.ClickContinue();
        }
        

        //public AddNewAddressPage AddNewAddress(AddressComponent address)
        //{
        //    return new AddNewAddressPage(driver);
        //}
    }
}
