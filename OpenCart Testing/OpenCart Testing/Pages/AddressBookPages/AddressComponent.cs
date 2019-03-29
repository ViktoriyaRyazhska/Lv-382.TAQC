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
        //private IWebElement AddressDescription => addressRow.FindElement(MAddressComponent.locatorAddressDescription);
        //private IWebElement EditButton => addressRow.FindElement(MAddressComponent.locatorEditButton);
        //private IWebElement DeleteButton => addressRow.FindElement(MAddressComponent.locatorDeleteButton);


        private IWebElement AddressDescription { get; set; }
        private IWebElement EditButton { get; set; }
        private IWebElement DeleteButton { get; set; }


        public AddressComponent(IWebElement addressRow)
        {
            this.addressRow = addressRow;
        }

        public AddressComponent(IWebElement addressDescription, IWebElement editButton, IWebElement deleteButton)
        {
            AddressDescription = addressDescription;
            EditButton = editButton;
            DeleteButton = deleteButton;
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
