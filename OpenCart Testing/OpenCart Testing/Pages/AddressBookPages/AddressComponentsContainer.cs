using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class AddressComponentsContainer
    {
        private const string ADDRESS_COMPONENTS_XPASS = "//tr";

        private IWebDriver driver;

        private List<AddressComponent> addressComponents;

        public AddressComponentsContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }

        private void InitElements()
        {
            addressComponents = new List<AddressComponent>();
            int rowsCount = driver.FindElements(By.XPath(ADDRESS_COMPONENTS_XPASS)).Count;            
            AddressComponent address;
            for (int i= 1; i <= rowsCount; i++)
            {
                address = new AddressComponent(driver.FindElement(By.XPath(ADDRESS_COMPONENTS_XPASS + "[" + i + "]" + MAddressComponent.locatorAddressDescription)),
                    driver.FindElement(By.XPath(ADDRESS_COMPONENTS_XPASS + "[" + i + "]" + MAddressComponent.locatorEditButton)),
                    driver.FindElement(By.XPath(ADDRESS_COMPONENTS_XPASS + "[" + i + "]" + MAddressComponent.locatorDeleteButton)));
                addressComponents.Add(address);
            }            
        }

        public List<AddressComponent> GetAddressComponents()
        {
            return addressComponents;
        }
        
        AddressComponent GetAddressComponentByName(string addressName)
        {
            AddressComponent result = null;
            foreach (AddressComponent current in GetAddressComponents())
            {
                if (current.GetAddressDescription().ToLower()
                        .Contains(addressName.ToLower()))
                {
                    result = current;
                    break;
                }
            }
            if (result == null)
            {
                throw new Exception("AddressName: " + addressName + " not Found.");
            }
            return result;
        }

        public void EditByName(string addressName)
        {
            GetAddressComponentByName(addressName).ClickEditButton();
            EditAddressPage page = new EditAddressPage(driver);
        }

        public void DeleteByName(string addressName)
        {
            GetAddressComponentByName(addressName).ClickDeleteButton();
        }

        public void ClickEditFirst()
        {
            addressComponents[0].ClickEditButton();
        }

        public void ClickDeleteFirst()
        {
            addressComponents[0].ClickDeleteButton();
        }

        public void ClickDeleteSecond()
        {
            addressComponents[1].ClickDeleteButton();
        }

        public void ClickDeleteLast()
        {
            addressComponents[addressComponents.Count-1].ClickDeleteButton();
        }

        public AddressComponent GetFirstAddress()
        {
            return addressComponents[0];
        }

        public AddressComponent GetLastAddress()
        {
            return addressComponents[addressComponents.Count - 1];
        }

        public int GetCount()
        {
            return GetAddressComponents().Count;
        }
    }
}
