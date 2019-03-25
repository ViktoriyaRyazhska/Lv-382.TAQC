using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MEditAddressPage
    {
        public static By locatorFirstnameTextbox => By.Id("input-firstname");
        public static By locatorLastnameTextbox => By.Id("input-lastname");
        public static By locatorCompanyTextbox => By.Id("input-company");
        public static By locatorAddress1Textbox => By.Id("input-address-1");
        public static By locatorAddress2Textbox => By.Id("input-address-2");
        public static By locatorCityTextbox => By.Id("input-city");
        public static By locatorPostcodeTextbox => By.Id("input-postcode");
        public static By locatorCountryDropdown => By.Id("input-country");
        public static By locatorZoneDropdown => By.Id("input-zone");
        public static By locatorDefaultYes => By.XPath("//input[@value='1']");
        public static By locatorDefaultNo => By.XPath("//input[@value='0']");
        public static By locatorContinueButton => By.ClassName("btn-primary");
    }
}
