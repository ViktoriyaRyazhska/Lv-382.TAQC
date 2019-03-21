using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart_Testing.UIMapping.MProductPage
{
    class MProductPage
    {
        public static By locatorDescription => By.CssSelector("a[href*='tab-description']");
        public static By locatorReviews => By.CssSelector("a[href*='tab-review']");
    }
}
