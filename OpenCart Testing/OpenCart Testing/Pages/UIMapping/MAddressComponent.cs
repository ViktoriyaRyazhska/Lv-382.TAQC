using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping
{
    class MAddressComponent
    {
        public static By locatorAddressDescription => By.XPath("//td[@class='text-left']");
        public static By locatorEditButton => By.XPath("//td[@class='text-right']/a[@class='btn btn-info']");
        public static By locatorDeleteButton => By.XPath("//td[@class='text-right']/a[@class='btn btn-danger']");
    }
}
