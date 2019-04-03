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
        public static By locatorImg => By.XPath("//tbody//td[@class='text-center']");
        //public static By locatorProductName => By.CssSelector("td:nth-child(2)"); #content > div.table-responsive td.text-left > a
        public static By locatorProductName => By.CssSelector("#content > div.table-responsive td.text-left > a");
        public static By locatorModel => By.XPath("//tbody//td[@class='text-left']/text()");
        public static By locatorStock => By.CssSelector("td:nth-child(4)");
        public static By locatorUnitPrice => By.XPath("//tbody//td[@class='text-right']/div[@class='price']");
        public static By locatorAddToCart => By.XPath("//div[@class='table-responsive']//tbody//button");
        public static By locatorRemove => By.XPath("//div[@class='table-responsive']//tbody//a[@class='btn btn-danger']");
    }
}
