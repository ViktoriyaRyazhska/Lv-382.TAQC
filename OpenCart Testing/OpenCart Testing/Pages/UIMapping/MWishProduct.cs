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
        public static By locatorImg => By.CssSelector("td:nth-child(1)");
        public static By locatorProductName => By.CssSelector("td:nth-child(2)");
        public static By locatorModel => By.CssSelector("td:nth-child(3)");
        public static By locatorStock => By.CssSelector("td:nth-child(4)");
        public static By locatorUnitPrice => By.CssSelector("td:nth-child(5)");
        public static By locatorAddToCart => By.CssSelector("td:nth-child(6) button");
        public static By locatorRemove => By.CssSelector("td:nth-child(6) a");
    }
}
