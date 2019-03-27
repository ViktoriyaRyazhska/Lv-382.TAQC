using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class AddressComponentsContainer
    {
        private const string ADDRESS_COMPONENT_XPASS = "//tr";

        private IWebDriver driver;

        private IList<AddressComponent> addressComponents;

        public AddressComponentsContainer(IWebDriver driver)
        {
            this.driver = driver;
            InitElements();
        }

        private void InitElements()
        {
            addressComponents = new List<AddressComponent>();
            foreach (IWebElement current in driver.FindElements(By.XPath(ADDRESS_COMPONENT_XPASS)))
            {
                addressComponents.Add(new AddressComponent(current));
            }
        }

        public IList<AddressComponent> GetAddressComponents()
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
                // TODO Develop Custom Exception 
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

        public EditAddressPage EditFirst()
        {
            addressComponents[0].ClickEditButton();
            return new EditAddressPage(driver);
        }

        public void DeleteSecond()
        {
            addressComponents[1].ClickDeleteButton();
        }

        public AddressComponent GetFirstAddress()
        {
            return addressComponents[0];
        }

        public int Count()
        {
            return GetAddressComponents().Count;
        }
    }
}
