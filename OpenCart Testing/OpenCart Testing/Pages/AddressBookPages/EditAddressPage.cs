using OpenCart_Testing.Pages.StaticParts;
using OpenCart_Testing.Pages.UIMapping;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.AddressBookPages
{
    public class EditAddressPage : ARightLoginPart
    {
        public EditAddressPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Firstname => driver.FindElement(MEditAddressPage.locatorFirstnameTextbox);
        public IWebElement Lastname => driver.FindElement(MEditAddressPage.locatorLastnameTextbox);
        public IWebElement Company => driver.FindElement(MEditAddressPage.locatorCompanyTextbox);
        public IWebElement Address1 => driver.FindElement(MEditAddressPage.locatorAddress1Textbox);
        public IWebElement Address2 => driver.FindElement(MEditAddressPage.locatorAddress2Textbox);
        public IWebElement City => driver.FindElement(MEditAddressPage.locatorCityTextbox);
        public IWebElement Postcode => driver.FindElement(MEditAddressPage.locatorPostcodeTextbox);
        public IWebElement Country => driver.FindElement(MEditAddressPage.locatorCountryDropdown);
        public IWebElement Region => driver.FindElement(MEditAddressPage.locatorZoneDropdown);
        public IWebElement DefaultAddress => driver.FindElement(MEditAddressPage.locatorDefaultYes);
        public IWebElement NotDefaultAddress => driver.FindElement(MEditAddressPage.locatorDefaultNo);
        public IWebElement ContinueButton => driver.FindElement(MEditAddressPage.locatorContinueButton);

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

        public AddressBookPage SetOnlyFirstname(string firstname)
        {
            SetFirstname(firstname);
            ClickContinue();
            return new AddressBookPage(driver);
        }

    }
}
