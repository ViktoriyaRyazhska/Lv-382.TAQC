using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.Pages.UIMapping.MWishPoduct
{
    class MWishProduct
    {
        public static By locatorImg => By.XPath("//tbody//td[1]");
        public static By locatorProductName => By.XPath("//tbody//td[2]");
        public static By locatorModel => By.XPath("//tbody//td[3]");
        public static By locatorStock => By.XPath("//tbody//td[4]");
        public static By locatorUnitPrice => By.XPath("//tbody//td[5]");
        public static By locatorAddToCart => By.XPath("//button[@class='btn btn-primary']");
        public static By locatorRemove => By.XPath("//a[@class='btn btn-danger']");
    }
}
