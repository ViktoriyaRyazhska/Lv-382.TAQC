using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class AddressComponentsContainer
    {
        private const string ADDRESS_COMPONENTS_XPASS = "table.table-bordered.table-hover tbody";

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
            IList<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
            IWebElement tableComponents = driver.FindElement(By.CssSelector(ADDRESS_COMPONENTS_XPASS));
            for(int i=1; i<=elements.Count; i++)
            {
                addressComponents.Add(new AddressComponent(tableComponents.FindElement(By.XPath("//tr[" + i + "]"))));
            }


            //foreach (IWebElement current in driver.FindElements(By.CssSelector(ADDRESS_COMPONENTS_XPASS)))
            //{
            //    addressComponents.Add(new AddressComponent(current));
            //}
        }

        public List<AddressComponent> GetAddressComponents()
        {
            return addressComponents;
        }



        public void Print()
        {
            foreach(AddressComponent comp in addressComponents)
            {
                Console.WriteLine(comp.GetAddressDescription());
            }
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

        public AddressComponent GetFirstAddress()
        {
            return addressComponents[0];
        }

        public int GetCount()
        {
            return GetAddressComponents().Count;
        }
    }
}
