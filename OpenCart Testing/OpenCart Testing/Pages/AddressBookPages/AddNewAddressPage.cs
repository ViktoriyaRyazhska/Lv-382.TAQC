using OpenCart_Testing.Pages.StaticParts;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class AddNewAddressPage: ARightLoginPart
    {
        public AddNewAddressPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Firstname => driver.FindElement(MAddNewAddressPage.locatorFirstnameTextbox);
        public IWebElement Lastname => driver.FindElement(MAddNewAddressPage.locatorLastnameTextbox);
        public IWebElement Company => driver.FindElement(MAddNewAddressPage.locatorCompanyTextbox);
        public IWebElement Address1 => driver.FindElement(MAddNewAddressPage.locatorAddress1Textbox);
        public IWebElement Address2 => driver.FindElement(MAddNewAddressPage.locatorAddress2Textbox);
        public IWebElement City => driver.FindElement(MAddNewAddressPage.locatorCityTextbox);
        public IWebElement Postcode => driver.FindElement(MAddNewAddressPage.locatorPostcodeTextbox);
        public IWebElement Country => driver.FindElement(MAddNewAddressPage.locatorCountryDropdown);
        public IWebElement Region => driver.FindElement(MAddNewAddressPage.locatorZoneDropdown);
        public IWebElement DefaultAddress => driver.FindElement(MAddNewAddressPage.locatorDefaultYes);
        public IWebElement NotDefaultAddress => driver.FindElement(MAddNewAddressPage.locatorDefaultNo);
        public IWebElement ContinueButton => driver.FindElement(MAddNewAddressPage.locatorContinueButton);

        public string GetFirstnameText()
        {
            return Firstname.Text;
        }

        public void SetFirstname(string firstname)
        {
            Firstname.ClearAndSendKeys(firstname);
        }

        public string GetLastnameText()
        {
            return Lastname.Text;
        }

        public void SetLastname(string lastname)
        {
            Lastname.ClearAndSendKeys(lastname);
        }

        public string GetCompanyText()
        {
            return Company.Text;
        }

        public void SetCompany(string company)
        {
            Company.ClearAndSendKeys(company);
        }

        public string GetAddress1Text()
        {
            return Address1.Text;
        }

        public void SetAddress1(string address1)
        {
            Address1.ClearAndSendKeys(address1);
        }

        public string GetAddress2Text()
        {
            return Address2.Text;
        }

        public void SetAddress2(string address2)
        {
            Address2.ClearAndSendKeys(address2);
        }

        public string GetCityText()
        {
            return City.Text;
        }

        public void SetCity(string city)
        {
            City.ClearAndSendKeys(city);
        }

        public string GetPostcodeText()
        {
            return Postcode.Text;
        }

        public void SetPostcode(string postcode)
        {
            Postcode.ClearAndSendKeys(postcode);
        }

        public string GetCountryText()
        {
            return Country.Text;
        }

        public void SetCountry(string country)
        {
            new SelectElement(Country).SelectByText(country);
        }

        public string GetRegionText()
        {
            return Firstname.Text;
        }

        public void SetRegion(string region)
        {
            new SelectElement(Region).SelectByText(region);
        }

        public void SetAsDefault()
        {
            DefaultAddress.Click();
        }

        public void SetAsNotDefault()
        {
            NotDefaultAddress.Click();
        }

        public void ClickContinue()
        {
            ContinueButton.Click();
        }

        public void FillAddress()
        {

        }
    }
}
