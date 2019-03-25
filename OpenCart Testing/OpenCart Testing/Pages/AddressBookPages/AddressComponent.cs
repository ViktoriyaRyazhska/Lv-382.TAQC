using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class AddressComponent
    {
        private IWebElement addressRow;
        private IWebElement AddressDescription => addressRow.FindElement(MAddressComponent.locatorAddressDescription);
        private IWebElement EditButton => addressRow.FindElement(MAddressComponent.locatorEditButton);
        private IWebElement DeleteButton => addressRow.FindElement(MAddressComponent.locatorDeleteButton);

        public AddressComponent(IWebElement addressRow)
        {
            this.addressRow = addressRow;
        }

        public string GetAddressDescription()
        {
            return AddressDescription.Text;
        }

        public void ClickEditButton()
        {
            EditButton.Click();
        }

        public void ClickDeleteButton()
        {
            DeleteButton.Click();
        }
    }
}
